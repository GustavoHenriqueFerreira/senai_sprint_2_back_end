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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _VeiculoRepository.Listar();

            return Ok(listaVeiculos);
        }

        [HttpGet("{idVeiculo}")]
        public IActionResult GetById(int idVeiculo)
        {
            VeiculoDomain veiculoProcurado = _VeiculoRepository.BuscarPorId(idVeiculo);

            if (veiculoProcurado == null)
            {
                return NotFound("Nenhum veículo foi encontrado");
            }

            return Ok(veiculoProcurado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{idVeiculo}")]
        public IActionResult Put(int idVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            VeiculoDomain veiculoProcurado = _VeiculoRepository.BuscarPorId(idVeiculo);

            if (veiculoProcurado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum veículo foi encontrado",
                    erro = true
                });
            }

            try
            {
                _VeiculoRepository.AtualizarIdUrl(idVeiculo, VeiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idVeiculo}")]
        public IActionResult Delete(int idVeiculo)
        {
            _VeiculoRepository.Deletar(idVeiculo);

            return StatusCode(204);
        }
    }
}
