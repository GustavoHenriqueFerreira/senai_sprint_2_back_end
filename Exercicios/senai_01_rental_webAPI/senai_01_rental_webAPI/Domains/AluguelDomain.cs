using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }

        public int idVeiculo { get; set; }

        public int idCliente { get; set; }

        public DateTime dataRetirada { get; set; }

        public DateTime dataDevolucao { get; set; }

        public ClienteDomain cliente { get; set; }

        public VeiculoDomain veiculo { get; set; }
    }
}
