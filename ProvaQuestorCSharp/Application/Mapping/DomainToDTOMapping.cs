using AutoMapper;
using ProvaQuestorCSharp.Domain.DTOs;
using ProvaQuestorCSharp.Domain.Model;

namespace ProvaQuestorCSharp.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Banco, BancoDTO>();            
            CreateMap<Boleto, BoletoDTO>();
        }
    }
}
