using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace compiler
{
    public partial class Middle_Code : Form
    {
        public Middle_Code()
        {
            InitializeComponent();
        }



        private void button3_Click(object sender, EventArgs e)//打开文件
        {
            //打开文件对话框
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //打开字符流
                StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                //将文件内容，字符流显示在文本框1中
                textBox1.Text = sr.ReadToEnd().ToString();
                //关闭字符流
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LexcicalAnalsis.LineNo = 1;//初始化行号
            LexcicalAnalsis.errors = 0;//初始化错误个数
            LexcicalAnalsis.text5 = "";
            string text1 = textBox1.Text + '\0';//用于存放源程序
            LexcicalAnalsis LA = new LexcicalAnalsis();//实例化 LexcicalAnalsis类 为LA
            LA.GetTokenSymbol(text1);//调用LA实例GetTokenSymbol的方法 
            //输出TokenTable
            listView1.Clear();//移除所有的项和列
            listView1.Columns.Add("行号", 60);//添加列表头 “列表头名字”，宽度
            listView1.Columns.Add("单词", 90);
            listView1.Columns.Add("种别码", 90);
            listView1.Columns.Add("类别", 120);

            foreach (List<string> ls in LexcicalAnalsis.TokenTable)//输出
            {
                ListViewItem lvi = new ListViewItem();//以下为输出
                lvi.Text = ls[0];
                lvi.SubItems.Add(ls[1]);
                lvi.SubItems.Add(ls[2]);
                lvi.SubItems.Add(ls[3]);
                listView1.Items.Add(lvi);
            }

            //输出SymbolTable
            listView2.Clear();//移除所有的项和列
            listView2.Columns.Add("入口 ", 42);//添加列表头 “列表头名字”，宽度
            listView2.Columns.Add("单词名字", 62);
            listView2.Columns.Add("长度", 40);
            listView2.Columns.Add("类型", 53);
            listView2.Columns.Add("种属", 62);
            listView2.Columns.Add("值", 53);
            listView2.Columns.Add("内存地址", 62);

            foreach (List<string> ls in LexcicalAnalsis.SymbolTable)//输出
            {
                ListViewItem lvi = new ListViewItem();//以下为输出
                lvi.Text = ls[0];
                lvi.SubItems.Add(ls[1]);
                lvi.SubItems.Add(ls[2]);
                lvi.SubItems.Add(ls[3]);
                lvi.SubItems.Add(ls[4]);
                lvi.SubItems.Add(ls[5]);
                lvi.SubItems.Add(ls[6]);
                listView2.Items.Add(lvi);
            }
            //textBox2.Text = "*****************Token串生成表如下********************" + "\r\n" + text2;
            textBox3.Text = "***********出错信息如下************" + "\r\n" + LexcicalAnalsis.text5 + "\r\n" + "       错误个数：" + LexcicalAnalsis.errors + "\r\n" + "       词法分析结束！";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InterCodeGenratn ICG = new InterCodeGenratn();//实例化
            int BraceCounter = 0;//花括号计数器 用来判断{}是否结束
            List<string> MainProgram = new List<string>();//用来 存放经过主程序Main(){}中所有的句子        
            for (int l = 0; l < LexcicalAnalsis.TokenTable.Count; l++)//预处理命令 主程序语义分析
            {

                if (LexcicalAnalsis.TokenTable[l][1] == "#")//跳过预处理命令
                {
                    l++;
                    while (LexcicalAnalsis.TokenTable[l][1] != ">")
                    {
                        l++;//直接跳过 预处理命令
                    }
                    l++;//跳过">"
                }
                if (LexcicalAnalsis.TokenTable[l][1] == "void")//有void  是主程序
                {
                    l += 4;//跳过main()
                    if (LexcicalAnalsis.TokenTable[l][1] == "{")
                    {
                        BraceCounter++;
                        l++;//跳过"{"
                        while (BraceCounter != 0)
                        {
                            if (LexcicalAnalsis.TokenTable[l][1] == "}")
                            {
                                BraceCounter--;
                            }
                            else if (LexcicalAnalsis.TokenTable[l][1] == "{")
                            {
                                BraceCounter++;
                            }
                            MainProgram.Add(LexcicalAnalsis.TokenTable[l][1]);//添加到主程序中
                            l++;
                        }
                        MainProgram.RemoveAt(MainProgram.Count - 1);//移除最后的}
                    }
                }
                else
                {
                    while (l < LexcicalAnalsis.TokenTable.Count)
                    {
                        MainProgram.Add(LexcicalAnalsis.TokenTable[l][1]);//添加到主程序中
                        l++;
                    }
                }
            }
            while (true)//说明语句的语义分析
            {
                for (int i = 0; i < MainProgram.Count; i++)//遍历Token表
                {
                    if (MainProgram[i] == "int")//如果是int型
                    {
                        i++;//下一个Token串单词（单位）
                        bool bb = false;
                        for (int j = 0; j < LexcicalAnalsis.SymbolTable.Count; j++)//遍历符号表
                        {
                            if (MainProgram[i] == LexcicalAnalsis.SymbolTable[j][1])
                            {
                                LexcicalAnalsis.SymbolTable[j][3] = "整型";
                                bb = true;
                            }
                        }
                        if (!bb)//符号表里没找到，则为调用错误处理语法错误
                        {
                        }
                        i++;//下一个Token串单词（单位）
                        if (MainProgram[i] == "=")
                        {
                            for (int j = 0; j < LexcicalAnalsis.SymbolTable.Count; j++)//遍历符号表
                            {
                                if (MainProgram[i - 1] == LexcicalAnalsis.SymbolTable[j][1])
                                {
                                    LexcicalAnalsis.SymbolTable[j][5] = MainProgram[i + 1];//把值写进去
                                    bb = true;
                                }
                            }
                            i += 2;
                        }
                        while (MainProgram[i] != ";")//只要不是";"
                        {
                            if (MainProgram[i] == ",")
                            {
                                i++;
                            }
                            else//错误处理语法错误
                            {

                            }
                            for (int j = 0; j < LexcicalAnalsis.SymbolTable.Count; j++)//遍历符号表
                            {
                                if (MainProgram[i] == LexcicalAnalsis.SymbolTable[j][1])
                                {
                                    LexcicalAnalsis.SymbolTable[j][3] = "整型";
                                    bb = true;
                                }
                            }
                            if (!bb)//符号表里没找到，则为调用错误处理语法错误
                            {
                            }
                            i++;//下一个Token串单词（单位）
                            if (MainProgram[i] == "=")
                            {
                                for (int j = 0; j < LexcicalAnalsis.SymbolTable.Count; j++)//遍历符号表
                                {
                                    if (MainProgram[i - 1] == LexcicalAnalsis.SymbolTable[j][1])
                                    {
                                        LexcicalAnalsis.SymbolTable[j][5] = MainProgram[i + 1];//把值写进去
                                        bb = true;
                                    }
                                }
                                i += 2;
                            }
                        }
                    }
                }

                for (int i = 0; i < MainProgram.Count; i++)//遍历Token表  算术表达式的语义分析
                {
                    if (i < MainProgram.Count - 1)
                    {
                        if (MainProgram[i] == ";" && MainProgram[i + 1] == "a")//算术表达式
                        {
                            i++;
                            List<string> ls = new List<string>();//用来存放语法分析过后的语法单位即句子  这里是算术表达式和赋值表达式
                            while (MainProgram[i] != ";")
                            {
                                ls.Add(MainProgram[i]);
                                i++;
                            }
                            ICG.ArithmeticExprAnalysis(ls);//算术表达式语义分析
                            /*for (int j=0;j<ls.Count;j++)//遍历句子
                            {
                                if (ls[j] == "(")
                                {
                                    j++;
                                    if (ls[j] == "-")//单目
                                    {
                                        j++;
                                        string Temp = ICG.NewTemp();
                                        ICG.GenInterCode("-",ls[j],"",Temp);
                                    
                                        j++;
                                    }
                                    if (ls[j] == ")")
                                    {
                                        j++;
                                    }
                                }
                            }*/
                        }
                    }


                }
                List<List<string>> LLS = new List<List<string>>();//用来存放所有的句子
                List<string> ls1 = new List<string>();//用来存每一个语句 句子
                for (int i = 0; i < MainProgram.Count; i++)//遍历Token表
                {
                    if (MainProgram[i] != ";")
                    {
                        ls1.Add(MainProgram[i]);
                    }
                    else
                    {
                        ls1.Add(";");
                        LLS.Add(ls1);
                        ls1 = ICG.NewListStr();//生成一个 新句子 来存放
                    }
                }
                List<string> BoolExpre = new List<string>();//布尔表达式
                /*foreach (List<string> ls in LLS)//找到布尔表达式
                {
                    foreach (string s in ls)
                    {
                        if (s == "&&" || s == "||" || s == "!")
                            break;
                    }
                    BoolExpre = ls;
                }*/
                ICG.BoolExprAnalysis(BoolExpre);//布尔表达式和关系表达式的语义分析
                //含有if语句的
                List<List<string>> LLS1 = new List<List<string>>();//用来存放所有的句子
                List<string> ls2 = new List<string>();//用来存每一个语句 句子
                Stack<string> SymbolStack2 = new Stack<string>();//用来存放{
                for (int k = 0; k < MainProgram.Count; k++)//遍历MainProgram 
                {
                    if (MainProgram[k] == "if")//if语句块
                    {
                        bool bl = true;
                        while (bl)
                        {
                            ls2.Add(MainProgram[k]);//加入句子中
                            if (MainProgram[k] == "{")
                            {
                                SymbolStack2.Push("{");//入符号栈
                            }
                            else if (MainProgram[k] == "}")
                            {
                                SymbolStack2.Pop();//出符号栈
                                if (SymbolStack2.Count == 0)
                                {
                                    bl = false;
                                    LLS1.Add(ls2);
                                    ls2 = ICG.NewListStr();//生成一个 新句子 来存放
                                }
                            }
                            k++;
                        }
                        k--;
                    }
                    else if (MainProgram[k] == "else")//else语句块
                    {
                        bool bl = true;
                        while (bl)
                        {
                            ls2.Add(MainProgram[k]);//加入句子中
                            if (MainProgram[k] == "{")
                            {
                                SymbolStack2.Push("{");//入符号栈
                            }
                            else if (MainProgram[k] == "}")
                            {
                                SymbolStack2.Pop();//出符号栈
                                if (SymbolStack2.Count == 0)
                                {
                                    bl = false;
                                    LLS1.Add(ls2);
                                    ls2 = ICG.NewListStr();//生成一个 新句子 来存放
                                }
                            }
                            k++;
                        }
                        k--;
                    }
                    else if (MainProgram[k] == "for")//for语句块
                    {
                        bool bl = true;
                        while (bl)
                        {
                            ls2.Add(MainProgram[k]);//加入句子中
                            if (MainProgram[k] == "{")
                            {
                                SymbolStack2.Push("{");//入符号栈
                            }
                            else if (MainProgram[k] == "}")
                            {
                                SymbolStack2.Pop();//出符号栈
                                if (SymbolStack2.Count == 0)
                                {
                                    bl = false;
                                    LLS1.Add(ls2);
                                    ls2 = ICG.NewListStr();//生成一个 新句子 来存放
                                }
                            }
                            k++;
                        }
                        k--;
                    }

                }

                foreach (List<string> ls in LLS1)//遍历含有if的语句
                {
                    if (ls[0] == "if" || ls[0] == "else")
                        ICG.IfExprAnalysis(ls);//if语句分析
                    else if (ls[0] == "for")
                        ICG.ForExprAnalysis(ls);//for语句分析
                }
                break;
            }
            //输出中间代码表
            listView1.Clear();//移除所有的项和列
            listView1.Columns.Add("NO.", 72);//添加列表头 “列表头名字”，宽度
            listView1.Columns.Add("op", 72);
            listView1.Columns.Add("arg1", 72);
            listView1.Columns.Add("arg2", 72);
            listView1.Columns.Add("result", 72);

            for (int u = 0; u < InterCodeGenratn.InterCodeTable.Count; u++)//输出
            {
                ListViewItem lvi = new ListViewItem();//以下为输出
                lvi.Text = (u + 1).ToString();//四元式编号
                lvi.SubItems.Add(InterCodeGenratn.InterCodeTable[u][0]);
                lvi.SubItems.Add(InterCodeGenratn.InterCodeTable[u][1]);
                lvi.SubItems.Add(InterCodeGenratn.InterCodeTable[u][2]);
                lvi.SubItems.Add(InterCodeGenratn.InterCodeTable[u][3]);
                listView1.Items.Add(lvi);
            }

            //输出SymbolTable
            listView2.Clear();//移除所有的项和列
            listView2.Columns.Add("入口 ", 42);//添加列表头 “列表头名字”，宽度
            listView2.Columns.Add("单词名字", 62);
            listView2.Columns.Add("长度", 40);
            listView2.Columns.Add("类型", 53);
            listView2.Columns.Add("种属", 62);
            listView2.Columns.Add("值", 53);
            listView2.Columns.Add("内存地址", 62);

            foreach (List<string> ls in LexcicalAnalsis.SymbolTable)//输出
            {
                ListViewItem lvi = new ListViewItem();//以下为输出
                lvi.Text = ls[0];
                lvi.SubItems.Add(ls[1]);
                lvi.SubItems.Add(ls[2]);
                lvi.SubItems.Add(ls[3]);
                lvi.SubItems.Add(ls[4]);
                lvi.SubItems.Add(ls[5]);
                lvi.SubItems.Add(ls[6]);
                listView2.Items.Add(lvi);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LexcicalAnalsis.SymbolTable.Clear();
            InterCodeGenratn.InterCodeTable.Clear();
        }
    }
}
