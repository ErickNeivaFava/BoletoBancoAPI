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
    [Route("api/banco")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BancoController(IBancoRepository bancoRepository, IMapper mapper)
        {
            _bancoRepository = bancoRepository ?? throw new ArgumentNullException(nameof(bancoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<BancoDTO>>> BuscarTodosBancos()
        {
            var bancos = await _bancoRepository.BuscarTodosBancos();
            return Ok(bancos);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("BancoId/{id}")]
        public async Task<ActionResult<Banco>> BuscarPorId(int id)
        {
            var banco = await _bancoRepository.BuscarPorId(id);
            var bancoDTO = _mapper.Map<BancoDTO>(banco);
            return Ok(bancoDTO);
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("BancoCodigo/{codigo}")]
        public async Task<ActionResult<Banco>> BuscarPorCodigo(int codigo)
        {
            var banco = await _bancoRepository.BuscarPorCodigo(codigo);
            var bancoDTO = _mapper.Map<BancoDTO>(banco);
            return Ok(bancoDTO);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<Banco>> Adicionar(BancoViewModel bancoView)
        {
            var banco = new Banco(bancoView.Nome, bancoView.Codigo, bancoView.PercentualJuros);   
            await _bancoRepository.Adicionar(banco);
            return Ok(banco);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Banco>> Atualizar(BancoViewModel bancoView, int id)
        {
            var banco = new Banco(bancoView.Nome, bancoView.Codigo, bancoView.PercentualJuros);
            await _bancoRepository.Atualizar(banco, id);
            return Ok(banco);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _bancoRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
