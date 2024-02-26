using ProvaQuestorCSharp.Domain.DTOs;

namespace ProvaQuestorCSharp.Domain.Model
{
    public interface IBoletoRepository
    {
        Task<List<BoletoDTO>> BuscarTodosBoletos();
        Task<Boleto> BuscarPorId(int id);
        Task<Boleto> Adicionar(Boleto boleto);
        Task<Boleto> Atualizar(Boleto boleto, int id);
        Task<bool> Apagar(int id);
    }
}
