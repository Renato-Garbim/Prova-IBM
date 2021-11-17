using IBMEntities;
using System;
using System.Linq;

namespace IBMServices
{
    public class CalculadorInssService : ICalculadorInss
    {
        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var dadoINSS = ObterAliquotaParaSalarioAno(data , salario);

            return dadoINSS.Teto ? dadoINSS.ValorBruto : dadoINSS.Aliquota * salario;
        }

        private DescontoINSS ObterAliquotaParaSalarioAno(DateTime data, decimal salario)
        {
            var mock = new MockDB.MockListasDB();
            var listaINSS = mock.ObterListaParamestrosInss().ToList();

            var valoresAno = listaINSS.Where(x => x.Ano == data.Year);

            if (listaINSS.Count() == 0) return new DescontoINSS();

            var listaSalarios = valoresAno.Select(x => x.Contribuicao).ToList().OrderBy(x => x);

            foreach(var valor in listaSalarios)
            {
                if(salario < valor)
                {
                    return valoresAno.FirstOrDefault(x => x.Contribuicao == valor);
                }
                 
            }

            // Se chegou até aqui pela lógica implimentada no código, significa que o valor é maior do que o tabelado nas contribuições, logo esta no teto.

            return valoresAno.FirstOrDefault(x => x.Teto);            
        }
    }
}
