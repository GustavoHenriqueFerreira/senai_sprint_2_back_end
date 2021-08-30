using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepositorycs
    {
        List<Filme_Domain> Listar();

        Filme_Domain BuscarPorId(int idFilme);

        void Cadastrar(Filme_Domain novoFilme);

        void AtualizarIdUrl(int idFilme, Filme_Domain filme);

        void Deletar(int idFilme);
    }
}
