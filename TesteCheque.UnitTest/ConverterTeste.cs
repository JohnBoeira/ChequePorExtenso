using ChequePorExtenso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteCheque.UnitTest
{
    [TestClass]
    public class ConverterTeste
    {
        [TestMethod]
        public void Converter_UnidadeCentavoZero()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();      
            //act
            string resultado = conversor.Converter(0.00);
            //assert
            Assert.AreEqual("Valor nulo", resultado);
        }
        [TestMethod]
        public void Converter_UnidadeCentavo()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act
            string resultado = conversor.Converter(0.09);
            //assert
            Assert.AreEqual("nove centavos de real", resultado);
        }
        [TestMethod]
        public void Converter_DezenaCentavo()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            ////act
            string resultado = conversor.Converter(0.10);
            ////assert
            Assert.AreEqual("dez centavos de real", resultado);
        }
        [TestMethod]
        public void Converter_UnidadeReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            ////act
            string resultado = conversor.Converter(9.19);
            string resultado2 = conversor.Converter(1.19);
            ////assert
            Assert.AreEqual("nove reais e dezenove centavos", resultado);
            Assert.AreEqual("um real e dezenove centavos", resultado2);
        }
        [TestMethod]
        public void Converter_DezenaReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            ////act
            string resultado = conversor.Converter(29.16);
           
            ////assert
            Assert.AreEqual("vinte e nove reais e dezesseis centavos", resultado);
           
        }
        [TestMethod]
        public void Converter_CentenaReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            ////act
            string resultado = conversor.Converter(129.16);
            string resultado2 = conversor.Converter(100.16);
            string resultado3 = conversor.Converter(999.16);
            ////assert
            Assert.AreEqual("cento e vinte e nove reais e dezesseis centavos", resultado);
            Assert.AreEqual("cem reais e dezesseis centavos", resultado2);
            Assert.AreEqual("novecentos e noventa e nove reais e dezesseis centavos", resultado3);
        }
        [TestMethod]
        public void Converter_uMilharReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act
            string resultado1 = conversor.Converter(1000.16);
            string resultado = conversor.Converter(1100.16);
            string resultado2 = conversor.Converter(1145.16);
          
            //assert
            Assert.AreEqual("mil reais e dezesseis centavos", resultado1);
            Assert.AreEqual("mil e cem reais e dezesseis centavos", resultado);
            Assert.AreEqual("mil cento e quarenta e cinco reais e dezesseis centavos", resultado2);
      
        }
        [TestMethod]
        public void Converter_DezenaDeMilharReal() //99.999
        {
            //arrange - organiza
            ConversorBase conversor = new ConversorBase();
            //act - ação          
            string resultado = conversor.Converter(12001.12);
            //assert
            Assert.AreEqual("doze mil e um reais e doze centavos", resultado);

        }
        [TestMethod]
        public void Converter_cMilharReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act
           
            string resultado3 = conversor.Converter(999999.16);
            string resultado4 = conversor.Converter(61637.00);
            //assert
        
            Assert.AreEqual("novecentos e noventa e nove mil novecentos e noventa e nove reais e dezesseis centavos", resultado3);
            Assert.AreEqual("sessenta e um mil seiscentos e trinta e sete reais", resultado4);
        }
        [TestMethod]
        public void Converter_unidadeMilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act

            string resultado3 = conversor.Converter(1000000);
            string resultado4 = conversor.Converter(1115000);
            //assert

            Assert.AreEqual("um milhão de reais", resultado3);
            Assert.AreEqual("um milhão cento e quinze mil reais", resultado4);
        }
        [TestMethod]
        public void Converter_dezenaMilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act

            string resultado3 = conversor.Converter(12000000);
            
            //assert

            Assert.AreEqual("doze milhões de reais", resultado3);
           
        }
        [TestMethod]
        public void Converter_centenaMilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act

            string resultado3 = conversor.Converter(120000000);
            string resultado4 = conversor.Converter(120001000); 
            string resultado5 = conversor.Converter(425961637);
            //assert

            Assert.AreEqual("cento e vinte milhões de reais", resultado3);
            Assert.AreEqual("cento e vinte milhões e um mil reais", resultado4);
            Assert.AreEqual("quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", resultado5);
        }
        [TestMethod]
        public void Converter_unidadebilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();        
            //act
            string resultado3 = conversor.Converter(1000000000);
            string resultado4 = conversor.Converter(8425961637);
            //assert
            Assert.AreEqual("um bilhão de reais", resultado3);
            Assert.AreEqual("oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", resultado4);
        }
        [TestMethod]
        public void Converter_dezenaBilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act
            string resultado3 = conversor.Converter(12000000000);
            //assert
            Assert.AreEqual("doze bilhões de reais", resultado3);
        }
        [TestMethod]
        public void Converter_centenaBilhaoReal()
        {
            //arrange
            ConversorBase conversor = new ConversorBase();
            //act
            string resultado3 = conversor.Converter(110000000000);
            //assert
            Assert.AreEqual("cento e dez bilhões de reais", resultado3);
        }
    }
}
