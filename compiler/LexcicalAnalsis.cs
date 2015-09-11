using System;
using System.Collections.Generic;
using System.Text;

namespace compiler
{
    class LexcicalAnalsis
    {
        int i = 0, j = 0;
        public static int LineNo = 1;
        public static int Flag1LineNo, Flag2LineNo, Flag3LineNo, Flag4LineNo;//出错信息行号
        string token = "";
        string text2 = "";//token串
        public static List<List<string>> TokenTable = new List<List<string>>();//token串
        string text3 = "";//记录错误信息
        public static string text4 = "入口:单词名称   长度     类型     种属     值    内存地址" + "\r\n";//用来记录符号表
        public static List<List<string>> SymbolTable = new List<List<string>>();//符号表
        string wrong = "";//记录异常信息
        public static int errors = 0;
        public static string text5 = "";//记录错误的详细信息
        int flag1 = 0, flag2 = 0, flag3, flag4 = 0;        //标记成对出现的界符
        string[] m_KeyWords = new string[32]{"auto", "double", "int","struct", "break", "else","long","switch","case","enum",
            "register","typedef","char","extern","return","union","const","float","short","unsigned","continue","for","signed","void","default",
        "goto","sizeof","volatile","do","if","while","static" };//定义关键字   32  这是字符串 数组
        string[] m_bound = new string[13] { "{", "}", "[", "]", ";", ",", ".", "(", ")", ":", "\"", "#", "\'" };//定义界符 13 也是字符串数组
        string[] m_operator = new string[28]{"+","-","*","/","%",">","<",">=","<=","==", "-=","+=","*=","/=",   
                           "!=","=","%=","&","&&","|","||","!","++","--","~","<<",">>","?:"};//定义运算符   28 同样是字符串数组

        public void GetTokenSymbol(string str)//读入字符串
        {
            string space = "";//空格数
            try
            {
                while (str[i] != '\0')//读入字符串判断,空格,字母,数字,界符  一个一个字符读
                    if (str[i] == ' ' || str[i] == '\t' || str[i] == '\r')//跳过无意义的的字符 空格 换行
                    {
                        i++;
                    }
                    else if (str[i] == '\n')//如果是换行符,则行号加1
                    {
                        LineNo++;
                        i++;
                    }
                    else if (isalpha(str[i]))//如果是字母
                    {
                        i = recog_id(str, i);
                        for (j = 0; j < m_KeyWords.Length; j++)
                        {
                            if (token.CompareTo(m_KeyWords[j]) == 0)//调用了字符串的CompareTo方法，如果string一致就返回0
                                break;
                        }
                        if (j >= m_KeyWords.Length)//不是关键字 是标识符
                        {
                            //for (int m = 0; m < 12 - token.Length; m++)//空格数  挺有用的控制格式的
                              //  space = space + " ";
                            //text2 = text2 + LineNo.ToString() + ":  " + token + space + "标识符     Token码       61" + "\r\n"; ;
                            List<string> ls = new List<string>();
                            ls.Add(LineNo.ToString());//行号
                            ls.Add(token);//单词
                            ls.Add("61");//种别码
                            ls.Add("标识符");//类别
                            TokenTable.Add(ls);//添加到Token串中
                            //符号表
                            //text4 = text4 + LineNo.ToString() + ":  " + token + space + token.Length + "        " + "标识符" + "  " + "简单变量" + "  " + "未知" + "  " + "  未知" + "\r\n";
                            AddToSymbolTabel(LineNo.ToString(), token, token.Length.ToString(), "", "简单变量", "", "");
                            token = "";//把token置空
                            space = ""; //把space 置空

                        }
                        if (j < m_KeyWords.Length)//是关键字
                        {
                            /*for (int m = 0; m < 12 - token.Length; m++)//空格数
                            {
                                space = space + " ";
                            }
                            text2 = text2 + LineNo.ToString() + ":  " + m_KeyWords[j] + space + "关键字     Token码       " + Convert.ToString(gettoken(token, 1)) + "\r\n"; ;
                            */
                            List<string> ls = new List<string>();
                            ls.Add(LineNo.ToString());//行号
                            ls.Add(token);//单词
                            ls.Add(Convert.ToString(gettoken(token, 1)));//种别码
                            ls.Add("关键字");//类别
                            TokenTable.Add(ls);//添加到Token串中
                            token = "";//把token置空
                            space = "";//把space置空

                        }
                    }
                    else if (isdigit(str[i]))//如果是数字 常数
                    {
                        i = recog_digit(str, i);//识别数字
                       /* for (int m = 0; m < 12 - token.Length; m++)
                            space = space + " ";//空格数
                        //控制输出
                        text2 = text2 + LineNo.ToString() + ":  " + token + space + "常数       Token码       62" + "\r\n";
                        */
                        List<string> ls = new List<string>();
                        ls.Add(LineNo.ToString());//行号
                        ls.Add(token);//单词
                        ls.Add("62");//种别码
                        ls.Add("常量");//类别
                        TokenTable.Add(ls);//添加到Token串中
                        //符号表输出
                        text4 = text4 + LineNo.ToString() + ":  " + token + space + token.Length + "        " + "整数" + "    " + "简单变量" + "  " + "未知" + "  " + "  未知" + "\r\n";
                        AddToSymbolTabel(LineNo.ToString(), token, token.Length.ToString(), "", "简单常量", "", "");//添加到符号表中
                        token = "";//把token置空+
                        space = "";//把space置空
                    }
                    else if (isbound(str[i]))//如果是界符
                    {
                        i = recog_bound(str, i);
                        /*for (int m = 0; m < 12 - token.Length; m++)//空格数
                        {
                            space = space + " ";
                        }

                        //控制输出
                        text2 = text2 + LineNo.ToString() + ":  " + token + space + "界符       Token码       " + Convert.ToString(gettoken(token, 3)) + "\r\n"; ;
                        */
                        List<string> ls = new List<string>();
                        ls.Add(LineNo.ToString());//行号
                        ls.Add(token);//单词
                        ls.Add(Convert.ToString(gettoken(token, 3)));//种别码
                        ls.Add("界符");//类别
                        TokenTable.Add(ls);//添加到Token串中
                        token = "";//把token置空
                        space = "";//把space置空

                    }
                    else if (isoperator(str[i]))//如果是运算符
                    {
                        i = recog_Operator(str, i);
                        /*for (int m = 0; m < 12 - token.Length; m++)//空格数
                            space = space + " ";
                        //控制输出
                        text2 = text2 + LineNo.ToString() + ":  " + token + space + "运算符     Token码       " + Convert.ToString(gettoken(token, 2)) + "\r\n";
                        */
                        List<string> ls = new List<string>();
                        ls.Add(LineNo.ToString());//行号
                        ls.Add(token);//单词
                        ls.Add(Convert.ToString(gettoken(token, 2)));//种别码
                        ls.Add("运算符");//类别
                        TokenTable.Add(ls);//添加到Token串中
                        token = "";//把token置空
                        space = "";//把space置空

                    }
                    else { error(0); i++; }//识别不了是非法字符
                error(1);//最后进行错误检查

            }

            catch (DivideByZeroException e1)
            {
                wrong = e1.Message;
            }
            catch (IndexOutOfRangeException e2)
            {
                wrong = e2.Message;
            }
            catch (Exception e)
            {
                wrong = e.Message;
            }
        }




