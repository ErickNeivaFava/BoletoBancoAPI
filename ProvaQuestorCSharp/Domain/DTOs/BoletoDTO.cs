using ProvaQuestorCSharp.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaQuestorCSharp.Domain.DTOs
{
    public class BoletoDTO
    {
        public string? NomePagador { get; set; }
        public string? CpfPagador { get; set; }
        public string? CnpjPagador { get; set; }
        public string? NomeBeneficiario { get; set; }
        public string? CpfBeneficiario { get; set; }
        public string? CnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
    }
}