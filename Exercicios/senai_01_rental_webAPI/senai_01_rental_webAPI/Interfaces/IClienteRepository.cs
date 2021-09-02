using senai_01_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Interfaces
{
    interface IClienteRepository
    {
        List<ClienteDomain> Listar();

        ClienteDomain BuscarPorId(int idCliente);

        void Cadastrar(ClienteDomain novoCliente);

        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);

        void Deletar(int idCliente);
    }
}
