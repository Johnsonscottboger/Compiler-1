using System;
using System.Collections.Generic;
using System.Text;

namespace compiler
{
    class InterCodeGenratn
    {
        int i = 0;///用于生成临时变量的数目
        public static List<List<string>> InterCodeTable = new List<List<string>>();//中间代码表
        string[,] OperPre = new string[9, 9] { { "", "=", "+", "-", "*", "/", "(", ")", "#" },{ "=", "", "<", "<", "<", "<", "<", "<", ">" }, { "+", ">", ">", ">", "<", "<", "<", ">", ">" }, { "-", ">", ">", ">", "<", "<", "<", ">", ">" } 
                        ,{"*",">",">",">",">",">","<",">",">"},{"/",">",">",">",">",">","<",">",">"},{"(","","<","<","<","<","<","$",">"},{")",">","<","<","<","<","",">",">"},{"#","<","<","<","<","<","<","<","$"}};//算符优先表
        string[] RelaLogiOper = new string[9] { "<", ">", "<=", ">=", "==", "!=", "&&", "||", "!" };//关系和逻辑运算符
        public static List<List<int>> ListFalseChain = new List<List<int>>();//装假出口链的链
        public static List<int> FalseChain = new List<int>();//装假出口链的链
        public static List<int> TrueChain = new List<int>();//真出口链
        public static List<int> IfChain = new List<int>();//if出口链 if{}执行完产生的
        public static int DoWhileEntrance = 0;//do-while的入口
        public void GenInterCode(string op, string arg1, string arg2, string result)//生成四元式并加入到四元式表
        {
            List<string> ls = new List<string>();
            ls.Add(op);
            ls.Add(arg1);
            ls.Add(arg2); 
            ls.Add(result);
            InterCodeTable.Add(ls);
        }
        public string NewTemp()
        {
            
            i++;
            string s = "T";
            s += i.ToString();
            /*List<string> ls = new List<string>();
            ls[1] = s;
            LexcicalAnalsis.SymbolTable.Add(ls);//添加到符号表*/
            return s;
        }
        public bool SeekSymbolTable(string s)
        {
            bool bl = false;
            foreach(List<string> ls in LexcicalAnalsis.SymbolTable)
            {
                if (ls[1] == s)
                    bl = true;
            }
            return bl;
        }
        public string SeekOperPre(string s1, string s2)
        {
            string s3 = "";
            int x = 0,y=0;
            for (; x < 9;x++ )
            {
                if (s1 == OperPre[x,0])//找横坐标
                {
                    break;
                }
            }
            for (; y<9;y++)
            {
                if (s2 == OperPre[0, y])//找纵坐标
                    break;
            }
            if(x<9&&y<9)//确保数组有界
            s3 = OperPre[x, y];
            return s3;
        }
        public bool SeekOper(string s)//是否在Oper   判断一个运算符是否是算术运算符
        {
            bool bl=false;
            for (int x = 0; x < 9; x++)
            {
                if (s == OperPre[x,0])
                {
                    bl = true;
                    break;
                }
            }
            return bl;
        }
        public bool SeekRelaLogiOper(string s)//是否在RelaLogiOper   判断一个运算符是否是关系和逻辑运算符
        {
            bool bl = false;
            for (int x = 0; x < 9; x++)
            {
                if (s == RelaLogiOper[x])
                {
                    bl = true;
                    break;
                }
            }
            return bl;
        }
        public List<string> NewListStr()
        {
            List<string> ls1 = new List<string>();//用来存每一个语句 句子
            return ls1;
        }
        public List<int> NewListInt()
        {
            List<int> li1 = new List<int>();//用来存每一个语句 句子
            return li1;
        }
        public void BoolExprAnalysis(List<string> BoolExpre)//布尔表达式和关系表达式的语义分析  BoolExpre末尾需要有";"
        {
            int q = 0;
            List<string> ls1 = new List<string>();//用来存关系表达式中的算术表达式
            Stack<string> StateStack1 = new Stack<string>();//用来存放布尔量 
            Stack<string> SymbolStack1 = new Stack<string>();//用来存放符号
            while (q < BoolExpre.Count)
            {
                if (BoolExpre[q] == "&&")//是布尔量
                {
                    GenInterCode("jnz", StateStack1.Pop(), "_", (InterCodeGenratn.InterCodeTable.Count + 3).ToString());//真出口
                    GenInterCode("j", "_", "_", "0");//假出口
                    FalseChain.Add(InterCodeTable.Count);//加到假链上
                    q++;
                }
                else if (SeekRelaLogiOper(BoolExpre[q]))
                {
                    SymbolStack1.Push(BoolExpre[q]);//入符号栈
                    q++;
                }
                else if (!SeekRelaLogiOper(BoolExpre[q]) && !SeekOper(BoolExpre[q]) && BoolExpre[q] != ";")
                {
                    StateStack1.Push(BoolExpre[q]);//入状态栈
                    q++;
                }
                else if (SymbolStack1.Count > 0)
                {
                    if (SeekRelaLogiOper(SymbolStack1.Peek()) && BoolExpre[q] == ";")
                    {
                        string s2=StateStack1.Pop();
                        string s1=StateStack1.Pop();
                        GenInterCode("j" + SymbolStack1.Pop(), s1, s2, (InterCodeGenratn.InterCodeTable.Count + 3).ToString());//真出口
                        GenInterCode("j", "_", "_", "0");//假出口
                        FalseChain.Add(InterCodeTable.Count);//加到假链上
                        q++;
                    }

                }
                if (q == BoolExpre.Count) break;
                if (BoolExpre[q] == "(")
                {
                    SymbolStack1.Push("(");//入符号栈
                    q++;
                    while (BoolExpre[q] != ")")
                    {
                        ls1.Add(BoolExpre[q]);//用来存关系表达式中的算术表达式
                        q++;
                    }
                    if (BoolExpre[q] == ")")
                    {
                        SymbolStack1.Pop();//出符号栈
                    }
                    q++;//跳过")"
                    ArithmeticExprAnalysis(ls1);//算术表达式的语义分析
                    StateStack1.Push(InterCodeTable[InterCodeTable.Count - 1][3]);//入状态栈  此时是临时变量入状态栈
                }
            }
        }
        public void ArithmeticExprAnalysis(List<string> ls)//算术表达式语义分析
        {
            Stack<string> SymblStack = new Stack<string>();//符号栈
            Stack<string> StateStack = new Stack<string>();//状态栈
            SymblStack.Push("#");//初始化
            ls.Add("#");
            string Oper = "";
            int k = 0;
            while (ls[k] != "#" || SymblStack.Peek() != "#")
            {
                if (SeekSymbolTable(ls[k]))//在符号表里
                {
                    StateStack.Push(ls[k]);//压入状态栈
                    k++;
                }
                else
                {
                    switch (SeekOperPre(SymblStack.Peek(), ls[k]))
                    {
                        case "<":
                            {
                                SymblStack.Push(ls[k]);//当前算符进符号栈
                                k++;
                                break;
                            }
                        case ">":
                            {
                                Oper = SymblStack.Pop();//符号栈出栈
                                switch (Oper)
                                {
                                    case "-":
                                        {
                                            string Temp = NewTemp();
                                            GenInterCode("-", StateStack.Pop(), "", Temp);
                                            StateStack.Push(Temp);//入状态栈
                                            break;
                                        }
                                    case "*":
                                        {
                                            string Temp = NewTemp();
                                            string arg1, arg2;
                                            arg2 = StateStack.Pop();
                                            arg1 = StateStack.Pop();
                                            GenInterCode("*", arg1, arg2, Temp);
                                            StateStack.Push(Temp);//入状态栈
                                            break;
                                        }
                                    case "+":
                                        {
                                            string Temp = NewTemp();
                                            string arg1, arg2;
                                            arg2 = StateStack.Pop();
                                            arg1 = StateStack.Pop();
                                            GenInterCode("+", arg1, arg2, Temp);
                                            StateStack.Push(Temp);//入状态栈
                                            break;
                                        }
                                    case "=":
                                        {
                                            GenInterCode("=", StateStack.Pop(), "", StateStack.Pop());
                                            break;
                                        }
                                }
                                break;
                            }
                        case "$"://相等
                            {
                                SymblStack.Pop();//符号栈出栈
                                k++;
                                break;
                            }
                    }
                }
            }
        }
        public void IfExprAnalysis(List<string> ls)//if语句语义分析
        {
            List<List<string>> LLS2 = new List<List<string>>();//用来存放所有的句子
            List<string> ls3 = new List<string>();//用来存每一个语句 句子
            Stack<string> SymbolStack3 = new Stack<string>();//用来存放(
            Stack<string> SymbolStack4 = new Stack<string>();//用来存放{
            List<string> ls4 = new List<string>();//用来存每一个语句 else里的算术表达式语句
            List<string> ls5 = new List<string>();//用来存if{}里的语句 句子
            List<string> ls6 = new List<string>();//用来存 else里的 do-while语句
            List<string> ls7 = new List<string>();//用来存do-while语句里do{}中的算术表达式
            List<string> ls8 = new List<string>();//用来存do-while语句里while()中的布尔表达式和关系表达式
            for (int x = 0; x < ls.Count; x++)
            {
                if (ls[x] == "if")
                {
                    if (ls[x + 1] == "(")
                    {
                        SymbolStack3.Push("(");
                        x += 2;
                        ls3 = NewListStr();
                        while (SymbolStack3.Count > 0)
                        {
                            ls3.Add(ls[x]);
                            if (ls[x] == ")")
                            {
                                SymbolStack3.Pop();
                            }
                            else if (ls[x] == "(")
                            {
                                SymbolStack3.Push("(");
                            }
                            x++;
                        }
                        x--;
                        ls3.RemoveAt(ls3.Count - 1);//末尾的")"不要
                        ls3.Add(";");//此时ls3是布尔表达式或关系表达式
                        BoolExprAnalysis(ls3);
                        InterCodeGenratn.ListFalseChain.Add(InterCodeGenratn.FalseChain);//把假链添加到 假链的链里
                        FalseChain = NewListInt();//清空一下
                    }
                    if (ls[x + 1] == "{"&&ls[x+2]!="if")
                    {
                        x += 2;
                        while (ls[x] != ";")
                        {
                            ls5.Add(ls[x]);
                            x++;
                        }
                        ArithmeticExprAnalysis(ls5);//算术表达式分析
                        if (ls[x+1] == "}")
                        {
                            GenInterCode("j", "_", "_", (InterCodeTable.Count+2).ToString());//默认跳到下一条
                            IfChain.Add(InterCodeTable.Count);//InterCodeTable.Count就是把当前的四元式标号
                            foreach (int i1 in InterCodeGenratn.ListFalseChain[ListFalseChain.Count-1])//FalseChain的回填  假链的链里逆序 输出
                            {
                                for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                                {
                                    if ((j1 + 1) == i1)//四元式表的序号
                                    {
                                        InterCodeGenratn.InterCodeTable[j1][3] = (InterCodeGenratn.InterCodeTable.Count+1).ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                    }
                                }
                            }
                            ListFalseChain.RemoveAt(ListFalseChain.Count - 1);// 逆序输出之后 移除
                            x++;//跳过}
                        }
                        
                    }
                }
                else if (ls[x] == "else")
                {
                    if (ls[x+2] != "do")
                    {
                        ls4 = NewListStr();
                        while (ls[x] != ";")
                        {
                            x++;
                            if (ls[x] == "{")//把"{"去掉
                            {
                                x++;
                            }
                            ls4.Add(ls[x]);
                        }
                        ls4.RemoveAt(ls4.Count - 1);//去掉末尾的";"
                        ArithmeticExprAnalysis(ls4);//算术表达式
                        if (ls[x + 1] == "}")
                        {
                            foreach (int i1 in InterCodeGenratn.IfChain)//IfChain的回填
                            {
                                for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                                {
                                    if ((j1 + 1) == i1)//四元式表的序号
                                    {
                                        InterCodeGenratn.InterCodeTable[j1][3] = (InterCodeGenratn.InterCodeTable.Count + 1).ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                    }
                                }
                            }
                            x++;//把"}"去掉
                        }
                    }
                    if (x + 2 < ls.Count)
                    {
                        if (ls[x + 2] == "do")//处理do-while
                        {
                            x += 2;//跳过"else{"
                            while (!(ls[x] == ")" && ls[x + 1] == ";"))//do-while结束的标志
                            {
                                ls6.Add(ls[x]);//用来存 else里的 do-while语句
                                x++;
                            }
                            x += 2;//跳过"）;"
                            ls6.Add(")");
                            ls6.Add(";");
                            for (int z = 0; z < ls6.Count; z++)//处理do-while语句
                            {
                                if (ls6[z] == "do")//处理do{}里边的语句
                                {
                                    z++;
                                    if (ls6[z] == "{")//去掉"{"
                                    {
                                        DoWhileEntrance = InterCodeTable.Count + 1;//DoWhile的入口
                                        z++;
                                        while (ls6[z] != ";")
                                        {
                                            ls7.Add(ls6[z]);//用来存放do-while中的do{}中的算术表达式
                                            z++;
                                        }
                                        ArithmeticExprAnalysis(ls7);//算术表达式分析
                                    }
                                    if (ls6[z + 1] == "}")//去掉"}"
                                    {
                                        z++;
                                    }
                                }
                                if (ls6[z] == "while")
                                {
                                    z++;
                                    if (ls6[z] == "(")
                                    {
                                        z++;
                                        while (ls6[z] != ")")
                                        {
                                            ls8.Add(ls6[z]);//用来存放do-while中的while()中的布尔表达式和关系表达式
                                            z++;
                                        }
                                        ls8.Add(";");
                                        BoolExprAnalysis(ls8);//布尔表达式的分析
                                        TrueChain.Add(InterCodeTable.Count - 1);//把while()布尔表达式的真出口加到真链上
                                        foreach (int i1 in InterCodeGenratn.TrueChain)//TrueChain的回填
                                        {
                                            for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                                            {
                                                if ((j1 + 1) == i1)//四元式表的序号
                                                {
                                                    InterCodeGenratn.InterCodeTable[j1][3] = DoWhileEntrance.ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                                }
                                            }
                                        }
                                        InterCodeGenratn.ListFalseChain.Add(InterCodeGenratn.FalseChain);//把假链添加到 假链的链里
                                        foreach (int i1 in InterCodeGenratn.ListFalseChain[ListFalseChain.Count - 1])//FalseChain的回填  假链的链里逆序 输出
                                        {
                                            for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                                            {
                                                if ((j1 + 1) == i1)//四元式表的序号
                                                {
                                                    InterCodeGenratn.InterCodeTable[j1][3] = (InterCodeGenratn.InterCodeTable.Count + 1).ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                                }
                                            }
                                        }
                                        ListFalseChain.RemoveAt(ListFalseChain.Count - 1);// 逆序输出之后 移除
                                    }
                                }
                            }

                        }
                    }
                    
                    if (ls[x] == "}")
                    {
                        foreach (int i1 in InterCodeGenratn.IfChain)//IfChain的回填
                        {
                            for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                            {
                                if ((j1 + 1) == i1)//四元式表的序号
                                {
                                    InterCodeGenratn.InterCodeTable[j1][3] = (InterCodeGenratn.InterCodeTable.Count + 1).ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                }
                            }
                        }
                    }
                }
                else if (ls[x] == "{")
                {
                    SymbolStack4.Push("{");//入栈
                }
                else if (ls[x] == "}")
                {
                    SymbolStack4.Pop();//出栈
                    if (SymbolStack4.Count == 0)//if()的{}结束 
                    {
                        GenInterCode("j", "_", "_", "0");//跳出if{}
                        IfChain.Add(InterCodeTable.Count);//InterCodeTable.Count就是把当前的四元式标号
                        foreach (int i1 in InterCodeGenratn.IfChain)//IfChain的回填
                        {
                            for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                            {
                                if ((j1 + 1) == i1)//四元式表的序号
                                {
                                    InterCodeGenratn.InterCodeTable[j1][3] = InterCodeGenratn.InterCodeTable.Count.ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                }
                            }
                        }
                        foreach (int i1 in InterCodeGenratn.ListFalseChain[ListFalseChain.Count - 1])//FalseChain的回填  假链的链里逆序 输出
                        {
                            for (int j1 = 0; j1 < InterCodeGenratn.InterCodeTable.Count; j1++)
                            {
                                if ((j1 + 1) == i1)//四元式表的序号
                                {
                                    InterCodeGenratn.InterCodeTable[j1][3] = (InterCodeGenratn.InterCodeTable.Count+1).ToString();//回填当前的四元式号到假链中所有的四元式的相应分量上
                                }
                            }
                        }
                        ListFalseChain.RemoveAt(ListFalseChain.Count - 1);// 逆序输出之后 移除
                    }
                }

            }
        }
        public void ForExprAnalysis(List<string> ls)//for语句语义分析
        {
            List<string> ls1 = new List<string>();//用来存for(;;)中 第一个";"前里的算术表达式
            List<string> ls2 = new List<string>();//用来存for(;;)中 第二个";"前里的布尔表达式
            List<string> ls3 = new List<string>();//用来存for(;;)中 第二个";"后里的算术表达式
            List<string> ls4 = new List<string>();//用来存for(;;){}中的{}内的语句
            Stack<string> SymbolStack = new Stack<string>();//用来存放for(;;){}中的"{"
            int ForBoolEntrance = 0;//for(;;)中第一个;后的入口
            for (int x = 0; x < ls.Count; x++)//遍历
            {
                if (ls[x] == "for")
                {
                    x++;//跳过for
                    if (ls[x] == "(")
                    {
                        x++;//跳过(
                        while (ls[x] != ";")
                        {
                            ls1.Add(ls[x]);//用来存for(;;)中 第一个";"中里的算术表达式
                            x++;
                        }
                        ArithmeticExprAnalysis(ls1);//算术表达式语义分析
                        x++;//跳过第一个";"
                        while (ls[x] != ";")
                        {
                            ls2.Add(ls[x]);//用来存for(;;)中 第二个";"中里的布尔表达式
                            x++;
                        }
                        ls2.Add(";");
                        BoolExprAnalysis(ls2);//布尔表达式语义分析
                        ForBoolEntrance = InterCodeTable.Count-1;//填上for(;;)中第一个;后的入口
                        x++;//跳过第二个";"
                        while (ls[x] != ")")
                        {
                            ls3.Add(ls[x]);//用来存for(;;)中 第一个";"中里的算术表达式
                            x++;
                        }
                    }
                }
                else if (ls[x] == "{")
                {
                    x++;//跳过for(;;){}中的"{"
                    SymbolStack.Push("{");//入符号栈
                    while (SymbolStack.Count != 0)
                    {
                        if (ls[x] == "{")
                        {
                            SymbolStack.Push("{");//入符号栈
                        }
                        else if (ls[x] == "}")
                        {
                            SymbolStack.Pop();//出符号栈
                        }
                        ls4.Add(ls[x]);//用来存for(;;){}中的{}内的语句
                        x++;
                    }
                    ls4.RemoveAt(ls4.Count - 1);//移除一个}
                    IfExprAnalysis(ls4);//if语句的语义分析
                    x--;//回退一个
                    if (ls[x] == "}")//for(;;){}中的"}"
                    {
                        ArithmeticExprAnalysis(ls3);//for(;;)循环第二个;后的算术表达式语义分析
                        GenInterCode("j", "_", "_", ForBoolEntrance.ToString());//跳到for(;;)中第一个;之后 第二个;之前
                    }
                }
            }
        }
    }
}
