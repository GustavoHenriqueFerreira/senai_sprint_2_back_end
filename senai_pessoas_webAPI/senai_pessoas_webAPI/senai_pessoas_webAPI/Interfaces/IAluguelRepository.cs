using senai_pessoas_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    interface IAluguelRepository
    {
        List<Aluguel_Domain> Listar();

        Aluguel_Domain BuscarPorId(int idAluguel);

        void Cadastrar(Aluguel_Domain novoAluguel);

        void AtualizarIdUrl(int idAluguel, Aluguel_Domain aluguel);

        void Deletar(int idAluguel);
    }
}
