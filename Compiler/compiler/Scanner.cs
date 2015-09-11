using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
namespace compiler
{
    class Scanner
    {
        int i = 0, j = 0;                    //记录字符位置,token数组的位置
        public static int LineNo = 1;                                       //行号
        string word = "";                //记录识别出的单词   
        public int errors = 0;                   //错误字段的个数
        //保留字
        string[] KeyWords = new string[20]{"program","var","integer","bool","real","char","const","begin","if",
        "then","else","while","do","repeat","until","for","to","end","read","write"};
        string[] Operators = new string[13]{"not","and","or","+","-","*","/","<",">","<=",">=","=",":="};//运算符
        string[] Bounds = new string[11] { ";", ",", "'", "\"", "//", "/*","*/","(",")",".",":"};              //界符
        
        public ArrayList tokenlist = new ArrayList();
        public ArrayList symList = new ArrayList();
        public ArrayList errorList = new ArrayList();
        public List<token_table> list = new List<token_table>();
        public List<Symbol> symbol = new List<Symbol>();
        public void scanner(string str)     
        {
            if (str.Length == 0)
            {
                return;
            }
            try 
            {
                while (str[i] != '\0')
                {
                    if (str[i] == ' ' || str[i] == '\t' || str[i] == '\r')
                    {
                        i++;  
                    }
                    else if (str[i] == '\n')		
                    {
                        LineNo++;
                        i++;
                    }
                    else if (isQuote(str[i]))
                    {
                        string sstr = ":";
                        if (str.Length>=2&&str.Substring(++i-1,2)==":=")
                        {
                            sstr = ":=";
                            tokenlist.Add(new token_table(LineNo,sstr,33));
                            list.Add(new token_table(LineNo, sstr, 33));
                            i++;
                        }
                        else
                        {
                            tokenlist.Add(new token_table(LineNo, sstr, 50));
                            list.Add(new token_table(LineNo, sstr, 50));
                        }
                    }
                    else if (isAlpha(str[i]))
                    {
                        i = recog_id(str, i);
                        for (j = 0; j < KeyWords.Length; j++)
                        {
                            if (word.CompareTo(KeyWords[j]) == 0)//token是某个关键字
                            {
                                break;
                            }
                        }
                        if (j >= KeyWords.Length)               //不是关键字
                        {
                            tokenlist.Add(new token_table(LineNo, word, 34));
                            list.Add(new token_table(LineNo, word, 34));
                            if (isExist_sym(word)==0)
                            {
                                symList.Add(new Symbol(word, 34, "标识符"));
                                
                            }
                            word = "";
                        }
                        if (j < KeyWords.Length)								//是关键字
                        {
                            tokenlist.Add(new token_table(LineNo, KeyWords[j], getType(word, 1)));
                            list.Add(new token_table(LineNo, KeyWords[j], getType(word, 1)));
                            word = "";
                        }
                    }
                    else if (isOperator(str[i]))//运算符
                    {
                        i = recog_Operator(str, i);
                        if (word.Length>0)
                        {
                            tokenlist.Add(new token_table(LineNo, word, getType(word, 2)));
                            list.Add(new token_table(LineNo, word, getType(word, 2)));
                        }
                        word = "";
                    }
                    else if (isDigit(str[i]))		//如果是数字
                    {
                        i = recog_Dig(str, i);
                    }
                    
                    else if (str[i] == '\'')
                    {
                        i = recog_char(str, i);
                    }
                    else if (str[i]=='"')
                    {
                        i = recog_string(str, i);
                    }
                    else if (isDelimiter(str[i]))                  //识别界符
                    {
                        i = recog_Del(str, i);
                        tokenlist.Add(new token_table(LineNo, word, getType(word, 3)));
                        list.Add(new token_table(LineNo, word, getType(word, 3)));
                        word = "";
                    }
                    else
                    {
                        word += str[i];
                        error(word);
                        i++;
                        word = "";
                    }
                }
            }
            catch (Exception e)
            {
                errorList.Add(e.Message);
            }
        }

