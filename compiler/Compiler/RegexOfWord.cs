using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Compiler
{
    class RegexOfWord
    {
        Regex rx = new Regex(@"^[a-zA-Z]+([a-zA-Z]*|[0-9]*)[a-zA-Z]*$");
        public string[] get_lines(string str)
        {
            string[] lines = str.Split('\r');
            return lines;
        }
        public string[] get_words(string line)
        {
            string str;
            int i=1;
            int j = 0;
            int k = 0;
            string[] result={};
            while (j <= line.Length)
            {
                str = line.Substring(j, i);
                if (rx.IsMatch(str))
                {
                    i++;
                }
                else
                {
                    i--;
                    str = line.Substring(j, i);
                    j += str.Length;
                    i = 1;
                    result[k]=str;
                    k++;
                }
            }
            return result;
        }
    }
}
