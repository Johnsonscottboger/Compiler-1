using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace compiler
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
    public class NFANtoNFAD
    {
        private NFA.NFAM[] nfam;
        private NFA.NFAM nfa;

        /// <summary>
        /// 只写属性的Nfa
        /// </summary>
        public NFA.NFAM Nfa
        {
            set { this.nfa = value; }
        }
        public NFA.NFAM[] Nfam
        {
            set { this.nfam = value; }
        }
        List<List<int>> TableState = new List<List<int>>();
        List<int>[,] rrr;
        List<int> aaaaaa = new List<int>();


        public List<int> getaaaa()
        {
            return aaaaaa;
        }
        List<int> States = new List<int>();
        public List<int> GetStates()
        {
            return States;
        }
        /// <summary>
        /// 返回I,Ia,Ib.......Ix组成的表格
        /// </summary>
        /// <param name="nfam">要转换的nfam</param>
        /// <param name="start">起始状态</param>
        /// <returns>I,Ia,Ib.......Ix组成的表格</returns>
        public List<DFAD.DFA> Transfrom(NFA.NFAM[] nfam, string start, string end)
        {
            //List<List<int>> TableState = new List<List<int>>();
            TableState = StartAnalysis(nfam, start);
            List<Char> UsedAllChar = GetAllChar(nfam);//NFAM中用到的所有的非空字符
            List<int> Starts = new List<int>();
            List<int> Ends = new List<int>();
            List<DFAD.DFA> Result = new List<DFAD.DFA>();
            int m = 0;
            int n = 0;
            List<int>[,] TableDfaD = new List<int>[TableState.Count / (UsedAllChar.Count + 1), UsedAllChar.Count + 1];
            for (int i = 0; i < TableState.Count; i++)
            {
                if (m < TableState.Count / (UsedAllChar.Count + 1))
                    TableDfaD[m, n] = TableState[i];
                n++;
                if (n % (UsedAllChar.Count + 1) == 0)
                {
                    n = 0;
                    m++;
                }
            }
            int[,] newTable = new int[TableDfaD.GetLength(0), TableDfaD.GetLength(1)];
            rrr = TableDfaD;

            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                newTable[i, 0] = i;
                aaaaaa.Add(i);

            }
            for (int i = 0; i < TableDfaD.GetLength(0); i++)
            {
                for (int j = 1; j < TableDfaD.GetLength(1); j++)
                {
                    for (int k = 0; k < newTable.GetLength(0); k++)
                    {
                        if (ListCompare(TableDfaD[i, j], TableDfaD[k, 0]))
                        {

                            newTable[i, j] = k;
                        }
                        if (TableDfaD[i, j].Count == 0)
                            newTable[i, j] = -1;
                    }
                }
            }
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                for (int j = 0; j < UsedAllChar.Count; j++)
                {
                    DFAD.DFA dfa = new DFAD.DFA();
                    dfa.From = newTable[i, 0];
                    dfa.Varch = UsedAllChar[j];
                    dfa.To = newTable[i, j + 1];
                    Result.Add(dfa);
                }
            }

            return Result;
        }
        /// <summary>
        /// 返回I,Ia,Ib.......Ix组成的列表
        /// </summary>
        /// <param name="nfam">要转换的nfam</param>
        /// <param name="start">起始状态</param>
        /// <returns>I,Ia,Ib.......Ix组成的列表</returns>
        public List<List<int>> StartAnalysis(NFA.NFAM[] nfam, string start)
        {
            int Start = Convert.ToInt16(start);
            Boolean IsRepeat = false;
            List<int> startList = new List<int>();
            List<int> Dealing = new List<int>();//正在处理的状态集合
            Queue<List<int>> NeedDeals = new Queue<List<int>>(); //需要计算Ix的状态集合队列
            List<List<int>> Dealed = new List<List<int>>();//处理过的状态集合
            List<Char> UsedAllChar = new List<char>();//NFAM中用到的所有的非空字符
            List<int> DealingResult = new List<int>();//Dealing状态集合处理后的状态集合
            List<List<int>> OneLineState = new List<List<int>>();//表格中的一行数据
            startList = E_Closure(Start, nfam); //求出构造表格的第一个元素即第一行第一列
            UsedAllChar = GetAllChar(nfam);
            NeedDeals.Enqueue(startList);
            while (NeedDeals.Count != 0)
            {
                Dealing = NeedDeals.Dequeue();       //取出队列的第一个的元素
                OneLineState = GetOneLine(Dealing, nfam, UsedAllChar);
                Dealed.Add(Dealing);
                //关于是否重复判断错误，需要重新修改才能判断
                for (int j = 1; j < OneLineState.Count; j++)
                {
                    //判断是否重复，不重复这加入需要处理的队列needdeal
                    for (int i = 0; i < Dealed.Count; i++)
                    {
                        if (ListCompare(OneLineState[j], Dealed[i]))
                        {
                            IsRepeat = true;
                            break;
                        }
                        else
                        {
                            IsRepeat = false;
                            continue;
                        }
                    }
                    //    //判断是否在处理队列队列中，队列不能重复
                    //    foreach (List<int> state in NeedDeals)
                    //    {
                    //        if (ListCompare(state, OneLineState[j]))
                    //        {
                    //            IsRepeat = true;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            IsRepeat = false;
                    //            continue;
                    //        }
                    //    }
                    if (!IsRepeat && OneLineState[j].Count != 0)
                        NeedDeals.Enqueue(OneLineState[j]);
                    //加入到已处理队列中
                    Dealed.Add(OneLineState[j]);
                }
            }
            return Dealed;
        }
        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="state"></param>
        /// <param name="nfam"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        private List<List<int>> GetOneLine(List<int> state, NFA.NFAM[] nfam, List<char> ch)
        {
            List<List<int>> ListResult = new List<List<int>>();
            List<int> list = new List<int>();
            ListResult.Add(state);
            for (int i = 0; i < ch.Count; i++)
            {
                ListResult.Add(GetIxTransform(nfam, state, ch[i]));
            }
            return ListResult;
        }

        /// <summary>
        /// 一个状态集合经过弧ch所到达的所有状态
        /// </summary>
        /// <param name="nfam">参考的nfam</param>
        /// <param name="state">起始状态集合</param>
        /// <param name="ch">弧ch</param>
        /// <returns>状态集合state经过弧ch所到达的所有状态集合</returns>
        private List<int> GetIxTransform(NFA.NFAM[] nfam, List<int> state, Char ch)
        {
            List<int> AllState = new List<int>();
            List<int> EState = new List<int>();
            Boolean isrepeat = false;
            for (int i = 0; i < state.Count; i++)
            {
                int[] J = Move(state[i], ch, nfam);              //对开始状态集合中的每一个状态求ch弧
                for (int j = 0; j < J.Length; j++)
                {
                    EState = E_Closure(J[j], nfam);
                    if (EState.Count == 0)
                    {
                    }
                    else
                        //判断estate中是否存在，不存在就加入，避免重复
                        for (int m = 0; m < EState.Count; m++)
                        {
                            for (int k = 0; k < AllState.Count; k++)
                            {
                                if (EState[m] == AllState[k])
                                {
                                    isrepeat = true;
                                    break;
                                }
                                else
                                {
                                    isrepeat = false;
                                    continue;
                                }
                            }
                            if (isrepeat == false)
                                AllState.Add(EState[m]);
                        }
                }
            }
            return AllState;
        }




        #region
        /// <summary>
        /// 得到所有的非空字符
        /// </summary>
        /// <param name="nfam">NFAM</param>
        /// <returns>所有的非空字符</returns>
        private List<char> GetAllChar(NFA.NFAM[] nfam)
        {
            List<char> AllChar = new List<char>();
            bool isrepeat = false;
            for (int i = 0; i < nfam.Length; i++)
            {
                if (nfam[i].varch != 'ε')
                {
                    if (AllChar.Count == 0)
                        AllChar.Add(nfam[i].varch);
                    else
                    {
                        for (int j = 0; j < AllChar.Count; j++)
                        {
                            if (AllChar[j] == nfam[i].varch)
                            {
                                isrepeat = true;
                                break;
                            }
                            else
                            {
                                isrepeat = false;
                                continue;
                            }
                        }
                        if (!isrepeat)
                        {
                            AllChar.Add(nfam[i].varch);
                        }
                    }
                }
            }
            return AllChar;
        }

        /// <summary>
        /// 某一状态state经过弧ch到达的所有状态
        /// </summary>
        /// <param name="state">状态state</param>
        /// <param name="nfam">要参考的nfam</param>
        /// <returns>state经过弧ch到达的所有状态</returns>
        private List<int> E_Closure(int state, NFA.NFAM[] nfam)
        {
            Stack<int> StateStack = new Stack<int>();
            int TopOfStateStack = 0;
            Boolean IsRepeat = false;
            List<int> DStates = new List<int>();
            DStates.Add(state);
            StateStack.Push(state);
            while (StateStack.Count != 0)
            {
                TopOfStateStack = StateStack.Pop();
                for (int i = 0; i < nfam.Length; i++)
                {
                    if (nfam[i].startstatus == TopOfStateStack && nfam[i].varch == 'ε')
                    {
                        StateStack.Push(nfam[i].endstatus);
                        for (int j = 0; j < DStates.Count; j++)               //检查当前状态是否已经在DS中存在
                        {
                            if (nfam[i].endstatus == DStates[j])
                            {
                                IsRepeat = true;
                                break;
                            }
                            else
                            {
                                IsRepeat = false;
                                continue;
                            }
                        }
                        if (!IsRepeat)                                         //如果不存在就加入DS
                        {
                            DStates.Add(nfam[i].endstatus);
                        }
                    }
                }
            }
            return DStates;
        }

        /// <summary>
        /// 状态state经过一条ch弧得到的状态
        /// </summary>
        /// <param name="state">开始状态</param>
        /// <param name="ch">弧</param>
        /// <param name="nfam">nfam数组</param>
        /// <returns>结束状态</returns>
        private int[] Move(int state, char ch, NFA.NFAM[] nfam)
        {
            bool isrepeat = false;
            List<int> EndStates = new List<int>();
            for (int i = 0; i < nfam.Length; i++)
            {
                if (nfam[i].startstatus == state && nfam[i].varch == ch)
                {
                    for (int j = 0; j < EndStates.Count; j++)
                        if (nfam[i].startstatus == EndStates[j])
                        {
                            isrepeat = true;
                            break;
                        }
                        else
                        {
                            isrepeat = false;
                            continue;
                        }
                    if (isrepeat == false)
                        EndStates.Add(nfam[i].endstatus);
                }
            }
            int[] EndState = new int[EndStates.Count];
            EndStates.CopyTo(EndState);
            return EndState;
        }
        #endregion

        /// <summary>
        /// 比较两个列表是否相等
        /// </summary>
        /// <param name="FirstList">要比较的第一个列表</param>
        /// <param name="SecondList">要比较的第二个列表</param>
        /// <returns>是否相等</returns>
        private Boolean ListCompare(List<int> FirstList, List<int> SecondList)
        {
            Boolean IsEquation = false;
            if (FirstList.Count != SecondList.Count)
                IsEquation = false;
            else
                for (int i = 0; i < FirstList.Count; i++)
                {
                    if (FirstList[i] == SecondList[i])
                    {
                        IsEquation = true;
                        continue;
                    }
                    else
                    {
                        IsEquation = false;
                        break;
                    }
                }
            return IsEquation;
        }
        /// <summary>
        /// 找到所有的开始状态和结束状态
        /// </summary>
        /// <param name="start">nfam的开始状态</param>
        /// <param name="end">nfam的结束状态</param>
        /// <returns>dfad的开始和结束状态</returns>
        public string[] GetStartEndsNode(string start, string end)
        {
            string[] strs = new string[2];
            for (int i = 0; i < rrr.GetLength(0); i++)
            {
                for (int j = 0; j < rrr[i, 0].Count; j++)
                {
                    if (rrr[i, 0][j] == Convert.ToInt16(start))
                        strs[0] += i.ToString() + ',';
                    if (rrr[i, 0][j] == Convert.ToInt16(end))
                        strs[1] += i.ToString() + ',';
                }
            }
            return strs;
        }
    }
    public static class NFA
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
    }
    class Group
    {
        public struct Node
        {
            public int pos;
            public int num;
            public int accept;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="pos">组号</param>
            /// <param name="num">状态号</param>
            /// <param name="accept">是否为非终结状态1表示非 0表示终结</param>
            public Node(int Pos, int num, int accept)
            {
                this.pos = Pos;
                this.num = num;
                this.accept = accept;
            }
            public Boolean CompareTo(Node node)
            {
                if (this.pos == node.pos && this.num == node.num && this.accept == node.accept)
                    return true;
                else
                    return false;
            }
        }
        public struct Arc
        {
            public int start;
            public char input;
            public int end;
            public Arc(int start, char input, int end)
            {
                this.start = start;
                this.end = end;
                this.input = input;
            }

        }

    }
    public class DfaMinClass
    {

        Stack<List<int>> nodesStack = new Stack<List<int>>();//需要处理的分组堆栈
        Queue<List<Group.Node>> nodesQueue = new Queue<List<Group.Node>>();//不需要继续分组的队列
        int pos = 2;
        List<Group.Node> node = new List<Group.Node>();

        public List<DFAD.DFA> DMC(DFAD.DFA[] Dfas, string Starts, string Ends, string States)
        {
            bool isrepa = false;
            int starts = Convert.ToInt16(Starts);
            int[] ends = new int[Ends.Length];
            string[] State = States.Split(',');
            List<int> node3 = new List<int>();//终结状态组
            List<int> node4 = new List<int>();//非终结状态组
            int[] st = new int[State.Length - 1];
            for (int i = 0; i < State.Length - 1; i++)
            {
                st[i] = Convert.ToInt16(State[i]);
            }
            //得到所有的开始状态和结束状态

            for (int i = 0; i < Ends.Length; i++)
                ends[i] = Convert.ToInt16(Ends[i]);

            for (int i = 0; i < st.Length; i++)
            {
                if (Ends.IndexOf(st[i].ToString()) != -1)
                {
                    Group.Node node1 = new Group.Node(1, st[i], 0);
                    node.Add(node1);
                    node3.Add(node1.num);
                }
                else
                {
                    Group.Node node1 = new Group.Node(0, st[i], 1);
                    node.Add(node1);
                    node4.Add(node1.num);
                }
            }
            //将所有的分组放入堆栈中
            nodesStack.Push(node3);
            nodesStack.Push(node4);
            //到此为止堆栈中有两个元素，终态集合和非终态集合
            while (nodesStack.Count != 0)
            {
                List<int> NeedGroup = new List<int>();
                NeedGroup = nodesStack.Pop();
                if (NeedGroup.Count > 1)
                {
                    ComparePos(GetAllChar(Dfas), Dfas, NeedGroup);
                }
            }
            string txtTest = "";
            for (int i = 0; i < node.Count; i++)
            {
                txtTest += "组号:" + node[i].pos.ToString() + "\t\t状态号:" + node[i].num.ToString() + "\t是否为非终结状态:" + node[i].accept.ToString() + "\r\n";

            }
            System.IO.File.WriteAllText(@"c:\txtTest.test", txtTest);
            txtTest = "";
            List<DFAD.DFA> newdfas = new List<DFAD.DFA>();

            foreach (DFAD.DFA dfa in Del(Dfas, ChangeDFA(Dfas)))
            {
                DFAD.DFA newdfa = new DFAD.DFA(SearchPos(dfa.From), SearchPos(dfa.To), dfa.Varch);
                for (int i = 0; i < newdfas.Count; i++)
                {
                    if (newdfa.From == newdfas[i].From && newdfa.To == newdfas[i].To && newdfa.Varch == newdfas[i].Varch)
                    {
                        isrepa = true;
                        break;
                    }
                    else
                    {
                        isrepa = false;
                        continue;
                    }
                }
                if (isrepa == false)
                {
                    newdfas.Add(newdfa);
                }
            }
            List<DFAD.DFA> result = new List<DFAD.DFA>();
            for (int i = 0; i < newdfas.Count; i++)
            {
                txtTest += newdfas[i].From + "\t" + newdfas[i].Varch + "\t" + newdfas[i].To + "\r\n";
                result.Add(newdfas[i]);
            }
            txtTest += "终结状态:";
            for (int i = 0; i < ChangeDFA(Dfas).Count; i++)
            {
                if (ChangeDFA(Dfas)[i].accept == 0)
                {
                    txtTest += ChangeDFA(Dfas)[i].pos.ToString() + ",";
                }
            }
            txtTest = txtTest.Substring(0, txtTest.Length - 1);
            txtTest += "\r\n开始状态:";
            for (int i = 0; i < node.Count; i++)
            {
                if (node[i].num == starts)
                    txtTest += SearchPos(starts).ToString();
            }
            System.IO.File.WriteAllText(@"c:\result.dfa", txtTest);
            return result;
        }


        /// <summary>
        /// 得到所有的非空字符
        /// </summary>
        /// <param name="nfam">NFAM</param>
        /// <returns>所有的非空字符</returns>
        private List<char> GetAllChar(DFAD.DFA[] dfas)
        {
            List<char> AllChar = new List<char>();
            bool isrepeat = false;
            for (int i = 0; i < dfas.Length; i++)
            {
                if (dfas[i].Varch != 'ε')
                {
                    if (AllChar.Count == 0)
                        AllChar.Add(dfas[i].Varch);
                    else
                    {
                        for (int j = 0; j < AllChar.Count; j++)
                        {
                            if (AllChar[j] == dfas[i].Varch)
                            {
                                isrepeat = true;
                                break;
                            }
                            else
                            {
                                isrepeat = false;
                                continue;
                            }
                        }
                        if (!isrepeat)
                        {
                            AllChar.Add(dfas[i].Varch);
                        }
                    }
                }
            }
            return AllChar;
        }
        /// <summary>
        /// 对输入的所有字符进行判断
        /// </summary>
        /// <param name="allchar">DFA中的所有字符</param>
        /// <param name="Dfas">DFA的所有弧</param>
        /// <param name="node">所有的节点</param>
        private void ComparePos(List<char> allchar, DFAD.DFA[] Dfas, List<int> NodeFromStack)
        {
            List<List<int>> ResultGroup = new List<List<int>>();
            for (int i = 0; i < allchar.Count; i++)
            {
                ResultGroup = ComparePos(allchar[i], Dfas, NodeFromStack);
                if (ResultGroup[1].Count != 0)
                {
                    if (ResultGroup[0].Count > 1)
                        nodesStack.Push(ResultGroup[0]);
                    if ((ResultGroup[1].Count == 2 && (SearchPos(ResultGroup[1][0]) != SearchPos(ResultGroup[1][1]))) || ResultGroup[1].Count == 1)
                    {
                    }
                    else
                    {
                        nodesStack.Push(ResultGroup[1]);
                    }
                    break;
                }
            }

        }
        /// <summary>
        /// 对某一个输入字符查询node节点并分组
        /// </summary>
        /// <param name="ch">输入字符</param>
        /// <param name="dfas">DFA弧数组</param>
        /// <param name="node">需要查询判断的节点</param>
        private List<List<int>> ComparePos(char ch, DFAD.DFA[] dfas, List<int> NodeFromStack)
        {
            List<int> FirstGroup = new List<int>();
            List<int> SecondGroup = new List<int>();
            List<List<int>> ResultGroup = new List<List<int>>();

            for (int i = 0; i < NodeFromStack.Count; i++)
            {
                for (int j = 0; j < dfas.Length; j++)
                {
                    if (NodeFromStack[i] == dfas[j].From && dfas[j].Varch == ch)
                    {
                        if (dfas[j].To == -1)
                        {
                            FirstGroup.Add(dfas[j].From);
                        }
                        else if (SearchPos(dfas[j].To) == SearchPos(dfas[j].From))
                        {
                            FirstGroup.Add(dfas[j].From);
                            break;
                        }
                        else
                        {
                            if (NodeFromStack.Count == 2)
                                pos++;
                            ChangPos(dfas[j].From, pos);
                            SecondGroup.Add(dfas[j].From);
                        }
                    }
                }
            }
            ResultGroup.Add(FirstGroup);
            ResultGroup.Add(SecondGroup);
            return ResultGroup;
        }

        private List<Group.Node> ChangeDFA(DFAD.DFA[] DFA)
        {
            List<Group.Node> newNode = new List<Group.Node>();
            bool isrepeat = false;
            for (int i = 0; i < node.Count; i++)
            {
                for (int j = 0; j < newNode.Count; j++)
                {
                    if (node[i].pos == newNode[j].pos)
                    {
                        isrepeat = true;
                        break;
                    }
                    else
                    {
                        isrepeat = false;
                        continue;
                    }
                }
                if (isrepeat == false)
                {
                    newNode.Add(node[i]);
                }
            }
            return newNode;
        }

        private List<DFAD.DFA> Del(DFAD.DFA[] DFAS, List<Group.Node> Nodes)
        {
            List<DFAD.DFA> newDFA = new List<DFAD.DFA>();

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < DFAS.Length; j++)
                {
                    if ((DFAS[j].From) == Nodes[i].num)
                        newDFA.Add(DFAS[j]);
                }
            }



            return newDFA;
        }

        #region ///组号查询，修改，比较
        /// <summary>
        /// 改变组号
        /// </summary>
        /// <param name="state">要改变组号的状态号</param>
        /// <param name="newpos">新的组号</param>
        private void ChangPos(int state, int newpos)
        {
            for (int i = 0; i < node.Count; i++)
            {
                if (node[i].num == state)
                {
                    Group.Node newNode = new Group.Node(newpos, node[i].num, node[i].accept);
                    node.RemoveAt(i);
                    node.Add(newNode);
                    break;
                }
            }
        }
        /// <summary>
        /// 查询某一个状态的组号
        /// </summary>
        /// <param name="state">要查询的状态</param>
        /// <param name="node">所有的节点</param>
        /// <returns>组号</returns>
        private int SearchPos(int state)
        {
            int pos = 0;
            for (int i = 0; i < node.Count; i++)
            {
                if (node[i].num == state)
                {
                    pos = node[i].pos;
                    break;
                }
                else
                {
                    pos = -1;
                    continue;
                }
            }
            return pos;
        }
        /// <summary>
        /// 比较两个组号是否相等
        /// </summary>
        /// <param name="pos1">组号1</param>
        /// <param name="pos2">组号2</param>
        /// <returns>比较结果</returns>
        private Boolean IsEqual(int pos1, int pos2)
        {
            Boolean isEqual = false;
            if (pos1 == pos2)
                isEqual = true;
            return isEqual;
        }
        #endregion
    }
    public class DFAD
    {
        #region 定义不确定的NFAM结构体
        /// <summary>
        /// 定义不确定的NFAM结构体
        /// </summary>
        public struct DFA
        {
            public int From;//起始状态
            public int To;//结束状态
            public char Varch;//弧
            /// <summary>
            /// NFA的构造函数
            /// </summary>
            /// <param name="cfrom">要构造的状态图的起始状态</param>
            /// <param name="cto">要构造的状态图的结束状态</param>
            /// <param name="ch">起始状态到结束状态的弧</param>
            public DFA(int from, int to, char ch)
            {
                this.From = from;
                this.To = to;
                this.Varch = ch;
            }
        }
        #endregion
    }
    
}