        public bool isAlpha(char ch)            //判断是否为字母
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                return true;
            else
                return false;
        }

        public bool isDigit(char ch)                 //判断是否为数字
        {
            if (ch >= '0' && ch <= '9')
                return true;
            else
                return false;
        }

        public bool isSign(char ch)                 //识别下划线
        {
            if (ch == '_')
                return true;
            else
                return false;
        }

        public bool isDelimiter(char ch)            //判断是否为界符
        {
            for (int j = 0; j < Bounds.Length; j++)
            {
                if (ch.CompareTo(Bounds[j][0]) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isOperator(char ch)             //判断是否为运算符
        {
            for (int i = 0; i < Operators.Length; i++)
            {
                if (ch == Operators[i][0])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isQuote(char ch)//表示冒号
        {
            if (ch == ':')
            {
                return true;
            }
            else return false;
        }

        public bool issign(char ch) //识别正负号
        {
            if (ch == '+' || ch == '-')
            {
                return true;
            }
            else return false;
        }
        public int recog_id(string str, int i)             //识别单词
        {
            char state = '0';
            string sstr = "";                             //记录单词
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (isAlpha(str[i]))
                        {
                            state = '1';
                            sstr = sstr + str[i];
                            i++;
                        }
                        break;
                    case '1':
                        if (isAlpha(str[i]) || isDigit(str[i]) || isSign(str[i]))
                        {
                            state = '1';
                            sstr = sstr + str[i];
                            i++;
                        }
                        else
                        {
                            state = '2';
                        }
                        break;
                }
            }
            word = sstr;                   //记录识别的字符串
            return i;
        }

        public int recog_dig(string str, int i)
        {
            char state = '0';
            string sstr = "";
            while (state != '3')
            {
                switch (state)
                {
                    case '0':
                        if (isDigit(str[i]))
                        {
                            sstr += str[i];
                            state = '1';
                            i++;
                        }
                        break;
                    case '1':
                        if (isDigit(str[i]))
                        {
                            sstr += str[i];
                            state = '1';
                            i++;
                        }
                        else if (str[i] == '.' && isDigit(str[i + 1]))              
                        {
                            sstr += str[i];
                            state = '2';
                            i++;
                        }
                        else 
                            state = '3';
                        break;
                    case '2':
                        if (isDigit(str[i]))
                        {
                            sstr += str[i];
                            state = '2';
                            i++;
                        }
                        else state = '3';
                        break;
                }
            }
            tokenlist.Add(new token_table(LineNo, sstr, 35));
            list.Add(new token_table(LineNo, sstr, 35));
            if (isExist_sym(sstr) == 0)
            {
                symList.Add(new Symbol(sstr, 35, "常数"));
            }
            return i;
        }

        public int recog_Dig(string str, int i)
        {
            string sstr = "";
            char state = '0';
            while (state!='6')
            {
                switch (state)
                {
                    case '0':
                        if (isDigit(str[i]))
                        {
                            state = '1';
                            sstr += str[i];
                            i++;
                        }
                        break;
                    case '1':
                        if (isDigit(str[i]))
                        {
                            state = '1';
                            sstr += str[i];
                            i++;
                        }
                        else if (str[i] == '.')
                        {
                            state = '2';
                            sstr += str[i];
                            i++;
                        }
                        else if (str[i] == 'e' || str[i] == 'E')
                        {
                            state = '4';
                            sstr += str[i];
                            i++;
                        }
                        else //已识别完
                        {
                            tokenlist.Add(new token_table(LineNo, sstr, getType(sstr, 5)));
                            list.Add(new token_table(LineNo, sstr, getType(sstr, 5)));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 35, "常数"));
                            } 
                            state = '6';
                        }
                        break;
                    case '2':
                        if (isDigit(str[i]))
                        {
                            state = '3';
                            sstr += str[i];
                            i++;
                        }
                        else 
                        {
                            state = '6';
                            errorList.Add("行" + LineNo + ":" + "数字构词错误  " + sstr);
                            errors++;
                        }
                        break;
                    case '3':
                        if (isDigit(str[i]))
                        {
                            state = '3';
                            sstr += str[i];
                            i++;
                        }
                        else if (str[i] == 'e' || str[i] == 'E')
                        {
                            state = '4';
                            sstr += str[i];
                            i++;
                        }
                        else
                        {
                            state = '6';
                            tokenlist.Add(new token_table(LineNo, sstr, getType(sstr, 6)));
                            list.Add(new token_table(LineNo, sstr, getType(sstr, 6)));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 36, "实数"));
                            } 
                        }
                        break;
                    case '4':
                        if (isDigit(str[i]))
                        {
                            state = '4';
                            sstr += str[i];
                            i++;
                        }
                        else if (issign(str[i]))
                        {
                            state = '5';
                            sstr += str[i];
                            i++;
                        }
                        else
                        {
                            state = '6';
                            errorList.Add("行" + LineNo + ":" + "数字构词错误  " + sstr);
                            errors++;
                        }
                        break;
                    case '5':
                        if (isDigit(str[i]))
                        {
                            state = '5';
                            sstr += str[i];
                            i++;
                        }
                        else
                        {
                            state = '6';
                            tokenlist.Add(new token_table(LineNo, sstr, getType(sstr, 6)));
                            list.Add(new token_table(LineNo, sstr, getType(sstr, 6)));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 36, "实数"));
                            }
                        }
                        break;
                 }
            }
            return i;
        }

        private int recog_Operator(string str, int i)   //识别运算符
        {
            char state = '0';
            string sstr = "";
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        sstr += str[i];
                        i++;
                        state = '1';
                        break;
                    case '1':  
                        if (str.Substring(i - 1, 2) == ">=" || str.Substring(i - 1, 2) == "<=")
                        {
                            sstr += str[i];
                            i++;
                            state = '2';
                        }
                        else if (str.Substring(i-1,2)=="//")
                        {
                            while (str[i]!='\n'&&str[i]!='\0')
                            {
                                sstr = "";
                                if (i < str.Length)
                                {
                                    i++;
                                }
                            }
                        }
                        else if (str.Substring(i - 1, 2) == "/*")
                        {
                            while (str.Substring(i - 1, 2) != "*/" && str[i] != '\0')
                            {
                                i++;
                                if (str[i]=='\n')
                                {
                                    LineNo++;
                                }
                            }
                            if (str.Substring(i-1,2)=="*/")
                            {
                                i++;
                            }
                            sstr = "";
                        }
                        else { state = '2'; }                       //运算符
                        break;
                }
            }
            word = sstr;
            return i;
        }

        public int recog_Del(string str, int i)
        {
            string sstr = "";
            for (int k = 0; k < Bounds.Length; k++) 　　//判断为界符
                if (str[i].CompareTo(Bounds[k][0]) == 0)
                {
                    sstr += str[i];
                    i++;
                    break;
                }
                else continue;
            word = sstr;
            return i;
        }

        public int recog_char(string str, int i)
        {
            string sstr = "";
            char state = '0';
            while (state != '3')
            {
                switch (state)
                {
                    case '0': sstr += str[i]; state = '1'; i++; break;
                    case '1':
                        if (str[i]=='\0'||str[i] == '\n'||str[i]==' '||str[i]=='\t')
                        {
                            tokenlist.Add(new token_table(LineNo, sstr, getType(sstr, 3)));
                            list.Add(new token_table(LineNo, sstr, getType(sstr, 3)));
                            state = '3';
                        }
                        else if (str[i] == '\'')
                        {
                            sstr += str[i];
                            state = '3'; i++;
                            tokenlist.Add(new token_table(LineNo, sstr, 37));
                            list.Add(new token_table(LineNo, sstr, 37));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 37, "字符常量"));
                            }
                        }
                        else
                        {
                            sstr += str[i];
                            i++;
                            state = '2';
                        }
                        break;
                    case '2':
                        if (str[i] == '\0' || str[i] == '\n')
                        {
                            errorList.Add("行" + LineNo + ":" + "界符不匹配  " + sstr);
                            errors++;
                            state = '3';
                        }
                        else if (str[i] == '\'')
                        {
                            sstr += str[i];
                            state = '3'; i++;
                            tokenlist.Add(new token_table(LineNo, sstr, 37));
                            list.Add(new token_table(LineNo, sstr, 37));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 37, "字符常量"));
                            }
                        }
                        else errorList.Add("行" + LineNo + ":" + "界符不匹配  " + sstr);
                                errors++;state = '3';
                            break;
                }
            }
            return i;
        }
        public int recog_string(string str, int i)
        {
            string sstr = "";
            char state = '0';
            while (state != '2')
            {
                switch (state)
                {
                    case '0': sstr += str[i]; state = '1'; i++; break;
                    case '1':
                        if(str[i]!='"'&&str[i]!='\0'&&str[i]!='\n')
                        {
                            sstr += str[i]; state = '1'; i++;
                        }
                        else if (str[i] == '"')
                        {
                            sstr += str[i];
                            state = '2'; i++;
                            tokenlist.Add(new token_table(LineNo, sstr, 39));
                            list.Add(new token_table(LineNo, sstr, 39));
                            if (isExist_sym(sstr) == 0)
                            {
                                symList.Add(new Symbol(sstr, 39, "字符串常量"));
                            } 
                        }
                        else
                        {
                            if (sstr.Length>1)
                            {
                                errorList.Add("行" + LineNo + ":" + "界符不匹配  " + sstr);
                                errors++;
                            }
                            else tokenlist.Add(new token_table(LineNo, sstr, getType(sstr, 3)));
                            list.Add(new token_table(LineNo, sstr, getType(sstr, 3)));
                            state = '2';
                        }
                        break;
                }
            }
            return i;
        }
        public int getType(string str, int k)             //获得单词的种别码
        {
            int m =0;
            switch (k)
            {
                case 1:
                    for (int i = 0; i < KeyWords.Length; i++)                          //关键字
                    {
                        if (str == KeyWords[i])
                            m = i + 1;
                    }
                    break;
                case 2:
                    for (int i = 0; i < Operators.Length; i++)                         //运算符
                    {
                        if (str == Operators[i])
                            m= i + 20 + 1;
                    }
                    break;
                case 3:
                    for (int i = 0; i < Bounds.Length; i++)                           //界符
                    {
                        if (str == Bounds[i])
                            m= i + 39 + 1;
                    }
                    break;
                case 4: m = 34; break;      //标识符 id
                case 5: m = 35; break;      //整常数
                case 6: m = 36; break;      //实常数
                case 7: m = 37; break;      //字符常量
                case 8: m = 39; break;      //字符串常量
            }
            return m; 
        }

        void error(string word)
        {
            errorList.Add("行"+LineNo +":"+"无法识别字符  "+word);
            errors++;
        }

        public void write_token()
        {
            string str ="";
            FileStream fs = new FileStream("token.txt", FileMode.Create);
            foreach (token_table i in tokenlist)
            {
                str += i.lineno +"\t" +  i.token +"\t\t" +i.type + "\r\n";
            }
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
        }

        public int isExist_sym(string str)
        {
            int j = 0;
            foreach (Symbol sym in symList)
            {
                if (sym.name.Equals(str))
                {
                    j = 1;
                }
            }
            return j;
        }

        public void write_sym()
        {
            string str = "";
            FileStream fs = new FileStream("symbol.txt", FileMode.Create);
            foreach (Symbol i in symList)
            {
                str += i.name + "\t\t  " + i.token + "\t\t\t" + i.type +"\t\t"+"\r\n";
            }
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
        }
    }
}
