using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso
{
    public class ConversorCentavos : ConversorSistemaNumerico
    {
              
        public string ConverterCentavos(string Centavos) //01-99
        {
            string centavosExtenso = null;
            char[] dezenaUnidadeDeCentavo = Centavos.ToCharArray();
            //[0]dezena [1]unidade       
            centavosExtenso += ConverterDezenaUnidade(dezenaUnidadeDeCentavo[1], dezenaUnidadeDeCentavo[0]);
            if (centavosExtenso == "Um")
            {
                centavosExtenso += " centavo";
            }
            else if (centavosExtenso != "Um" && centavosExtenso != "")
            {
                centavosExtenso += " centavos";
            }
            

            return centavosExtenso;
        }
    }
}
