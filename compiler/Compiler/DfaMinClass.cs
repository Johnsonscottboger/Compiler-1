using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class DfaMinClass
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
}
