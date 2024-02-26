using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaQuestorCSharp.Domain.Model
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public decimal PercentualJuros { get; set; }

        public Banco() { }
        public Banco(string Nome, int Codigo, decimal PercentualJuros)
        {
            this.Nome = Nome ?? throw new ArgumentNullException(nameof(Nome));
            this.Codigo = Codigo;
            this.PercentualJuros = PercentualJuros;
        }
    }
}
