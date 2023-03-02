using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
    public class TextFormatHelper
    {
        public static string ReplaceSpaces(string text)
        {
            if (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
                return ReplaceSpaces(text);
            }

            if (text[0] == ' ')
            {
                text = text.Substring(1);
            }

            return text;

        }

    }
}
