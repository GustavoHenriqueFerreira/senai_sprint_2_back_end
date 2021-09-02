using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        //Estrutura de métodos da interface
        //TipoRetorno NomeMetodo (TipoParametro, NomeParametro)


        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<Genero_Domain> ListarTodos();

        /// <summary>
        /// Busca um gênero atráves do id
        /// </summary>
        /// <param name="idGenero">id do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        Genero_Domain BuscarPorId(int idGenero);


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os dados que serão cadastrados</param>
        void Cadastrar(Genero_Domain novoGenero);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGenero"></param>
        /// <param name="genero"></param>
        void AtualizarIdCorpo(Genero_Domain generoAtualizado);
        void AtualizarIdUrl(int idGenero, Genero_Domain generoAtualizado);

        void Deletar(int idGenero);
    }
}
