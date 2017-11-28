using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace D3PDFMaker
{
    public static class StringExtensions
    {
        public static string HanToZen(this string s)
        {
            var str = Regex.Replace(s, "[0-9]", p => ((char)(p.Value[0] - '0' + '０')).ToString());
            str = Regex.Replace(str, "[a-z]", p => ((char)(p.Value[0] - 'a' + 'ａ')).ToString());
            return Regex.Replace(str, "[A-Z]", p => ((char)(p.Value[0] - 'A' + 'Ａ')).ToString());
        }
    }
}
