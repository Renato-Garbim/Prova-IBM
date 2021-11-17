using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMServices
{
    public interface ICalculadorInss
	{
		/// <summary>
		/// Deve retornar o deconto do INSS aplicado ao salário, na determinada data.
		/// </summary>
		public decimal CalcularDesconto(DateTime data, decimal salario);
    }
}
