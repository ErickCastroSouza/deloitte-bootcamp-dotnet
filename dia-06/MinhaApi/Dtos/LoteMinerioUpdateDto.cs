using MinhaApi.Models;

namespace MinhaApi.Dtos
{
    public class LoteMinerioUpdateDto
    {
        public string LocalizacaoAtual { get; set; } = "";
        public int Status { get; set; }             // 0=EmEstoque, 1=EmTransporte, 2=Embarcado
        public decimal? TeorFe { get; set; }
        public decimal? Umidade { get; set; }
        public decimal? SiO2 { get; set; }
        public decimal? P { get; set; }
        public decimal? Toneladas { get; set; }
        public DateTime? DataProducao { get; set; }
        public string? MinaOrigem { get; set; }
        public string? CodigoLote { get; set; }
    }
}