using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_pessoas_webAPI.Domains;
using senai_pessoas_webAPI.Interfaces;
using senai_pessoas_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Controllers
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
            List<Aluguel_Domain> listaAlugueis = _AluguelRepository.Listar();;

                return Ok(listaAlugueis);
            }

            [HttpPost]
            public IActionResult Post(Aluguel_Domain novoAluguel)
            {
            _AluguelRepository.Cadastrar(novoAluguel);

                return StatusCode(201);
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
            _AluguelRepository.Deletar(id);

                return StatusCode(204);
            }
        }
}
