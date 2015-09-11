using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class Symbol
    {
        public string name;//变量名
        public int token;//token值
        public string type;//变量类型

        public Symbol(string n, int t, string tp)
        {
            this.name = n;
            this.token = t;
            this.type = tp;
        }
    }
}
