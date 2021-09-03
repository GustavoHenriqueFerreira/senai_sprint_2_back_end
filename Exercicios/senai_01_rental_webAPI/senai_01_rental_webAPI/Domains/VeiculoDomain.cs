using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }

        public int idModelo { get; set; }

        public int idEmpresa { get; set; }

        [StringLength(7, MinimumLength = 7)]
        public string placa { get; set; }


        public ModeloDomain modelo { get; set; }

        public EmpresaDomain empresa { get; set; }
    }
}
