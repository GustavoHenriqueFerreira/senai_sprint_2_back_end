using senai_pessoas_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    public class IClienteRepository
    {
        List<Cliente_Domain> Listar();

        Aluguel_Domain BuscarPorId(int idCliente);

        void Cadastrar(Aluguel_Domain novoCliente);

        void AtualizarIdUrl(int idCliente, Aluguel_Domain cliente);

        void Deletar(int idCliente);
    }
}
