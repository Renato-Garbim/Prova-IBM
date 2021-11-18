using IBMEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMServices.MockDB
{
    public class MockListasDB
    {
        public IEnumerable<DescontoINSS> ObterListaParamestrosInss()
        {

            var lista = new List<DescontoINSS>();

            lista.Add(new DescontoINSS(2011, (decimal)1106.9, (decimal)0.08, 0, false));
            lista.Add(new DescontoINSS(2011, (decimal)1844.83, (decimal)0.09, 0, false));
            lista.Add(new DescontoINSS(2011, (decimal)3689.66, (decimal)0.11, 0, false));
            lista.Add(new DescontoINSS(2011, 0, 0, (decimal)405.86, true));

            lista.Add(new DescontoINSS(2012, 1000, (decimal)0.07, 0, false));
            lista.Add(new DescontoINSS(2012, 1500, (decimal)0.08, 0, false));
            lista.Add(new DescontoINSS(2012, 3000, (decimal)0.09, 0, false));
            lista.Add(new DescontoINSS(2012, 4000, (decimal)0.11, 0, false));
            lista.Add(new DescontoINSS(2012, 0, 0, 500, true));

            return lista;
        }
    }
}
