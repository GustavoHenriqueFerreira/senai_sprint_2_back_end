using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenomeCliente { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }
    }
}
