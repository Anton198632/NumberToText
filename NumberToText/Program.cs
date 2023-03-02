using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberToText
{
    internal class Program
    {
        static void Main(string[] args)
        {


            new Thread(() =>
            {

                while (true)
                {
                    Сalculate(new Random().Next(1, int.MaxValue));
                    Thread.Sleep(1000);
                }

            }).Start();

        }


        static void Сalculate(long n)
        {
            string nS = n.ToString();

            int lastN = nS.Length % 3;

            if (lastN != 0)
                nS = $"{new string('0', 3 - lastN)}{n}";

            StringBuilder result = new StringBuilder();

            for (int i = nS.Length / 3 - 1; i > -1; i--)
            {
                int uN = Convert.ToInt32(nS.Substring(i * 3, 3));
                UnitConverter unitConverter = new UnitConverter(uN);

                string supplement = "";

                switch (nS.Length / 3 - 1 - i)
                {
                    case 1:
                        supplement = unitConverter.getSupplement(Supplement.THOUSANDS);
                        break;

                    case 2:
                        supplement = unitConverter.getSupplement(Supplement.MILLIONS); ;
                        break;

                    case 3:
                        supplement = unitConverter.getSupplement(Supplement.BILLIONS);
                        break;

                    default:
                        break;

                }

                result.Insert(0, $"{unitConverter.getText()} {supplement} ").Replace("  ", " ");

            }

            Console.WriteLine($"{n.ToString(),20:R} : {result}");
        }
    }
}
