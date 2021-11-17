using System;

namespace IBMEntities
{
    public class DescontoINSS
    {
        public int Ano { get; private set; }
        public decimal Contribuicao { get; private set; }
        public decimal Aliquota { get; private set; }
        public decimal ValorBruto { get; private set; }
        public bool Teto { get; private set; }

        public DescontoINSS()
        {

        }

        public DescontoINSS(int ano, decimal contribuicao, decimal aliquota, decimal valorBruto, bool teto)
        {
            Ano = ano;
            Contribuicao = contribuicao;
            Aliquota = aliquota;
            ValorBruto = valorBruto;
            Teto = teto;
                 
        }


    }
}
