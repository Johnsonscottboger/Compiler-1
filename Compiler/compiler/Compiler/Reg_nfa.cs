using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Compiler
{
    class Reg_nfa
    {
        #region 定义不确定的NFAM结构体
        /// <summary>
        /// 定义不确定的NFAM结构体
        /// </summary>
        public struct NFAM
        {
            public int startstatus;//起始状态
            public int endstatus;//结束状态
            public char varch;//弧
            /// <summary>
            /// NFA的构造函数
            /// </summary>
            /// <param name="cfrom">要构造的状态图的起始状态</param>
            /// <param name="cto">要构造的状态图的结束状态</param>
            /// <param name="ch">起始状态到结束状态的弧</param>
            public NFAM(int from, int to, char ch)
            {
                this.startstatus = from;
                this.endstatus = to;
                this.varch = ch;
            }
        }
        #endregion

        #region 初始化算符堆栈，状态堆栈
        Stack<char> SignStack = new Stack<char>();//定义算符堆栈
        Stack<NFAM> StartEndStatesStack = new Stack<NFAM>();//保存起始节点
        Queue<NFAM> NfamQueue = new Queue<NFAM>();//弧队列
        char ch;//输入串中的一个字符
        int index = 0;//正规式索引
        private void StackInit()
        {
            SignStack.Push('#');
        }
        #endregion

        #region 运算符优先级表格
        private char[,] TableOfPriority = new char[6, 6];//定义一个6行6列的表格
        /// <summary>
        /// 初始化运算符优先级表格
        /// </summary>
        private void TableOfPriorityInit()
        {

            TableOfPriority[0, 0] = ' ';
            TableOfPriority[0, 1] = '.';
            TableOfPriority[0, 2] = '|';
            TableOfPriority[0, 3] = '(';
            TableOfPriority[0, 4] = ')';
            TableOfPriority[0, 5] = '#';
            TableOfPriority[1, 0] = '.';
            TableOfPriority[1, 1] = '>';
            TableOfPriority[1, 2] = '>';
            TableOfPriority[1, 3] = '<';
            TableOfPriority[1, 4] = '>';
            TableOfPriority[1, 5] = '>';
            TableOfPriority[2, 0] = '|';
            TableOfPriority[2, 1] = '<';
            TableOfPriority[2, 2] = '>';
            TableOfPriority[2, 3] = '<';
            TableOfPriority[2, 4] = '>';
            TableOfPriority[2, 5] = '>';
            TableOfPriority[3, 0] = '(';
            TableOfPriority[3, 1] = '<';
            TableOfPriority[3, 2] = '<';
            TableOfPriority[3, 3] = '<';
            TableOfPriority[3, 4] = '=';
            TableOfPriority[3, 5] = 'E';
            TableOfPriority[4, 0] = ')';
            TableOfPriority[4, 1] = '>';
            TableOfPriority[4, 2] = '>';
            TableOfPriority[4, 3] = '>';
            TableOfPriority[4, 4] = 'E';
            TableOfPriority[4, 5] = '>';
            TableOfPriority[5, 0] = '#';
            TableOfPriority[5, 1] = '<';
            TableOfPriority[5, 2] = '<';
            TableOfPriority[5, 3] = '<';
            TableOfPriority[5, 4] = 'E';
            TableOfPriority[5, 5] = '=';
        }
        #endregion

        #region 主函数入口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strRegex"></param>
        public Queue<NFAM> StartTransform(string strRegex)
        {
            StackInit();                                //初始化堆栈
            TableOfPriorityInit();                      //初始化优先级表格
            strRegex = ChangeRegex(strRegex);           //规范化正规式
            if (ValidityOfRegex(strRegex))              //如果检查通过则分析并构造，否则返回空
            {
                return AnalyseRegex(strRegex);//调用分析构造函数
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 分析正规式并构造相应的NFAM
        /// <summary>
        /// 分析正规式并构造相应的NFAM
        /// </summary>
        /// <param name="str">输入一个正规式</param>
        /// <returns>构造的NFA</returns>
        private Queue<NFAM> AnalyseRegex(string str)
        {
            str += "#";
            ch = str[index];
            int start = 0;
            int end = 1;
            char compare = '=';
            int m = 0;
            int n = 0;
            do
            {
                ch = str[index];
                if (Char.IsLetterOrDigit(ch))
                {
                    if (StartEndStatesStack.Count == 0)
                    {
                        NFAM nfa = new NFAM(start, end, ch);
                        StartEndStatesStack.Push(nfa);//入状态栈
                        NfamQueue.Enqueue(nfa);//入队列
                    }
                    else
                    {
                        end = ((NFAM)StartEndStatesStack.Peek()).endstatus;
                        NFAM nfa = new NFAM(end + 1, end + 2, ch);
                        StartEndStatesStack.Push(nfa);//入状态栈
                        NfamQueue.Enqueue(nfa);//弧入队列
                    }
                    if (index < str.Length - 1)
                        index++;
                }
                else if (str[index] == '*')
                {
                    NFAM nfa13 = (NFAM)StartEndStatesStack.Pop();
                    //构造4条空弧
                    NFAM nfa14 = new NFAM(nfa13.endstatus, nfa13.startstatus, 'ε');

                    NFAM nfa15 = new NFAM(nfa13.endstatus + 1, nfa13.startstatus, 'ε');

                    NFAM nfa16 = new NFAM(nfa13.endstatus, nfa13.endstatus + 2, 'ε');

                    NFAM nfa17 = new NFAM(nfa13.endstatus + 1, nfa13.endstatus + 2, 'ε');

                    NFAM nfa18 = new NFAM(nfa13.endstatus + 1, nfa13.endstatus + 2, '#');
                    //新弧入栈
                    NfamQueue.Enqueue(nfa14);
                    NfamQueue.Enqueue(nfa15);
                    NfamQueue.Enqueue(nfa16);
                    NfamQueue.Enqueue(nfa17);
                    //起始节点入队列
                    StartEndStatesStack.Push(nfa18);
                    if (index < str.Length - 1)
                        index++;
                }
                else
                {
                    #region//查表
                    for (int i = 0; i < 6; i++)//i
                    {
                        if (SignStack.Peek() == TableOfPriority[i, 0])
                        {
                            m = i;
                            break;
                        }
                    }
                    for (int j = 0; j < 6; j++)//i+1
                    {
                        if (str[index] == TableOfPriority[0, j])
                        {
                            n = j;
                            break;
                        }
                    }
                    #endregion
                    compare = TableOfPriority[m, n];
                    Construction(compare, str);
                }
            }
            while (SignStack.Peek() != '#' || str[index] != '#');
            return NfamQueue;
        }
        #endregion


        #region 功能函数
        /// <summary>
        /// 根据查表得到的优先级构造相应的状态
        /// </summary>
        /// <param name="compare">优先级关系</param>
        /// <param name="str">正规式字符串</param>
        private void Construction(char compare, string str)
        {
            switch (compare)
            {
                case '<':
                    SignStack.Push(ch);
                    if (index < str.Length - 1)
                        index++;
                    break;
                case '>':
                    switch (SignStack.Pop())
                    {
                        case '.':
                            NFAM nfa2 = (NFAM)StartEndStatesStack.Pop();
                            NFAM nfa3 = (NFAM)StartEndStatesStack.Pop();
                            NFAM nfa4 = new NFAM(nfa3.endstatus, nfa2.startstatus, 'ε');
                            NfamQueue.Enqueue(nfa4);
                            NFAM nfa5 = new NFAM(nfa3.startstatus, nfa2.endstatus, '#');
                            StartEndStatesStack.Push(nfa5);
                            break;
                        case '|':
                            NFAM nfa6 = (NFAM)StartEndStatesStack.Pop();
                            NFAM nfa7 = (NFAM)StartEndStatesStack.Pop();
                            //构造或运算剩下的4条弧
                            NFAM nfa8 = new NFAM(nfa6.endstatus + 1, nfa7.startstatus, 'ε');
                            NFAM nfa9 = new NFAM(nfa6.endstatus + 1, nfa6.startstatus, 'ε');
                            NFAM nfa10 = new NFAM(nfa7.endstatus, nfa6.endstatus + 2, 'ε');
                            NFAM nfa11 = new NFAM(nfa6.endstatus, nfa6.endstatus + 2, 'ε');
                            //新构造的弧入队列
                            NfamQueue.Enqueue(nfa8);
                            NfamQueue.Enqueue(nfa9);
                            NfamQueue.Enqueue(nfa10);
                            NfamQueue.Enqueue(nfa11);
                            NFAM nfa12 = new NFAM(nfa6.endstatus + 1, nfa6.endstatus + 2, '#');
                            //起始节点入栈
                            StartEndStatesStack.Push(nfa12);
                            break;
                    }
                    break;
                case '=':
                    SignStack.Pop();
                    if (index < str.Length - 1)
                        index++;
                    break;
            }
        }
        /// <summary>
        /// 获取开始和结束节点
        /// </summary>
        /// <returns>开始和结束节点组成的数组</returns>
        public int[] GetStartEndNode()
        {
            int[] StartEndNode = new int[2];
            NFAM nfa1 = (NFAM)StartEndStatesStack.Pop();
            StartEndNode[0] = nfa1.startstatus;
            StartEndNode[1] = nfa1.endstatus;
            return StartEndNode;
        }
        #region 检查正规式是否正确
        /// <summary>
        /// 检查正规式是否正确
        /// </summary>
        /// <param name="str">输入一个正规式</param>
        /// <returns>检查结果</returns>
        private bool ValidityOfRegex(string str)
        {
            bool IsRight = true;//定义变量保存检查结果
            int i = 0;//字符串索引
            int countofbrackets = 0;//括号的数量
            if (str.StartsWith("*") || str.StartsWith("|"))//如果str以*或者|开头则为错误
            {
                IsRight = false;
            }
            if (str.EndsWith("|") || str.EndsWith("."))//如果str以*或者|结束则为错误
            {
                IsRight = false;
            }
            for (; i < str.Length; i++)
            {
                if ((str[i] == '(' && (str[i + 1] == '*' || str[i + 1] == '|')) || ((str[i] == '.' || str[i] == '|') && str[i + 1] == ')'))//如果前括号后面跟*或者|则为错误
                {
                    IsRight = false;
                }
                if (str[i] == '(')
                    countofbrackets++;
                if (str[i] == ')')
                    countofbrackets--;

            }

            for (int j = 0; j < str.Length; j++)
            {
                if (Char.IsLetterOrDigit(str[j]) || (str[j] == '.' || str[j] == '*' || str[j] == '|' || str[j] == '(' || str[j] == ')'))
                {
                    IsRight = true;
                }
                else
                    IsRight = false;
            }

            if (countofbrackets != 0)//如果括号的个数不成对这错误
                IsRight = false;
            if (str.IndexOf(')') < str.IndexOf('('))//如果第一个括号是后括号则错误
                IsRight = false;
            return IsRight;
        }
        #endregion

        /// <summary>
        /// 自动添加连接符号
        /// </summary>
        /// <param name="strRegex">用户输入的正规式</param>
        /// <returns>添加连接符号后的正规式</returns>
        public string ChangeRegex(string strRegex)
        {
            string Regex = null;
            for (int i = 0; i < strRegex.Length - 1; i++)
            {
                if (Char.IsLetterOrDigit(strRegex[i]) && Char.IsLetterOrDigit(strRegex[i + 1]))
                    Regex += strRegex[i] + ".";
                else if (Char.IsLetter(strRegex[i]) && strRegex[i + 1] == '(')
                    Regex += strRegex[i] + ".";
                else if (strRegex[i] == '*' && Char.IsLetter(strRegex[i + 1]))
                    Regex += strRegex[i] + ".";
                else if (strRegex[i] == ')' && Char.IsLetter(strRegex[i + 1]))
                    Regex += strRegex[i] + ".";
                else if (strRegex[i] == '*' && strRegex[i + 1] == '(')
                    Regex += strRegex[i] + ".";
                else if (strRegex[i] == ')' && strRegex[i + 1] == '(')
                    Regex += strRegex[i] + ".";
                else
                    Regex += strRegex[i];

            }
            return Regex + strRegex[strRegex.Length - 1];
        }

        #endregion
    }
}
