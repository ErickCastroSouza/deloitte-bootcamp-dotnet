using System;
using Xunit;
using MinhaApi.Dtos;

namespace MinhaApi.Tests.Dtos
{
    public class LoteMinerioResponseDtoTests
    {
        [Fact]
        public void PodeCriarELerPropriedades()
        {
            var data = new DateTime(2025, 1, 1);
            var dto = new LoteMinerioResponseDto(
                1,
                "L001",
                "Mina A",
                "Porto",
                62.5m,
                2.1m,
                null,
                0.01m,
                1000m,
                data,
                (MinhaApi.Models.StatusLote)0
            );

            Assert.Equal(1, dto.Id);
            Assert.Equal("L001", dto.CodigoLote);
            Assert.Equal("Mina A", dto.MinaOrigem);
            Assert.Equal("Porto", dto.LocalizacaoAtual);
            Assert.Equal(62.5m, dto.TeorFe);
            Assert.Equal(2.1m, dto.Umidade);
            Assert.Null(dto.SiO2);
            Assert.Equal(0.01m, dto.P);
            Assert.Equal(1000m, dto.Toneladas);
            Assert.Equal(data, dto.DataProducao);
            Assert.Equal((MinhaApi.Models.StatusLote)0, dto.Status);
        }
    }
}