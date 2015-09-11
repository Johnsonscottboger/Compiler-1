using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class token_table
    {
        public int lineno = 0;
        public string token = "";
        public int type = 0;
        public token_table(int line, string s, int t)
        {
            this.lineno = line;
            this.token = s;
            this.type = t;
        }
        public string getTokenValue() 
        {
            return token;
        }
        public int getTypeValue()
        {
            return type;
        }
        public int getLineNo()
        {
            return lineno;
        }
    }
}
