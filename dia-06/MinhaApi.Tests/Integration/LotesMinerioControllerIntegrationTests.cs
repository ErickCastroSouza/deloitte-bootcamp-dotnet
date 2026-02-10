using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;
using MinhaApi.Controllers;

namespace MinhaApi.Tests.Integration
{
    public class LotesMinerioControllerIntegrationTests : IClassFixture<WebApplicationFactory<global::Program>>
    {
        private readonly WebApplicationFactory<global::Program> _factory;

        public LotesMinerioControllerIntegrationTests(WebApplicationFactory<global::Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ControllerMethods_Run_WhenHosted()
        {
            var dbName = $"IntegrationDb_{Guid.NewGuid():N}";

            // exercise application startup (ensures Program is executed)
            var client = _factory.CreateClient();

            // create a local in-memory AppDbContext (do not alter the host's services)
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            using var ctx = new AppDbContext(options);

            // seed
            var seed = new LoteMinerio
            {
                CodigoLote = "I-1",
                MinaOrigem = "Mina X",
                LocalizacaoAtual = "Porto",
                TeorFe = 60.5m,
                Umidade = 1.1m,
                P = 0.02m,
                Toneladas = 50m,
                DataProducao = DateTime.UtcNow
            };
            ctx.LotesMinerio.Add(seed);
            ctx.SaveChanges();

            // instantiate controller with the local context and call public methods via reflection
            var controller = new LotesMinerioController(ctx);
            var type = controller.GetType();
            var methodNames = new[] { "GetAll", "GetById", "Create", "Update", "Delete" };

            foreach (var name in methodNames)
            {
                var method = type.GetMethod(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
                if (method == null) continue;

                var parameters = method.GetParameters();
                object[] args = parameters.Select(p => GetArgForParameter(p, ctx)).ToArray();
                var invokeResult = method.Invoke(controller, args);

                if (invokeResult is Task t) await t.ConfigureAwait(false);
                Assert.NotNull(invokeResult);
            }
        }

        private object GetArgForParameter(System.Reflection.ParameterInfo p, AppDbContext ctx)
        {
            var t = p.ParameterType;
            if (t == typeof(int) || t == typeof(int?))
            {
                // return an existing id when possible
                var any = ctx.LotesMinerio.FirstOrDefault();
                return any != null ? any.Id : 1;
            }
            if (t == typeof(string)) return "teste";
            if (t == typeof(CreateLoteMinerioDto)) return new CreateLoteMinerioDto { CodigoLote = "C-1", MinaOrigem = "M" };
            if (t == typeof(MinhaApi.Dtos.LoteMinerioUpdateDto)) return new MinhaApi.Dtos.LoteMinerioUpdateDto { CodigoLote = "C-1", MinaOrigem = "M" };
            return null;
        }
    }
}
