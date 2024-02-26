using System.ComponentModel.DataAnnotations;

namespace ProvaQuestorCSharp.Application.ViewModel
{
    public class BancoViewModel
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}
