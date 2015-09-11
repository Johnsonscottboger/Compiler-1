using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
{
    class Parser
    {
        int i = 0;
        public List<string> error = new List<string>();
        public void parser(List<token_table> list)
        {
            token_table token = getnexttoken(list);
            if (token.token!="program")
            {
                error.Add("缺少关键字program");
            }
            token = getnexttoken(list);
            if (token.type!=34)
            {
                error.Add("缺少程序名字");
            }
            token = getnexttoken(list);
            if (token.token!=";")
            {
                error.Add("缺少';'");
            }
            token = getnexttoken(list);
            if (token.token=="const")
            {
                con_st(list);
            }
            if (token.token=="var")
            {
                varst(list);
            }
            token = getnexttoken(list);
            if (token.token=="begin")
            {
                ST_SORT(list);
            }
        }

        

        private void con_st(token_table token)
        {
            throw new NotImplementedException();
        }

        private void ST_SORT(List<token_table> list)
        {
            token_table token = getnexttoken(list);
            if (token.token == "if") ifs(list);//if语句分析模块
            else if (token.token == "while") whiles(list);//while语句
            else if (token.token == "repeat") repeats(list);//repeat语句
            else if (token.token == "for") fors(list);//for语句
            else assign(list);//赋值语句
        }

        private void assign(List<token_table> list)
        {
            i--;
            token_table token = getnexttoken(list);
            if (token.type==34)
            {
                token = getnexttoken(list);
                if (token.token=="=")
                {
                    aexpr(list);
                    token = getnexttoken(list);
                    if (token.token != ";")
                    {
                        error.Add("行" + list[i-1].lineno + "\t错误:缺少';'");
                    }
                    else
                    {
                        token = getnexttoken(list);
                        if (token.token == "end")
                        {
                            return;
                        }
                        else
                        {
                            i--;
                            ST_SORT(list);
                        }
                    }
                }
                else
                    error.Add("行" + token.lineno + "\t赋值语句错误:缺少'='");
            }
            else error.Add("行" + token.lineno + "\t赋值语句错误:缺少变量");
        }
        
        private void fors(List<token_table> list)
        {
            i++;
            if (i < list.Count)
            {
                ;
            }
            else
                error.Add("行" + list[i - 1].getLineNo() + "\tfor无效");
        }

        private void repeats(List<token_table> list)
        {
            i++;
            if (i < list.Count)
            {
                ;
            }
            else
                error.Add("行" + list[i - 1].getLineNo() + "\trepeat无效");
        }

        private void whiles(List<token_table> list)
        {
            i++;
            if (i < list.Count)
            {
                ;
            }
            else
                error.Add("行" + list[i - 1].getLineNo() + "\twhile无效");
        }

        private void ifs(List<token_table>list)
        {
            bexp(list);
            i--;
            token_table token = getnexttoken(list);
            if (token.token!="then")
                error.Add("行" + token.lineno + "\t语法错误:缺少'then'");
            ST_SORT(list);
            token = getnexttoken(list);
            if (token.token=="else")
            {
                ST_SORT(list);
            }
        }

        private void varst(List<token_table>list)
        {
            token_table token = getnexttoken(list);
            while (true)
            {
                if (token.type!=34)
                {
                    error.Add("行" + token.lineno + "\t语法错误:var之后不是标识符"); 
                }
                token = getnexttoken(list);
                if (token.token==",")
                {
                    token = getnexttoken(list);
                }
                else if (token.token==":")
                {
                    break;
                }
                else error.Add("行" + token.lineno + "\t错误:变量名后只能出现:和，"); 
            }
            token = getnexttoken(list);
            if (token.token != "int" && token.token != "char" && token.token != "real" && token.token != "bool")
            {
                error.Add("行" + token.lineno + "\t错误:变量声明错误");
            }
            token = getnexttoken(list);
            if (token.token != ";")
            {
                error.Add("行" + token.lineno + "\t错误:缺少;");
            }
            token = getnexttoken(list);
            if (token.type==34)
            {
                i--;
                varst(list);
            }
            else if (token.token=="begin")
            {
                i--;
                return;
            }
            else error.Add("行" + token.lineno + "\t语法错误:缺少begin，或变量声明错误");
        }

        private void con_st(List<token_table> list)
        {
            token_table token = getnexttoken(list);
            if (token.type==34)
            {
                token = getnexttoken(list);
                if (token.token=="=")
                {
                    token = getnexttoken(list);
                    if (token.type>=35&&token.type<=39)
                    {
                        token = getnexttoken(list);
                        if (token.token==";")
                        {
                            token = getnexttoken(list);
                            if (token.type==34)
                            {
                                i--;
                                con_st(list);
                            }
                            else if (token.token=="var")
                            {
                                varst(list);
                            }
                        }
                        else error.Add("行" + token.lineno + "\t错误:缺少';'");

                    }
                    else error.Add("行" + token.lineno + "\t错误:'='后面必须跟常量");
                }
                else error.Add("行" + token.lineno + "\t错误:标识符后面必须跟'='");
                
            }
            else error.Add("行" + token.lineno + "\t错误:const后面必须跟标识符");
        }

        
        public bool IsMatch(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.
                RegularExpressions.Regex(@"^[a-zA-Z_]+[,a-zA-Z0-9]*[:]{1}(int)[;]|(char)[;]|(bool)[;]|(real)[;]$");
            return regex.IsMatch(str);
        }

        public void bexp(List<token_table>list)
        {
            bt(list);//单个布尔量
            i--;
            token_table token = getnexttoken(list);
            if (token.token == "or")
            {
                bexp(list);
            }
            else
                return;
        }

        private void bt(List<token_table> list)
        {
            bf(list);
            i--;
            token_table token = getnexttoken(list);
            token = getnexttoken(list);
            if (token.token == "and")
            {
                bexp(list);
            }
            else
                return;
        }

        private void bf(List<token_table> list)
        {
            i--;
            token_table token = getnexttoken(list);
            if (token.token=="not")
            {
                bf(list);
            }
            else if (token.token=="(")
            {
                bexp(list);
                token = getnexttoken(list);
                if (token.token != ")")
                {
                    error.Add("行" + token.lineno + "\t'（'不匹配");
                }
                else 
                {
                    aexpr(list);
                    token = getnexttoken(list);
                    if (token.token == ">" || token.token == ">=" || token.token == "<" || token.token == "<=" || token.token == "=" || token.token == "<>")
                    {
                        aexpr(list);
                    }
                }
            }
            else
            {
                aexpr(list);
                token = getnexttoken(list);
                if (token.token == ">" || token.token == ">=" || token.token == "<" || token.token == "<=" || token.token == "=" || token.token == "<>")
                {
                    aexpr(list);
                }
            }
        }

        private void aexpr(List<token_table> list)
        {
            token_table token = getnexttoken(list);
            char state = '0';
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (token.type>=34&&token.type<=39)
                        {
                            state = '1';
                            token = getnexttoken(list);
                        }
                        else
                        {
                            state = '2';
                            error.Add("行" + token.lineno + "\t错误:缺少常量");
                        }
                        break;
                    case '1':
                        if (isOperator(token.token))
                        {
                            state = '0';
                            token = getnexttoken(list);
                        }
                        else
                        {
                            state = '2';
                            i--;
                        }
                        break;
                }
            } 
            
        }

        public bool isOperator(string ch)
        {
            if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
            {
                return true;
            }
            else
                return false;
        }
        private token_table getnexttoken(List<token_table>list)
        {
            token_table token = new token_table(0,"",0);
            if (i<list.Count)
            {
                token = list[i];
                i++;
            }
            return token;
        }
    }
}
