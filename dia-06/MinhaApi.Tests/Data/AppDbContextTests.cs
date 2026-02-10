using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Tests.Data
{
    public class AppDbContextTests
    {
        [Fact]
        public void PodeCriarInstancia()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new AppDbContext(options);
            Assert.NotNull(context);
        }

        [Fact]
        public void OnModelCreating_RegistraEntidadeLoteMinerio()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using var context = new AppDbContext(options);

            // Força a construção do model e execução de OnModelCreating
            var model = context.Model;

            var entity = model.FindEntityType(typeof(LoteMinerio));
            Assert.NotNull(entity);

            // Verifica propriedades esperadas
            Assert.NotNull(entity.FindProperty("CodigoLote"));
            Assert.NotNull(entity.FindProperty("MinaOrigem"));
            Assert.NotNull(entity.FindProperty("DataProducao"));

            // Verifica chave primária
            var pk = entity.FindPrimaryKey();
            Assert.NotNull(pk);
            Assert.Contains(pk.Properties, p => p.Name == "Id");
        }

        [Fact]
        public void AdicionarLote_SalvaERecupera()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new AppDbContext(options))
            {
                var lote = new LoteMinerio
                {
                    CodigoLote = "TEST-001",
                    MinaOrigem = "Mina Teste",
                    LocalizacaoAtual = "Pátio",
                    TeorFe = 60m,
                    Umidade = 1.2m,
                    SiO2 = 5m,
                    P = 0.02m,
                    Toneladas = 200m,
                    DataProducao = DateTime.UtcNow
                };

                context.LotesMinerio.Add(lote);
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var encontrado = context.LotesMinerio.FirstOrDefaultAsync(l => l.CodigoLote == "TEST-001").GetAwaiter().GetResult();
                Assert.NotNull(encontrado);
                Assert.Equal("TEST-001", encontrado.CodigoLote);
            }
        }
    }
}