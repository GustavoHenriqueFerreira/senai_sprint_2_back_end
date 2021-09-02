using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) gênero
    /// </summary>
    public class Genero_Domain
    {
        public int idGenero { get; set; }
        public string nomeGenero { get; set; }
    }
}
