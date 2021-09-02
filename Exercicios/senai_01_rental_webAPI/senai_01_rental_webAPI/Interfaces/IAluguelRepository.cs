using senai_01_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> Listar();

        AluguelDomain BuscarPorId(int idAluguel);

        void Cadastrar(AluguelDomain novoAluguel);

        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        void Deletar(int idAluguel);
    }
}
