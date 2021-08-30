using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// classe que representa a entidade (tabela) Filme
    /// </summary>
    public class Filme_Domain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }
        public Genero_Domain genero { get; set; }
    }
}
