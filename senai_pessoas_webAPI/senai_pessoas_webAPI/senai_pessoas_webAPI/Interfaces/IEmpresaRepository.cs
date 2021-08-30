using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    interface IEmpresaRepository
    {
        List<Filme_Domain> Listar();

        Filme_Domain BuscarPorId(int idFilme);

        void Cadastrar(Filme_Domain novoFilme);

        void AtualizarIdUrl(int idFilme, Filme_Domain filme);

        void Deletar(int idFilme);
    }
}
