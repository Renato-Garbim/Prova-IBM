using IBMEntities;
using System;
using System.Linq;

namespace IBMServices
{
    public class CalculadorInssService : ICalculadorInss
    {
        public decimal CalcularDesconto(DateTime data, decimal salario)                
        {
            var temData = ValidarData(data.Year);
            var temSalario = ValidarSalario(salario);

            if (!temData || !temSalario) return 0;

            var dadoINSS = ObterAliquotaParaSalarioAno(data , salario);

            return dadoINSS.Teto ? dadoINSS.ValorBruto : dadoINSS.Aliquota * salario;
        }

        // Numa Solução mais robusta os validadores se localizariam em outra parte do código, os deixei aqui nos serviços em virtude da praticidade.

        private bool ValidarData(int data)
        {
            return data != 0 ? true : false;
        }

        private bool ValidarSalario(decimal salario)
        {
            return salario != 0 ? true : false;

        }

        private DescontoINSS ObterAliquotaParaSalarioAno(DateTime data, decimal salario)
        {
            var mock = new MockDB.MockListasDB();
            var listaINSS = mock.ObterListaParamestrosInss().ToList();

            var valoresAno = listaINSS.Where(x => x.Ano == data.Year);

            if (valoresAno.Count() == 0) return new DescontoINSS(); 
            // retorna uma nova entidade vazia quando não consta um ano na lista, 
            //poderia optar pelo pattern do retornar um null no entanto me atentei a reduzir o número de Ifs na função principal.

            var listaSalarios = valoresAno.Select(x => x.Contribuicao).ToList().OrderBy(x => x);

            foreach(var valor in listaSalarios)
            {
                if(salario <= valor)
                {
                    return valoresAno.FirstOrDefault(x => x.Contribuicao == valor);
                }
                 
            }

            // Se chegou até aqui pela lógica implimentada no código, significa que o valor é maior do que o tabelado nas contribuições, logo esta no teto.

            return valoresAno.FirstOrDefault(x => x.Teto);            
        }
    }
}
