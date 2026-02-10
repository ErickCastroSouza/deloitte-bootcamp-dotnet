using System;
using System.Text.Json;
using Xunit;
using MinhaApi.Dtos;

namespace MinhaApi.Tests.Dtos
{
    public class DtoSerializationTests
    {
        [Fact]
        public void CreateLoteMinerioDto_SerializationRoundtrip()
        {
            var dto = new CreateLoteMinerioDto
            {
                CodigoLote = "L001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Porto",
                TeorFe = 62.5m,
                Umidade = 2.1m,
                SiO2 = null,
                P = 0.01m,
                Toneladas = 1000m,
                DataProducao = new DateTime(2025,1,1)
            };

            var json = JsonSerializer.Serialize(dto);
            var des = JsonSerializer.Deserialize<CreateLoteMinerioDto>(json);

            Assert.NotNull(des);
            Assert.Equal(dto.CodigoLote, des.CodigoLote);
            Assert.Equal(dto.MinaOrigem, des.MinaOrigem);
            Assert.Equal(dto.TeorFe, des.TeorFe);
        }

        [Fact]
        public void LoteMinerioUpdateDto_SerializationRoundtrip()
        {
            var dto = new LoteMinerioUpdateDto
            {
                CodigoLote = "L002",
                MinaOrigem = "Mina B",
                LocalizacaoAtual = "Pátio",
                TeorFe = 58.0m,
                Umidade = 1.5m,
                SiO2 = 3.2m,
                P = 0.005m,
                Toneladas = 500m,
                DataProducao = DateTime.UtcNow,
                Status = 1
            };

            var json = JsonSerializer.Serialize(dto);
            var des = JsonSerializer.Deserialize<LoteMinerioUpdateDto>(json);

            Assert.NotNull(des);
            Assert.Equal(dto.CodigoLote, des.CodigoLote);
            Assert.Equal(dto.Status, des.Status);
        }

        [Fact]
        public void LoteMinerioResponseDto_SerializationRoundtrip()
        {
            var dto = new LoteMinerioResponseDto(
                1,
                "L003",
                "Mina C",
                "Terminal",
                61.0m,
                1.9m,
                2.0m,
                0.02m,
                750m,
                new DateTime(2025,2,2),
                (MinhaApi.Models.StatusLote)2
            );

            var json = JsonSerializer.Serialize(dto);
            var des = JsonSerializer.Deserialize<LoteMinerioResponseDto>(json);

            Assert.NotNull(des);
            Assert.Equal(dto.Id, des.Id);
            Assert.Equal(dto.CodigoLote, des.CodigoLote);
        }
    }
}
