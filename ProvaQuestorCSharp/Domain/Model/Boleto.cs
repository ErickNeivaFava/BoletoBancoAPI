using ProvaQuestorCSharp.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaQuestorCSharp.Domain.Model
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NomePagador { get; set; }
        [StringLength(14)]
        public string CpfPagador { get; set; }
        [StringLength(18)]
        public string CnpjPagador { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeBeneficiario { get; set; }
        [StringLength(14)]
        public string CpfBeneficiario { get; set; }
        [StringLength(18)]
        public string CnpjBeneficiario { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        [StringLength(255)]
        public string? Observacao { get; set; }
        [Required]
        [ForeignKey("Banco")]
        public int BancoId { get; set; }

        public Boleto() { }
        public Boleto(string NomePagador, string CpfPagador, string CnpjPagador, string NomeBeneficiario, string CpfBeneficiario, string CnpjBeneficiario, decimal Valor, DateTime DataVencimento, string Observacao, int BancoId)
        {
            this.NomePagador = NomePagador ?? throw new ArgumentNullException(nameof(NomePagador)); ;
            this.CpfPagador = CpfPagador ?? throw new ArgumentNullException(nameof(CpfPagador)); ;
            this.CnpjPagador = CnpjPagador ?? throw new ArgumentNullException(nameof(CnpjPagador)); ;
            this.NomeBeneficiario = NomeBeneficiario ?? throw new ArgumentNullException(nameof(NomeBeneficiario)); ;
            this.CpfBeneficiario = CpfBeneficiario ?? throw new ArgumentNullException(nameof(CpfBeneficiario)); ;
            this.CnpjBeneficiario = CnpjBeneficiario ?? throw new ArgumentNullException(nameof(CnpjBeneficiario)); ;
            this.Valor = Valor;
            this.DataVencimento = DataVencimento;
            this.Observacao = Observacao;
            this.BancoId = BancoId;
        }
    }
}
