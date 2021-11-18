using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProvaIBM.Models
{
    public class ResultadoDTO
    {        
        [DisplayName("Desconto")]
        public decimal Desconto { get; set; }
        public string MensagemErro { get; set; }
    }
}
