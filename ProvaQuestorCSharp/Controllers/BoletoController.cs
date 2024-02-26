using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaQuestorCSharp.Application.ViewModel;
using ProvaQuestorCSharp.Domain.DTOs;
using ProvaQuestorCSharp.Domain.Model;

namespace ProvaQuestorCSharp.Controllers
{
    [ApiController]
    [Route("api/boleto")]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly IMapper _mapper;

        public BoletoController(IBoletoRepository boletoRepository, IMapper mapper)
        {
            _boletoRepository = boletoRepository ?? throw new ArgumentNullException(nameof(boletoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<BoletoDTO>>> BuscarTodosBoletos()
        {
            var boletos = await _boletoRepository.BuscarTodosBoletos();
            return Ok(boletos);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("BoletoId/{id}")]
        public async Task<ActionResult<Boleto>> BuscarPorId(int id)
        {
            var boleto = await _boletoRepository.BuscarPorId(id);
            var boletoDTO = _mapper.Map<BoletoDTO>(boleto);
            
            return Ok(boletoDTO);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<Boleto>> Adicionar(BoletoViewModel boletoView)
        {
            var boleto = new Boleto(boletoView.NomePagador, boletoView.CpfPagador, boletoView.CnpjPagador, boletoView.NomeBeneficiario, boletoView.CpfBeneficiario, boletoView.CnpjBeneficiario, boletoView.Valor, boletoView.DataVencimento, boletoView.Observacao, boletoView.BancoId);

            await _boletoRepository.Adicionar(boleto);

            return Ok(boleto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Boleto>> Atualizar(BoletoViewModel boletoView, int id)
        {
            var boleto = new Boleto(boletoView.NomePagador, boletoView.CpfPagador, boletoView.CnpjPagador, boletoView.NomeBeneficiario, boletoView.CpfBeneficiario, boletoView.CnpjBeneficiario, boletoView.Valor, boletoView.DataVencimento, boletoView.Observacao, boletoView.BancoId);

            await _boletoRepository.Atualizar(boleto, id);

            return Ok(boleto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _boletoRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
