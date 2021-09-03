using Microsoft.AspNetCore.Http;
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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaGeneros = _ClienteRepository.Listar();

            return Ok(listaGeneros);
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(int idCliente)
        {
            ClienteDomain clienteProcurado = _ClienteRepository.BuscarPorId(idCliente);

            if (clienteProcurado == null)
            {
                return NotFound("Nenhum cliente foi encontrado");
            }

            return Ok(clienteProcurado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpPut("{idCliente}")]
        public IActionResult Put(int idCliente, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteProcurado = _ClienteRepository.BuscarPorId(idCliente);

            if (clienteProcurado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum cliente foi encontrado",
                    erro = true
                });
            }

            try
            {
                _ClienteRepository.AtualizarIdUrl(idCliente, clienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(int idCliente)
        {
            _ClienteRepository.Deletar(idCliente);

            return StatusCode(204);
        }
    }
}