using IBMEntities;
using IBMServices;
using Moq;
using System;
using Xunit;

namespace IBMTestService
{
    public class CalculadorINSSTest
    {
    
        [InlineData(2011, 0)]
        [InlineData(0, 1000)]
        [Theory]
        public void Calculo_RetornarValorZeradoQuandoParametrosNaoPreenchidos(int ano, decimal salario)
        {
            //arrange

            var mock = new Mock<ICalculadorInss>();

            var data = new DateTime(ano);            
            var servico = mock.Object;

            //servico.CalcularDesconto();
            mock.Setup(x => x.CalcularDesconto(data, salario)).Returns(0);

            //act
            var result = servico.CalcularDesconto(data, salario);

            ////assert

            Assert.Equal(0, result);
        }

    }
}
