using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Domains
{
    public class Aluguel_Domain
    {
        public int idAluguel { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public Veiculo_Domain veiculo { get; set; }
        public Cliente_Domain cliente { get; set; }
    }
}
