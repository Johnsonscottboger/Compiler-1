using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace Compiler
{
    class WordAnalysis
    {
        string[] keywords = { "program", "var", "integer", "bool", "real", "char", "const", "begin", "if", "then", "else", "while", "do", "for", "to", "end", "read", "write", "true", "false", "not", "and", "or" };
        //关键字表包括not and or
        string[] character = { "+", "-", "*", "/", "<", ">", "<=", ">=", "==", "<>", "=", ";", ",", "'", "/*", "*/", ":", "(", ")", "." };
        int[] character_code = { 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 };//种别码
        List<string> LinesCols = new List<string>();
        #region
        ArrayList Errors = new ArrayList();//错误信息Errors
        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <returns></returns>
        public List<string> Get_Errors()
        {
            List<string> errors = new List<string>();
            foreach (string s in Errors)
            {
                errors.Add(s);
            }
            return errors;
        }
        /// <summary>
        /// 获取行号列号
        /// </summary>
        /// <returns></returns>
        public List<string> Get_Lines_Cols()
        {
            return LinesCols;
        }
        /// <summary>
        /// 词法分析主函数
        /// </summary>
        /// <param name="str">要分析的程序源代码</param>
        /// <returns>分析结果</returns>
        public List<string> Analysis(string str)
        {
            int i = 0;//第i个字符；
            int Lines = 1;//行号；
            int Cols = 0;//列号；
            int count = 0;
            int errorline = 1;
            List<string> WordsList = new List<string>();
            string Words = null;
            while (i < str.Length)
            {
                #region
                if (str[i] == ' ' || str[i] == '\t')//除去空格和制表符
                {
                    i++; //读取下一个字符
                    Cols++;//列号加1
                }
                else if (str[i] == '\n')//将行隔开
                {
                    i++;//读取下一个字符
                    Lines++;//行号加1
                    Cols = 0;//列号+1
                }
                else if (Char.IsLetter(str[i]))//首字符是字母
                {
                    Words = recog_id(Lines, Cols, i, str);
                    i += Words.Length;
                    Cols += Words.Length;
                    WordsList.Add(Words);
                    LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                }
                else if (str[i] == '\'')//首字符是'
                {
                    Words = recog_str(Lines, Cols, i, str);
                    i += Words.Length;
                    Cols += Words.Length;
                    WordsList.Add(Words.Substring(0, Words.Length));
                    LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                }
                else if (Char.IsDigit(str[i]))//首字符是数字
                {
                    Words = recog_dig(Lines, Cols, i, str);
                    i += Words.Length;
                    Cols += Words.Length;
                    WordsList.Add(Words);
                    LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                }
                else if (str[i] == '/')//首字符是/
                {
                    Words = hand_com(Lines, Cols, i, str);
                    i += Words.Length;
                    Cols += Words.Length;
                    if (Words.Length == 1)
                    {
                        WordsList.Add(Words);
                        LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                    }
                    else
                    {
                        WordsList.Add("/*");
                        LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                        WordsList.Add("*/");
                        if (Words.IndexOf('\n') != -1)
                        {
                            string[] ss=Words.Split('\n');
                            Lines += ss.Length-1;
                            Cols = ss[ss.Length - 1].Length-1;
                        }
                        LinesCols.Add(Lines.ToString() + "," + Cols.ToString());
                    }
                }
                else//首字符是界符或者运算符
                {
                    Words = recog_del(Lines, Cols, i, str);
                    i += Words.Length;
                    Cols += Words.Length;
                    WordsList.Add(Words);
                    LinesCols.Add(Lines.ToString() + "," + (Cols - Words.Length + 1).ToString());
                }
                #endregion
            }
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '(')
                    count++;
                if (str[j] == ')')
                    count--;
                if (str[j] == '\n')
                {

                    if (count < 0)
                        ErrorInfo(errorline, 0, "", 106);
                    if (count > 0)
                        ErrorInfo(errorline, 0, "", 107);
                    errorline++;
                    count = 0;
                }
            }
            for (int j = 0; j < str.Length - 1; j++)
            {
                if (str[j] == '\'')
                    count++;
                if (str[j] == '\n')
                {

                    if (count % 2 != 0)
                        ErrorInfo(errorline, 0, "", 108);
                    errorline++;
                    count = 0;
                }
            }

            return WordsList;
        }
        /// <summary>
        /// 获取标识符或者关键字
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="i">第i个字符</param>
        /// <param name="str">源代码</param>
        /// <returns></returns>
        public string recog_id(int lines, int cols, int i, string str)
        {
            char state = '0';
            char ch = str[i];
            int length = 0;
            int j = i;
            #region
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (Char.IsLetter(ch))
                        {
                            state = '1';
                            length++;
                            j++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 100);
                            state = '1';
                        }
                        break;
                    case '1':
                        ch = str[j];
                        if (Char.IsLetter(ch) || Char.IsDigit(ch))
                        {
                            state = '1';
                            length++;
                            j++;
                        }
                        else
                            state = '2';
                        break;

                }
            }
            #endregion
            return str.Substring(i, length);
        }
        /// <summary>
        /// 保存错误信息
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="errorcode">错误代码</param>
        private void ErrorInfo(int lines, int cols, string words, int errorcode)
        {
            string line = lines.ToString();
            string col = cols.ToString();
            string errorinfo = null;
            string error = null;
            switch (errorcode)
            {
                case 100:
                    errorinfo = "标识符构词规则错误！";
                    break;
                case 101:
                    errorinfo = "实数构词规则错误！";
                    break;
                case 102:
                    errorinfo = "字符常量识别错误！";
                    break;
                case 103:
                    errorinfo = "注释识别错误";
                    break;
                case 104:
                    errorinfo = "界符识别错误！";
                    break;
                case 105:
                    errorinfo = "运算符识别错误！";
                    break;
                case 106:
                    errorinfo = "缺少前括号！";
                    break;
                case 107:
                    errorinfo = "缺少后括号！";
                    break;
                case 108:
                    errorinfo = "单引号不成对！";
                    break;
                case 109:
                    errorinfo = "注释长度超过255！";
                    break;
                default:
                    errorinfo = "无法识别的符号！";
                    break;
            }
            error = line + "," + col + "," + errorcode.ToString() + "," + words + "," + errorinfo;
            Errors.Add(error);
        }
        /// <summary>
        /// 获取字符常量
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="i">第i个字符</param>
        /// <param name="str">源代码</param>
        /// <returns></returns>
        private string recog_str(int lines, int cols, int i, string str)
        {
            char state = '0';
            int j = i;
            int length = 0;
            char ch = str[i];
            #region
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (ch == '\'')
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 102);
                            state = '1';
                        }
                        break;
                    case '1':
                        ch = str[j];
                        if (Char.IsLetter(ch))
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else
                        {
                            state = '2';
                        }
                        break;
                    case '2':
                        ch = str[j];
                        if (ch != '\'')
                            state = '3';
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 102);
                            state = '3';
                        }
                        break;
                }
            }
            #endregion
            return str.Substring(i, length+1);
        }
        /// <summary>
        /// 识别除法或者注释
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="i">第i个字符</param>
        /// <param name="str">源代码</param>
        /// <returns></returns>
        public string hand_com(int lines, int cols, int i, string str)
        {
            char state = '0';
            int j = i;
            int length = 0;
            char ch;
            #region
            while (state != '4')
            {
                switch (state)
                {
                    case '0':
                        if (str[i] == '/')
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 103);
                            state = '1';
                        }
                        break;
                    case '1':
                        ch = str[j];
                        if (ch == '*')
                        {
                            state = '2';
                            j++;
                            length++;
                        }
                        else
                        {
                            state = '4';
                        }
                        break;
                    case '2':
                        ch = str[j];
                        if (ch != '*')
                        {
                            state = '2';
                            j++;
                            length++;
                            if (ch == '\n')
                            {
                                lines++;
                                cols = 0;
                            }
                            if (length > 255)
                            {
                                ErrorInfo(lines, cols, str.Substring(i, length), 109);
                                state = '4';
                            }
                        }
                        else
                        {
                            state = '3';
                        }
                        break;
                    case '3':
                        ch = str[j];
                        if (ch == '*')
                        {
                            state = '3';
                            j++;
                            length++;
                        }
                        else if (ch == '/')
                        {
                            state = '4';
                        }
                        else
                        {
                            state = '2';
                        }
                        break;
                }
            }
            #endregion
            return str.Substring(i, length+1);

        }
        /// <summary>
        /// 识别界符
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="i">第i个字符</param>
        /// <param name="str">源代码</param>
        /// <returns></returns>
        private string recog_del(int lines, int cols, int i, string str)
        {
            char ch;
            char state = '0';
            int j = i;
            int length = 0;
            #region
            while (state != '2')
            {
                switch (state)
                {
                    case '0':
                        if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '<' || str[i] == '>' || str[i] == '=' || str[i] == ';' || str[i] == ',' || str[i] == ':' || str[i] == '(' || str[i] == ')' || str[i] == '.')
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length+1), 0);
                            length++;
                            state = '2';
                        }
                        break;
                    case '1':
                        ch = str[j];
                        if ((str[i] == '<' && (str[j] == '=' || str[j] == '>')) || ((str[i] == '>') && ch == '=') || (str[i] == '=' && ch == '='))
                        {
                            state = '2';
                            j++;
                            length++;
                        }
                        else if ((str[i] == '>' && str[j] == '<') || (str[i] == '>' && str[j] == '>') || (str[i] == '<' && str[j] == '<'))
                        {
                            state = '2';
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 105);
                        }
                        else
                        {
                            state = '2';
                        }
                        break;
                }
            }
            #endregion
            return str.Substring(i, length);
        }
        /// <summary>
        /// 识别数字
        /// </summary>
        /// <param name="lines">行号</param>
        /// <param name="cols">列号</param>
        /// <param name="i">第i个字符</param>
        /// <param name="str">源代码</param>
        /// <returns></returns>
        private string recog_dig(int lines, int cols, int i, string str)
        {
            char ch = str[i];
            int j = i;
            int length = 0;
            char state = '0';
            #region
            while (state != '7')
            {
                switch (state)
                {
                    case '0':
                        if (Char.IsDigit(ch))
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '1';
                        }
                        break;
                    case '1':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '1';
                            j++;
                            length++;
                        }
                        else if (ch == ' ' || ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '<' || ch == '>' || ch == '=' || ch == ';' || ch == ',' || ch == '\'' || ch == ':' || ch == '(' || ch == ')')
                        {
                            state = '7';
                        }
                        else if (ch == '.')
                        {
                            state = '2';
                            j++;
                            length++;
                        }
                        else if (ch == 'e' || ch == 'E')
                        {
                            state = '4';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '7';
                        }
                        break;
                    case '2':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '3';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '3';
                        }
                        break;
                    case '3':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '3';
                            j++;
                            length++;
                        }
                        else if (ch == ' ' || ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '<' || ch == '>' || ch == '=' || ch == ';' || ch == ',' || ch == '\'' || ch == ':' || ch == '(' || ch == ')')
                        {
                            state = '7';
                        }
                        else if (ch == 'e' || ch == 'E')
                        {
                            state = '4';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '7';
                        }
                        break;
                    case '4':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '6';
                            j++;
                            length++;
                        }
                        else if (ch == '+' || ch == '-')
                        {
                            state = '5';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '7';
                        }
                        break;
                    case '5':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '6';
                            j++;
                            length++;
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '6';
                        }
                        break;
                    case '6':
                        ch = str[j];
                        if (Char.IsDigit(ch))
                        {
                            state = '6';
                            j++;
                            length++;
                        }
                        else if (ch == ' ' || ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '<' || ch == '>' || ch == '=' || ch == ';' || ch == ',' || ch == '\'' || ch == ':' || ch == '(' || ch == ')')
                        {
                            state = '7';
                        }
                        else
                        {
                            ErrorInfo(lines, cols + length, str.Substring(i, length), 101);
                            state = '7';
                        }
                        break;
                }
            }
            #endregion
            return str.Substring(i, length);
        }
        #endregion
        /// <summary>
        /// 识别种别码
        /// </summary>
        /// <param name="str">要识别的字符串</param>
        /// <returns>种别码</returns>
        public int sort(string str)
        {
            Char ch = str[0];
            int i = 0;
            if (Char.IsLetter(ch))
            {
                for (int j = 0; j < keywords.Length; j++)
                {
                    if (str == keywords[j])
                    {
                        i = j + 1;
                        break;
                    }
                    else
                    {
                        i = 34;
                    }
                }
            }
            else if (Char.IsDigit(ch))
            {
                if (str.IndexOf('.') != -1)
                {
                    i = 36;
                }
                else
                {
                    i = 35;
                }
            }
            else
            {
                for (int j = 0; j < character.Length; j++)
                {
                    if (character[j] == str)
                    {
                        i = character_code[j];
                    }
                }
            }
            return i;
        }


    }
}