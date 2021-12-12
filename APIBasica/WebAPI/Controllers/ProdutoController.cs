using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IServicosProduto _servicosProduto;

        public ProdutoController(ILogger<ProdutoController> logger, IServicosProduto servicosProduto)
        {
            _logger = logger;
            _servicosProduto = servicosProduto;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var resultado = await _servicosProduto.Criar(produtoDto);
                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aconteceu um erro inesperado ao criar um produto.");
                return BadRequest("Desculpe! Aconteceu um erro inesperado em nosso sistema, aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var resultado = await _servicosProduto.BuscarTodos();
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Entidade);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aconteceu um erro inesperado ao listar os produtos.");
                return BadRequest("Desculpe! Aconteceu um erro inesperado em nosso sistema, aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId([FromRoute] int id)
        {
            try
            {
                var resultado = await _servicosProduto.BuscarPorId(id);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Entidade);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aconteceu um erro inesperado ao buscar o produto.");
                return BadRequest("Desculpe! Aconteceu um erro inesperado em nosso sistema, aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var resultado = await _servicosProduto.Atualizar(produtoDto);
                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aconteceu um erro inesperado ao atualizar o produto.");
                return BadRequest("Desculpe! Aconteceu um erro inesperado em nosso sistema, aguarde alguns minutos e tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var resultado = await _servicosProduto.Deletar(id);
                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest(resultado);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aconteceu um erro inesperado ao deletar o produto.");
                return BadRequest("Desculpe! Aconteceu um erro inesperado em nosso sistema, aguarde alguns minutos e tente novamente.");
            }
        }
    }
}
