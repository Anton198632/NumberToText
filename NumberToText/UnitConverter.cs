using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
    public class UnitConverter
    {

        protected string[] units =
        {
            "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять",
            "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать",
            "восемнадцать", "деветнадцать",
        };

        protected string[] tens =
        {
           "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семдесят", "восемьдесят", "девяносто"
        };

        protected string[] hundreds =
        {
            "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
        };

        protected string[] thousands = new string[] { "тысяча", "тысячи", "тысяч" };
        protected string[] millions = new string[] { "миллион", "миллиона", "миллионов" };
        protected string[] billions = new string[] { "миллиард", "миллиарда", "миллиардов" };


        protected int unit = -1;
        protected int ten = -1;
        protected int hundred = -1;


        public UnitConverter(int n)
        {
            hundred = (int)Math.Floor((double)n / 100);
            ten = (int)Math.Floor((double)(n - hundred * 100) / 10);
            unit = (int)Math.Floor((double)(n - hundred * 100 - ten * 10) / 1);

            if (ten < 2)
            {
                ten = 0;
                unit = (int)Math.Floor((double)(n - hundred * 100) / 1);

            }

        }

        public string getText()
        {
            string result = $"{hundreds[hundred]} {tens[ten]} {units[unit]}";
            return TextFormatHelper.ReplaceSpaces(result);
        }



        public string getSupplement(Supplement supplement)
        {
            string result = "";

            switch (supplement)
            {
                case Supplement.THOUSANDS:
                    result = unit == 1 ? thousands[0] : unit < 4 ? thousands[1] : thousands[2];
                    break;

                case Supplement.MILLIONS:
                    result = unit == 1 ? millions[0] : unit < 4 ? millions[1] : millions[2];
                    break;

                case Supplement.BILLIONS:
                    result = unit == 1 ? billions[0] : unit < 4 ? billions[1] : billions[2];
                    break;

            }

            return result;

        }
    }
}
