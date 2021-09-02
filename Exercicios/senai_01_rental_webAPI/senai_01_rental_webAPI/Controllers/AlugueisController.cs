using Microsoft.AspNetCore.Mvc;
using senai_01_rental_webAPI.Domains;
using senai_01_rental_webAPI.Interfaces;
using senai_01_rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.Listar();

            return Ok(listaAlugueis);
        }

        [HttpGet("{idAluguel}")]
        public IActionResult GetById(int idAluguel)
        {
            AluguelDomain aluguelProcurado = _AluguelRepository.BuscarPorId(idAluguel);

            if (aluguelProcurado == null)
            {
                return NotFound("Nenhum gênero foi encontrado");
            }

            return Ok(aluguelProcurado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        [HttpPut("{idAluguel}")]
        public IActionResult Put(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelProcurado = _AluguelRepository.BuscarPorId(idAluguel);

            if (aluguelProcurado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum aluguel foi encontrado",
                    erro = true
                });
            }

            try
            {
                _AluguelRepository.AtualizarIdUrl(idAluguel, aluguelAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idAluguel}")]
        public IActionResult Delete(int idAluguel)
        {
            _AluguelRepository.Deletar(idAluguel);

            return StatusCode(204);
        }
    }
}
