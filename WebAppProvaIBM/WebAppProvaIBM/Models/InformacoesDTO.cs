using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProvaIBM.Models
{
    public class InformacoesDTO
    {

        [DisplayName("Ano")]
        public int Ano { get; set; }

        [DisplayName("Salário")]
        public decimal Salario { get; set; }
    }
}
