using Microsoft.EntityFrameworkCore;
using ProvaQuestorCSharp.Domain.DTOs;
using ProvaQuestorCSharp.Domain.Model;

namespace ProvaQuestorCSharp.Infrastructure.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public BancoRepository(ConnectionContext connectionContext)
        {
            _context = connectionContext;
        }
        public async Task<Banco> BuscarPorId(int id)
        {
            return await _context.Banco
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Banco> BuscarPorCodigo(int codigo)
        {
            return await _context.Banco
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<List<BancoDTO>> BuscarTodosBancos()
        {
            return await _context.Banco
                .Select(b =>
                new BancoDTO()
                {
                    Nome = b.Nome,
                    Codigo = b.Codigo,
                    PercentualJuros = b.PercentualJuros
                }).ToListAsync();
        }
        public async Task<Banco> Adicionar(Banco banco)
        {
            await _context.Banco.AddAsync(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> Atualizar(Banco banco, int id)
        {
            Banco bancoPorId = await BuscarPorId(id);

            if (bancoPorId == null)
            {
                throw new Exception($"Banco para o ID: {id} não foi encontrado no banco de dados.");
            }

            bancoPorId.Nome = banco.Nome;
            bancoPorId.Codigo = banco.Codigo;
            bancoPorId.PercentualJuros = banco.PercentualJuros;

            _context.Banco.Update(bancoPorId);
            await _context.SaveChangesAsync();

            return bancoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Banco bancoPorId = await BuscarPorId(id);

            if (bancoPorId == null)
            {
                throw new Exception($"Banco para o ID: {id} não foi encontrado no banco de dados.");
            }

            _context.Banco.Remove(bancoPorId);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
