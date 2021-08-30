using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Domains
{
    public class Veiculo_Domain
    {
        public int idVeiculo { get; set; }
        public int Placa { get; set; }
        public Empresa_Domain empresa { get; set; }
        public Modelo_Domain modelo { get; set; }
    }
}
