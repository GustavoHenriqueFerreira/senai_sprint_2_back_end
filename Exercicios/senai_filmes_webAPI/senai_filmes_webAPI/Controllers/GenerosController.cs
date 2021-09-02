using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    //Define a resposta em json
    [Produces("application/json")]

    //ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; }

        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Genero_Domain> listaGeneros = _GeneroRepository.ListarTodos();

            return Ok(listaGeneros);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Genero_Domain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero foi encontrado");
            }

            return Ok(generoBuscado);
        }

        [HttpPost]
        public IActionResult Post(Genero_Domain novoGenero)
        {
            _GeneroRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Genero_Domain generoAtualizado)
        {
            Genero_Domain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                (new
                {
                mensagem = "Nenhum gênero foi encontrado",
                erro = true
                });
            }

            try
            {
                _GeneroRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutBody(Genero_Domain generoAtualizado)
        {
            Genero_Domain generoBuscado = _GeneroRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(generoAtualizado);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            return NotFound
                (new
                {
                    mensagem = "Nenhum gênero foi encontrado",
                    erro = true
                });
        }
        //ex: http://localhost:5000/api/generos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _GeneroRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
