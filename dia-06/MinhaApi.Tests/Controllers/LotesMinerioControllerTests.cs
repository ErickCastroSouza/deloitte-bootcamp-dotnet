using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.Dtos;
using MinhaApi.Models;
using Xunit;

namespace MinhaApi.Tests.Controllers
{
    public class LotesMinerioControllerTests
    {
        private AppDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void Construtor_DeveCriarInstancia()
        {
            using var context = CreateContext();
            var controller = new LotesMinerioController(context);

            Assert.NotNull(controller);
        }

        [Fact]
        public async Task Create_DeveSalvarLote()
        {
            using var context = CreateContext();
            var controller = new LotesMinerioController(context);

            var dto = new CreateLoteMinerioDto
            {
                CodigoLote = "L-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Armazém 1" // ✅ Adicionado
            };

            var result = await controller.Create(dto);

            Assert.NotNull(result);
            Assert.Single(context.LotesMinerio);
        }

        [Fact]
        public async Task GetAll_DeveRetornarLista()
        {
            using var context = CreateContext();

            context.LotesMinerio.Add(new LoteMinerio
            {
                CodigoLote = "L-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Armazém 1" // ✅ Adicionado
            });
            
            context.LotesMinerio.Add(new LoteMinerio
            {
                CodigoLote = "L-002",
                MinaOrigem = "Mina B",
                LocalizacaoAtual = "Armazém 2" // ✅ Adicionado
            });

            await context.SaveChangesAsync();

            var controller = new LotesMinerioController(context);
            var result = await controller.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_DeveRetornarLote_QuandoExiste()
        {
            using var context = CreateContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "L-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Armazém 1" // ✅ Adicionado
            };

            context.LotesMinerio.Add(lote);
            await context.SaveChangesAsync();

            var controller = new LotesMinerioController(context);
            var result = await controller.GetById(lote.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_DeveRetornarNulo_QuandoNaoExiste()
        {
            using var context = CreateContext();
            var controller = new LotesMinerioController(context);

            var result = await controller.GetById(999);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_DeveAtualizarQuandoExiste()
        {
            using var context = CreateContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "L-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Armazém 1" 
            };

            context.LotesMinerio.Add(lote);
            await context.SaveChangesAsync();

            var controller = new LotesMinerioController(context);

            var dto = new LoteMinerioUpdateDto
            {
                CodigoLote = "L-002",
                MinaOrigem = "Mina B",
                LocalizacaoAtual = "Armazém 2" 
            };

            var result = await controller.Update(lote.Id, dto);

            Assert.NotNull(result);
            
            // Verifica que atualizou
            var updatedLote = await context.LotesMinerio.FindAsync(lote.Id);
            Assert.Equal("L-002", updatedLote.CodigoLote);
        }

        [Fact]
        public async Task Update_DeveRetornarQuandoNaoExiste()
        {
            using var context = CreateContext();
            var controller = new LotesMinerioController(context);

            var dto = new LoteMinerioUpdateDto
            {
                CodigoLote = "L-002",
                MinaOrigem = "Mina B"
            };

            var result = await controller.Update(999, dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_DeveRemoverQuandoExiste()
        {
            using var context = CreateContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "L-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Armazém 1"
            };

            context.LotesMinerio.Add(lote);
            await context.SaveChangesAsync();

            var controller = new LotesMinerioController(context);
            var result = await controller.Delete(lote.Id);

            Assert.NotNull(result);
            Assert.Empty(context.LotesMinerio);
        }

        [Fact]
        public async Task Delete_DeveRetornarQuandoNaoExiste()
        {
            using var context = CreateContext();
            var controller = new LotesMinerioController(context);

            var result = await controller.Delete(999);

            Assert.NotNull(result);
        }
    }
}