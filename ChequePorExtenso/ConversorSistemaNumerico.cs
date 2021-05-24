using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso
{
    public abstract class ConversorSistemaNumerico : ConversorBase
    {
        protected string ConverterDezenaUnidade(char unidade, char dezena)
        {
            if (dezena == '0') //01 - 09
            {
                return ConverterUnidade(unidade);
            }
            else
            if (dezena == '1')
            {
                switch (unidade)
                {
                    case '0': return "dez";
                    case '1': return "onze";
                    case '2': return "doze";
                    case '3': return "treze";
                    case '4': return "quatorze";
                    case '5': return "quinze";
                    case '6': return "dezesseis";
                    case '7': return "dezessete";
                    case '8': return "dezoito";
                    case '9': return "dezenove";
                    default: throw new ArgumentOutOfRangeException("Valor digitado incorreto: ", nameof(dezena), nameof(unidade));
                }
            }
            else
            {
                if (unidade == '0') //ex: 20 30 40 50 80
                {
                    return ConverterDezena(dezena);
                }
                else //ex: 21
                {
                    return ConverterDezena(dezena) + " e " + ConverterUnidade(unidade);
                }
            }
        }

        private string ConverterDezena(char dezena)
        {
            switch (dezena)
            {
                case '0': return "";
                case '2': return "vinte";
                case '3': return "trinta";
                case '4': return "quarenta";
                case '5': return "cinquenta";
                case '6': return "sessenta";
                case '7': return "setenta";
                case '8': return "oitenta";
                case '9': return "noventa";
                default: throw new ArgumentOutOfRangeException("Valor digitado incorreto: ", nameof(dezena));
            }
        }

        protected string ConverterUnidade(char unidade)
        {
            switch (unidade)
            {
                case '0': return "";
                case '1': return "um";
                case '2': return "dois";
                case '3': return "três";
                case '4': return "quatro";
                case '5': return "cinco";
                case '6': return "seis";
                case '7': return "sete";
                case '8': return "oito";
                case '9': return "nove";
                default: throw new ArgumentOutOfRangeException("Valor digitado incorreto: ", nameof(unidade));
            }
        }

        protected string ConverterCentenaDezenaUni(char unidade, char dezena, char centena) //001 000
        {
            if (centena == '1' && unidade == '0' && dezena == '0')
            {
                return "cem";
            }
            else if (unidade == '0' && dezena == '0')
            {
                return ConverterCentena(centena);
            }
            else if (centena == '0')
            {
                return "e " + ConverterDezenaUnidade(unidade, dezena);
            }
            else
            {
                return ConverterCentena(centena) + " e " + ConverterDezenaUnidade(unidade, dezena);
            }
        }

        protected string ConverterCentena(char centena)
        {
            switch (centena)
            {
                case '0': return "";
                case '1': return "cento";
                case '2': return "duzentos";
                case '3': return "trezentos";
                case '4': return "quatrocentos";
                case '5': return "quinhentos";
                case '6': return "seiscentos";
                case '7': return "setecentos";
                case '8': return "oitocentos";
                case '9': return "novecentos";
                default: throw new ArgumentOutOfRangeException("Valor digitado incorreto: ", nameof(centena));
            }
        }

        protected string ConverterUnidadeMilhar(char unidade, char dezena, char centena, char umilhar) //0
        {
            if (umilhar == '1')
            {
                if (centena == '0' && dezena == '0' && unidade == '0')
                {
                    return "mil"; //1000
                }
                else if (dezena == '0' && unidade == '0')
                {
                    return "mil" + " e " + ConverterCentenaDezenaUni(unidade, dezena, centena); //1100 1200
                }
                else
                {
                    return "mil " + ConverterCentenaDezenaUni(unidade, dezena, centena);//1125
                }
            }

            else
            {
                if (dezena == '0' && unidade == '0')
                {
                    return ConverterUnidade(umilhar) + " mil " + " e " + ConverterCentenaDezenaUni(unidade, dezena, centena);
                }

                else
                {
                    return ConverterUnidade(umilhar) + " mil " + ConverterCentenaDezenaUni(unidade, dezena, centena);
                }
            }
        }
        protected string ConverterDezenaMilhar(char unidade, char dezena, char centena, char umilhar, char dmilhar)
        {
            if (dezena == '0' && unidade == '0')
            {
                return ConverterDezenaUnidade(umilhar, dmilhar) + " mil " + " e " + ConverterCentenaDezenaUni(unidade, dezena, centena);
            }
            else
            {
                return ConverterDezenaUnidade(umilhar, dmilhar) + " mil " + ConverterCentenaDezenaUni(unidade, dezena, centena);
            }
        }
        protected string ConverterCentenaMilhar(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar)
        {
            if (umilhar == '0' && dmilhar == '0' && cmilhar == '0')
            {
                return "";
            }
            else if (centena != '0' && dezena == '0' && unidade == '0')
            {
                return ConverterCentenaDezenaUni(umilhar, dmilhar, cmilhar) + " mil " + " e " + ConverterCentenaDezenaUni(unidade, dezena, centena);
            }
            else if (centena == '0')
            {
                return ConverterCentenaDezenaUni(umilhar, dmilhar, cmilhar) + " mil";
            }
            else
            {
                return ConverterCentenaDezenaUni(umilhar, dmilhar, cmilhar) + " mil " + ConverterCentenaDezenaUni(unidade, dezena, centena);
            }

        }
        public string ConverterUnidadeMilhão(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao)
        {
            if (umilhao == '1')
            {
                if (ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar) == "")
                {
                    return "um milhão de";
                }
                return "um milhão " + ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar);
            }
            else
            {
                return ConverterUnidade(umilhar) + " milhões " + ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar);
            }
        }
        public string ConverterDezenaMilhão(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao, char dmilhao)
        {
            if (ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar) =="")
            {
                return ConverterDezenaUnidade(umilhao, dmilhao) + " milhões de";
            }
            return ConverterDezenaUnidade(umilhao, dmilhao) + " milhões " + ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar);
        }
        public string ConverterCentenaMilhão(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao, char dmilhao, char cmilhao)
        {
            if (ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar) == "" && ConverterCentenaDezenaUni(umilhao, dmilhao, cmilhao) != "")
            {
                return ConverterCentenaDezenaUni(umilhao, dmilhao, cmilhao) + " milhões de";
            }
            else if (ConverterCentenaDezenaUni(umilhao, dmilhao, cmilhao) != "")
            {
                return ConverterCentenaDezenaUni(umilhao, dmilhao, cmilhao) + " milhões " + ConverterCentenaMilhar(unidade, dezena, centena, umilhar, dmilhar, cmilhar);
            }
            return "";
        }
        public string ConverterUnidadeBilhao(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao, char dmilhao, char cmilhao, char ubilhao)
        {
            if (ubilhao == '1')
            {
                if (ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao) != "")
                {
                    return "um bilhão " + ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao);
                }
                return "um bilhão de";
            }
            else
            {
                if (ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao) == "")
                {
                    return ConverterUnidade(ubilhao) + " bilhões de";
                }
                return ConverterUnidade(ubilhao) + " bilhões " + ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao);
            }
        }
        public string ConverterDezenaBilhao(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao, char dmilhao, char cmilhao, char ubilhao, char dbilhao)
        {
            if (ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao) == "")
            {
                return ConverterDezenaUnidade(ubilhao, dbilhao) + " bilhões de";
            }
            return ConverterDezenaUnidade(ubilhao, dbilhao) + " bilhões " + ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao);
        }
        public string ConverterCentenaBilhao(char unidade, char dezena, char centena, char umilhar, char dmilhar, char cmilhar, char umilhao, char dmilhao, char cmilhao, char ubilhao, char dbilhao, char cbilhao)
        {
            if (ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao) == "")
            {
                return ConverterCentenaDezenaUni(ubilhao, dbilhao, cbilhao) + " bilhões de";
            }

                return ConverterCentenaDezenaUni(ubilhao, dbilhao, cbilhao) + " bilhões " + ConverterCentenaMilhão(unidade, dezena, centena, umilhar, dmilhar, cmilhar, umilhao, dmilhao, cmilhao);
        }
    }
}
