using System.ComponentModel.DataAnnotations;

namespace ProvaQuestorCSharp.Domain.DTOs
{
    public class BancoDTO
    {
        public string? Nome { get; set; }
        public int Codigo { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}
