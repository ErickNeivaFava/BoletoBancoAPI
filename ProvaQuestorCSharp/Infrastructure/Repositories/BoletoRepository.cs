using Microsoft.EntityFrameworkCore;
using ProvaQuestorCSharp.Domain.DTOs;
using ProvaQuestorCSharp.Domain.Model;
using System;
using System.Drawing;

namespace ProvaQuestorCSharp.Infrastructure.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public BoletoRepository(ConnectionContext connectionContext)
        {
            _context = connectionContext;
        }
        public async Task<Boleto> BuscarPorId(int id)
        {
            var boleto = await _context.Boleto
                .FirstOrDefaultAsync(x => x.Id == id);
            var banco = await _context.Banco
                .FirstOrDefaultAsync(x => x.Id == boleto.BancoId);
            if (DateTime.Now > boleto.DataVencimento)
            {
                boleto.Valor = boleto.Valor + (boleto.Valor * (banco.PercentualJuros/100));
            }
            return boleto;
        }

        public async Task<List<BoletoDTO>> BuscarTodosBoletos()
        {
            return await _context.Boleto
                .Select(b =>
                new BoletoDTO()
                {
                    NomePagador = b.NomePagador,
                    CpfPagador = b.CpfPagador,
                    CnpjPagador = b.CnpjPagador,
                    NomeBeneficiario = b.NomeBeneficiario,
                    CpfBeneficiario = b.CpfBeneficiario,
                    CnpjBeneficiario = b.CnpjBeneficiario,
                    Valor = b.Valor,
                    DataVencimento = b.DataVencimento,
                    Observacao = b.Observacao,
                    BancoId = b.BancoId
                }).ToListAsync();
        }
        public async Task<Boleto> Adicionar(Boleto boleto)
        {
            if(boleto.CpfBeneficiario == null && boleto.CnpjBeneficiario == null)
            {
                throw new Exception("É necessário possuir pelo menos um CPF ou CNPJ.");
            }
            await _context.Boleto.AddAsync(boleto);
            await _context.SaveChangesAsync();
            return boleto;
        }

        public async Task<Boleto> Atualizar(Boleto boleto, int id)
        {
            Boleto boletoPorId = await BuscarPorId(id);

            if (boletoPorId == null)
            {
                throw new Exception($"Boleto para o ID: {id} não foi encontrado no banco de dados.");
            }


            boletoPorId.NomePagador = boleto.NomePagador;
            boletoPorId.CpfPagador = boleto.CpfPagador;
            boletoPorId.CnpjPagador = boleto.CnpjPagador;
            boletoPorId.NomeBeneficiario = boleto.NomeBeneficiario;
            boletoPorId.CpfBeneficiario = boleto.CpfBeneficiario;
            boletoPorId.CnpjBeneficiario = boleto.CnpjBeneficiario;
            boletoPorId.Valor = boleto.Valor;
            boletoPorId.DataVencimento = boleto.DataVencimento;
            boletoPorId.Observacao = boleto.Observacao;
            boleto.BancoId = boleto.BancoId;


            _context.Boleto.Update(boletoPorId);
            await _context.SaveChangesAsync();

            return boletoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Boleto boletoPorId = await BuscarPorId(id);

            if (boletoPorId == null)
            {
                throw new Exception($"Boleto para o ID: {id} não foi encontrado no boleto de dados.");
            }

            _context.Boleto.Remove(boletoPorId);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
