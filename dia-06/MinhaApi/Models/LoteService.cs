using MinhaApi.Models;

namespace MinhaApi.Services
{
    public class LoteService
    {
        public string ClassificarQualidade(LoteMinerio lote)
        {
            if (lote.TeorFe >= 65 && lote.Umidade <= 7 && lote.SiO2 <= 3)
            {
                return "Premium";
            }
            else if (lote.TeorFe >= 60 && lote.Umidade <= 10 && lote.SiO2 <= 5)
            {
                return "Padrão";
            }
            else
            {
                return "Baixa Qualidade";
            }
        }

        public decimal CalcularPrecoPorTonelada(LoteMinerio lote)
        {
            var qualidade = ClassificarQualidade(lote);

            return qualidade switch
            {
                "Premium" => 180.50m,
                "Padrão" => 150.20m,
                "Baixa Qualidade" => 79.40m,
                _ => 0m
            };
        }

        public decimal CalcularValorTotal(LoteMinerio lote)
        {
            var preco = CalcularPrecoPorTonelada(lote);
            return preco * lote.Toneladas;
        }

        public void RegistrarMovimentacao(LoteMinerio lote, string local, StatusLote novoStatus)
        {
            lote.Historico.Add(new HistoricoMovimentacao
            {
                Local = local,
                Status = novoStatus,
                Data = DateTime.UtcNow
            });

            lote.LocalizacaoAtual = local;
            lote.Status = novoStatus;
        }

        public void AvancarStatus(LoteMinerio lote)
        {
            var novoStatus = lote.Status switch
            {
                StatusLote.EmEstoque     => StatusLote.EmTransporte,
                StatusLote.EmTransporte  => StatusLote.Embarcado,
                StatusLote.Embarcado     => throw new InvalidOperationException("Lote já está embarcado."),
                _                        => throw new ArgumentOutOfRangeException(nameof(lote.Status))
            };

            RegistrarMovimentacao(
                lote,
                lote.LocalizacaoAtual,
                novoStatus
            );
        }

        public decimal CalcularPenalidadeUmidade(LoteMinerio lote)
        {
            if (lote.Umidade <= 8)
            {
                return 0m;
            }
            var excessoUmidade = lote.Umidade - 8;
            return excessoUmidade * 1.50m;
        }
    }
}

