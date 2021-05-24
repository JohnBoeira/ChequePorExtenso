using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso
{
    public class ConversorBase
    {
        ConversorCentavos conversorCentavos;
        ConversorReal conversorReal;
        public string Converter(double valorMonetario)
        {
            conversorReal = new ConversorReal();
            conversorCentavos = new ConversorCentavos();
            string valorPorExtenso;
            
            string valorConvertidoParaString = valorMonetario.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
            // 00.1 1000
            //"0,01" "1.000,00"
            string[] separadosCentDoReal = valorConvertidoParaString.Split(','); //[0] reais [1]centavos
                                                                          
            string reais = separadosCentDoReal[0];
            string centavos = separadosCentDoReal[1];
            
            if (reais != "0") //reais e centavos
            {
                valorPorExtenso = conversorReal.ConverterReais(reais); //12.001
                valorPorExtenso += conversorCentavos.ConverterCentavos(centavos) != "" ? " e " + conversorCentavos.ConverterCentavos(centavos) : ""; //12
                
            }
            else if(reais == "0" && centavos != "00") //centavos
            {
                valorPorExtenso = conversorCentavos.ConverterCentavos(centavos) + " de real";
            }
            else //0 00.0 0.0
            {
                valorPorExtenso = "Valor nulo";
            }
            
            return valorPorExtenso;
        }
             
        
    }
}
