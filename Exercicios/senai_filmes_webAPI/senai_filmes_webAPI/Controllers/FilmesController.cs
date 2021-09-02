using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
        //Define a resposta em json
        [Produces("application/json")]

        //ex: http://localhost:5000/api/filmes
        [Route("api/[controller]")]
        [ApiController]
    public class FilmesController : ControllerBase
    {
            private FilmeRepository _FilmeRepository { get; set; }

            public FilmesController()
            {
            _FilmeRepository = new FilmeRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                List<Filme_Domain> listaFilmes = _FilmeRepository.Listar();

                return Ok(listaFilmes);
            }

            [HttpGet]
            public IActionResult GetById(int id)
            {
            Filme_Domain FilmeBuscado = _FilmeRepository.BuscarPorId(id);

                if (FilmeBuscado == null)
                {
                    return NotFound("Nenhum filme foi encontrado");
                }

                return Ok(FilmeBuscado);
            }

            [HttpPost]
            public IActionResult Post(Filme_Domain novoFilme)
            {
            _FilmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Filme_Domain FilmeAtualizado)
            {
            Filme_Domain FilmeBuscado = _FilmeRepository.BuscarPorId(id);

                if (FilmeBuscado == null)
                {
                    return NotFound
                    (new
                    {
                        mensagem = "Nenhum filme foi encontrado",
                        erro = true
                    });
                }

                try
                {
                _FilmeRepository.AtualizarIdUrl(id, FilmeAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            [HttpPut("{id}")]
            public IActionResult PutBody(Filme_Domain FilmeAtualizado)
            {
            Filme_Domain FilmeBuscado = _FilmeRepository.BuscarPorId(FilmeAtualizado.idFilme);

                if (FilmeBuscado != null)
                {
                    try
                    {
                    _FilmeRepository.AtualizarIdCorpo(FilmeAtualizado);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }
                return NotFound
                    (new
                    {
                        mensagem = "Nenhum filme foi encontrado",
                        erro = true
                    });
            }
        //ex: http://localhost:5000/api/filmes/5
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
            _FilmeRepository.Deletar(id);

                return StatusCode(204);
            }
        }
    }
      