        public bool isalpha(char ch)                  //判断是否为字母
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                return true;
            else
                return false;
        }
        public bool isdigit(char ch)                  //判断是否为数字
        {
            if (ch >= '0' && ch <= '9')
                return true;
            else return false;
        }
        public bool issign(char ch)                 //判断是否为下划线
        {
            if (ch == '_')
                return true;
            else return false;
        }
        public bool isbound(char ch)//判断是否为界符
        {
            for (j = 0; j < m_bound.Length; j++)
            {
                if ((ch.CompareTo(m_bound[j][0])) == 0)//返回0 说明是在同一个位置即相等 
                {
                    return true;
                }
            }
            return false;
        }
        public bool isoperator(char ch)//判断是否为运算符
        {
            for (j = 0; j < m_operator.Length; j++)
                if (ch == m_operator[j][0])//二维数组
                {
                    return true;
                }
            return false;

        }


        public int recog_id(string str, int i)//识别单词（关键字和标识符）
        {
            char state = '0';
            string sstr = "";
            while (state != '2')
            {
                switch (state)
                {
                    case '0': if (isalpha(str[i]))
                        {
                            state = '1';
                            sstr = sstr + str[i];
                            i++;
                        }
                        else error(1);
                        break;
                    case '1': if (isalpha(str[i]) || isdigit(str[i]) || issign(str[i]))
                        {
                            state = '1';
                            sstr = sstr + str[i];
                            i++;
                        }
                        else state = '2';
                        break;

                }
            }
            token = sstr;//记录识别的字符串
            return i;
        }
        public int recog_digit(string str, int i)//识别实数
        {
            char state = '0';
            string sstr = "";
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (isdigit(str[i]))
                        {
                            sstr += str[i];
                            state = '1';
                            i++;
                        }
                        break;
                    case '1':
                        if (isdigit(str[i]))
                        {
                            sstr += str[i];
                            i++;
                        }
                        else if (str[i] == '.' && isdigit(str[i + 1]))
                        {
                            sstr += str[i];
                            i++;
                        }
                        else
                        {
                            state = '2';
                            //i--;//终结的时候回退一个
                        }
                        break;
                }
                token = sstr;

            }
            return i;
        }
        public int recog_bound(string str, int i)//识别界符  状态转换图
        {
            string sstr = "";
            for (int k = 0; k < m_bound.Length; k++)
                if (str[i].CompareTo(m_bound[k][0]) == 0)//判断是否是定义的界符字符串数组的 元素
                {
                    sstr += str[i];
                    i++;
                    break;
                }
                else
                    continue;
            token = sstr;
            if (token == "{" || token == "}")
            {
                flag1++;
                Flag1LineNo = LineNo;
            }
            else if (token == "[" || token == "]")
            {
                flag2++;
                Flag2LineNo = LineNo;
            }

            else if (token == "(" || token == ")")
            {
                flag3++;
                Flag3LineNo = LineNo;
            }
            else if (token == "<" || token == ">")
            {
                flag4++;
                Flag4LineNo = LineNo;
            }

            /*else if(token=="\'")
                flag5++;
            else if(token=="\"")
                flag6++;*/
            return i;
        }
        private int recog_Operator(string str, int i)//识别运算符
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
                    case '1'://判断双目运算符
                        if (str.Substring(i - 1, 2) == "++" || str.Substring(i - 1, 2) == "--" || str.Substring(i - 1, 2) == "<<"
                            || str.Substring(i - 1, 2) == ">>" || str.Substring(i - 1, 2) == "+=" || str.Substring(i - 1, 2) == "-=" || str.Substring(i - 1, 2) == "*="
                            || str.Substring(i - 1, 2) == "/=" || str.Substring(i - 1, 2) == "!=" || str.Substring(i - 1, 2) == "%="||str.Substring(i - 1, 2) == "&&"
                            || str.Substring(i - 1, 2) == "||" )//取子串操作
                        {
                            sstr += str[i];
                            i++;
                            state = '2';
                        }
                        if (str[i - 1] == '?' && str[i] == ':')//判断三目运算符
                        {
                            sstr += str[i];
                            i++;
                            state = '2';
                        }
                        else
                        {
                            state = '2';//判断单个运算符
                        }
                        break;
                }
            }
            token = sstr;
            return i;

        }

        public int gettoken(string str, int k)//获得单词的token值
        {
            switch (k)
            {
                case 1:
                    for (int i = 0; i < m_KeyWords.Length; i++)//关键字
                    {
                        if (str == m_KeyWords[i])
                            return i + 1;
                    }
                    break;
                case 2:
                    for (int i = 0; i < m_operator.Length; i++)//运算符
                    {
                        if (str == m_operator[i])
                            return i + 33;
                    }
                    break;
                case 3:
                    for (int i = 0; i < m_bound.Length; i++)//界符
                    {
                        if (str == m_bound[i])
                            return i + 63;
                    }
                    break;
            }
            return 0;
        }
        public string ErrorNo()//错误信息个数
        {
            error(0);
            error(1);
            text3 = errors.ToString() + "  errors    词法分析结束。";//几个错误
            return text3;
        }
        public void error(int k)//具体错误信息
        {
            switch (k)
            {
                case 0:
                    text5 = text5 + LineNo.ToString() + ":" + "        非法字符     " + "\r\n";//输入了非法字符
                    errors++;
                    break;
                case 1://界符不匹配信息
                    if (flag1 % 2 != 0)
                    {
                        text5 = text5 + Flag1LineNo.ToString() + ":" + "   {   不匹配" + "\r\n";
                        errors++;
                    }
                    if (flag2 % 2 != 0)
                    {
                        text5 = text5 + Flag2LineNo.ToString() + ":" + "    [    不匹配" + "\r\n";
                        errors++;
                    }

                    if (flag3 % 2 != 0)
                    {
                        text5 = text5 + Flag3LineNo.ToString() + ":" + "    (    不匹配" + "\r\n";
                        errors++;
                    }
                    if (flag4 % 2 != 0)
                    {
                        text5 = text5 + Flag4LineNo.ToString() + ":" + "    <      不匹配" + "\r\n";
                        errors++;
                    }
                    /*  if (flag5 % 2 != 0)
                      {
                          text5 = text5 + LineNo.ToString() + ":" + "   '    不匹配  " + "\r\n";
                          errors++;
                      }
                      if (flag6 % 2 != 0)
                      {
                          text5 = text5 + LineNo.ToString() + ":" + "     \"    不匹配" + "\r\n";//转义字符
                          errors++;
                      }*/
                    break;

            }
        }
        public void AddToSymbolTabel(string s1,string s2,string s3,string s4,string s5,string s6,string s7)
        {
            List<string> ls1 = new List<string>();
            bool bl = true;
            ls1.Add(s1);//入口
            ls1.Add(s2);//单词名字
            ls1.Add(s3);//长度
            ls1.Add(s4);//类型
            ls1.Add(s5);//种属
            ls1.Add(s6);//值
            ls1.Add(s7);//内存地址
            if (ls1[1] == "include" || ls1[1] == "stdio" || ls1[1] == "h" || ls1[1] == "main")//去掉include预处理命令和main函数名
            {
                bl = false;
            }
            foreach (List<string> ls in SymbolTable)//插入前 查看符号表中是否已经存在 有则不加 没有则添加
            {
                if (ls[1] == ls1[1])
                {
                    bl = false;
                }
                
            }
            if(bl)
            SymbolTable.Add(ls1);//添加到符号表中
        }
    }
}


