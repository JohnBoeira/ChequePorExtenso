using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso
{
    public class ConversorReal : ConversorSistemaNumerico
    {
        string reaisExtenso = null;
        public string ConverterReais(string valorReal) //12001
        {
           
            if (valorReal.Length == 1)//9 
            {
                reaisExtenso = ConverterUnidade(valorReal.ToCharArray()[0]);
                reaisExtenso += ConverterUnidade(valorReal.ToCharArray()[0]) != "um" ? " reais" : " real";
                return reaisExtenso;
            }
            else if(valorReal.Length == 2)//99
            {
                reaisExtenso = ConverterDezenaUnidade(valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);
            }
            else if (valorReal.Length == 3)//999
            {
                reaisExtenso = ConverterCentenaDezenaUni(valorReal.ToCharArray()[2], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);
            }
            else if(valorReal.Length == 5)//9.999
            {
                char[] array = valorReal.ToCharArray();
               reaisExtenso = ConverterUnidadeMilhar(array[4], array[3], array[2], array[0]);
            }
            else if (valorReal.Length == 6)//99.999
            {             
                reaisExtenso = ConverterDezenaMilhar(valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[3], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);
            }
            else if (valorReal.Length == 7)//999.999
            {               
                reaisExtenso = ConverterCentenaMilhar(valorReal.ToCharArray()[6], valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[2], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);
            }
            else if (valorReal.Length ==9) //9.999.999
            {
                reaisExtenso = ConverterUnidadeMilhão(valorReal.ToArray()[8],valorReal.ToCharArray()[7], valorReal.ToCharArray()[6], valorReal.ToCharArray()[4], valorReal.ToCharArray()[3], valorReal.ToCharArray()[2], valorReal.ToCharArray()[0]);

            }
            else if (valorReal.Length == 10) //99.999.999
            {
                reaisExtenso = ConverterDezenaMilhão(valorReal.ToArray()[9], valorReal.ToArray()[8], valorReal.ToCharArray()[7], valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[3], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);

            }
            else if (valorReal.Length == 11) //999.999.999
            {
                reaisExtenso = ConverterCentenaMilhão(valorReal.ToCharArray()[10],valorReal.ToArray()[9], valorReal.ToArray()[8], valorReal.ToCharArray()[6], valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[2], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);

            }
            else if (valorReal.Length == 13) //9.999.999.999
            {
                reaisExtenso = ConverterUnidadeBilhao(valorReal.ToCharArray()[12], valorReal.ToCharArray()[11],valorReal.ToArray()[10], valorReal.ToArray()[8], valorReal.ToCharArray()[7], valorReal.ToCharArray()[6], valorReal.ToCharArray()[4], valorReal.ToCharArray()[3], valorReal.ToCharArray()[2], valorReal.ToCharArray()[0]);

            }
            else if (valorReal.Length == 14) //99.999.999.999
            {
                reaisExtenso = ConverterDezenaBilhao(valorReal.ToCharArray()[13], valorReal.ToCharArray()[12], valorReal.ToCharArray()[11], valorReal.ToArray()[9], valorReal.ToArray()[8], valorReal.ToCharArray()[7], valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[3], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);

            }
            else ///999.999.999.999
            {
                reaisExtenso = ConverterCentenaBilhao(valorReal.ToCharArray()[14], valorReal.ToCharArray()[13], valorReal.ToCharArray()[12], valorReal.ToCharArray()[10], valorReal.ToArray()[9], valorReal.ToArray()[8], valorReal.ToCharArray()[6], valorReal.ToCharArray()[5], valorReal.ToCharArray()[4], valorReal.ToCharArray()[2], valorReal.ToCharArray()[1], valorReal.ToCharArray()[0]);
            }
            reaisExtenso += " reais";
            
            return reaisExtenso;                           
        }
    }
}
