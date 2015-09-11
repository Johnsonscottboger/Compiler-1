using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
namespace Compiler
{
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
                            if(isrepeat==false)
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
}
