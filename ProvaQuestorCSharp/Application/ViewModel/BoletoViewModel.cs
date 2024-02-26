using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProvaQuestorCSharp.Application.ViewModel
{
    public class BoletoViewModel
    {
        public string NomePagador { get; set; }
        public string CpfPagador { get; set; }
        public string CnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfBeneficiario { get; set; }
        public string CnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
    }
}
