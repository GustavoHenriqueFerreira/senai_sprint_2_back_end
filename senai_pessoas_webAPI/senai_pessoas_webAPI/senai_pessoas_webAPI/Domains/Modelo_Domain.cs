using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Domains
{
    public class Modelo_Domain
    {
        public int idModelo { get; set; }
        public string NomeModelo { get; set; }
        public DateTime AnoModelo { get; set; }
        public int TamanhoModelo { get; set; }
        public Marca_Domain marca { get; set; }
    }
}
