using ProvaQuestorCSharp.Domain.DTOs;

namespace ProvaQuestorCSharp.Domain.Model
{
    public interface IBancoRepository
    {
        Task<List<BancoDTO>> BuscarTodosBancos();
        Task<Banco> BuscarPorId(int id);
        Task<Banco> BuscarPorCodigo(int codigo);
        Task<Banco> Adicionar(Banco banco);
        Task<Banco> Atualizar(Banco banco, int id);
        Task<bool> Apagar(int id);
    }
}
