using System;
using Xunit;
using MinhaApi.Dtos;

namespace MinhaApi.Tests.Dtos
{
    public class LoteMinerioUpdateDtoTests
    {
        [Fact]
        public void PodeCriarELerPropriedades()
        {
            var data = new DateTime(2025, 1, 1);
            var dto = new LoteMinerioUpdateDto
            {
                CodigoLote = "L001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Porto",
                TeorFe = 62.5m,
                Umidade = 2.1m,
                SiO2 = null,
                P = 0.01m,
                Toneladas = 1000m,
                DataProducao = data,
                Status = 0
            };

            Assert.Equal("L001", dto.CodigoLote);
            Assert.Equal("Mina A", dto.MinaOrigem);
            Assert.Equal("Porto", dto.LocalizacaoAtual);
            Assert.Equal(62.5m, dto.TeorFe);
            Assert.Equal(2.1m, dto.Umidade);
            Assert.Null(dto.SiO2);
            Assert.Equal(0.01m, dto.P);
            Assert.Equal(1000m, dto.Toneladas);
            Assert.Equal(data, dto.DataProducao);
            Assert.Equal(0, dto.Status);
        }
    }
}