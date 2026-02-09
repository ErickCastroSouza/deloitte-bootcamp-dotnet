
using System;
using Xunit;
using MinhaApi.Models;

namespace MinhaApi.Tests.Models
{
	public class LoteMinerioTests
	{
		[Fact]
		public void PodeCriarELerPropriedades()
		{
			var data = new DateTime(2025, 1, 1);
			var lote = new LoteMinerio
			{
				CodigoLote = "L001",
				MinaOrigem = "Mina A",
				LocalizacaoAtual = "Porto",
				TeorFe = 62.5m,
				Umidade = 2.1m,
				SiO2 = null,
				P = 0.01m,
				Toneladas = 1000m,
				DataProducao = data
			};

			Assert.Equal("L001", lote.CodigoLote);
			Assert.Equal("Mina A", lote.MinaOrigem);
			Assert.Equal("Porto", lote.LocalizacaoAtual);
			Assert.Equal(62.5m, lote.TeorFe);
			Assert.Equal(2.1m, lote.Umidade);
			Assert.Null(lote.SiO2);
			Assert.Equal(0.01m, lote.P);
			Assert.Equal(1000m, lote.Toneladas);
			Assert.Equal(data, lote.DataProducao);
			Assert.Equal(StatusLote.EmEstoque, lote.Status);
		}

		[Fact]
		public void CamposNulosAceitosParaSiO2eP()
		{
			var lote = new LoteMinerio
			{
				CodigoLote = "L002",
				MinaOrigem = "Mina B",
				LocalizacaoAtual = "Pátio",
				TeorFe = 58.0m,
				Umidade = 1.5m,
				SiO2 = null,
				P = null,
				Toneladas = 500m,
				DataProducao = DateTime.UtcNow
			};

			Assert.Null(lote.SiO2);
			Assert.Null(lote.P);
		}

		[Fact]
		public void ValoresDoEnumStatusEstaoCorretos()
		{
			Assert.Equal(0, (int)StatusLote.EmEstoque);
			Assert.Equal(1, (int)StatusLote.EmTransporte);
			Assert.Equal(2, (int)StatusLote.Embarcado);
		}
	}
}
