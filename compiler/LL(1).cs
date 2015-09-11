using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace compiler
{
    
    public partial class LL_1_ : Form
    {
        public LL_1_()
        {
            InitializeComponent();
        }
        List<char> VT = new List<char>();//终结符
        List<char> VN = new List<char>();//非终结符
        List<string> grammer = new List<string>();
        List<string> produ = new List<string>();
        Dictionary<char, List<string>> First = new Dictionary<char, List<string>>();
        Dictionary<char, List<string>> Follow = new Dictionary<char, List<string>>();
        Dictionary<char, List<string>> list = new Dictionary<char, List<string>>();
        private void LL_1__Load(object sender, EventArgs e)
        {
            listViewFollow.Columns[0].Width = 50;
        }
        
        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            of.FileName = "Test";
            if (of.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(of.FileName, System.Text.Encoding.Default))
                {
                    rtbText.Text = sr.ReadToEnd();
                }
            }
        }
        public bool isVN(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                return true;
            return false;
        }
        public bool isVT(char ch)
        {
            for (int i = 0; i < VT.Count; i++)
                if (ch.CompareTo(VT[i]) == 0)
                    return true;
            return false;
        }
        public bool isExitVN(char ch)
        {
            for (int i = 0; i < VN.Count; i++)
                if (ch.CompareTo(VN[i]) == 0)
                    return true;
            return false;
        }
        public bool isExitVT(char ch)
        {
            for (int i = 0; i < VT.Count; i++)
                if (ch.CompareTo(VT[i]) == 0)
                    return true;
            return false;
        }
        public bool isToEmpty(string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (str[i] == '$')
                    return true;
            return false;
        }
        public string cs(char ch)
        {
            string str = "";
            for (int i = 0; i < grammer.Count; i++)
                if (ch == grammer[i][0])
                    str = grammer[i];
            return str;
        }
        private void Production()
        {
            string sponser = rtbText.Text;
            string str = "";
            for (int i = 0; i < sponser.Length; i++)
            {
                if (sponser[i] != '\n'&&sponser[i]!=' ')
                    str += sponser[i];
                else
                {
                    grammer.Add(str);
                    str = "";
                }
            }
            grammer.Add(str);

            for (int n = 0; n < grammer.Count; n++)
            {
                string temp = "";
                for (int i = 0; i < grammer[n].Length; i++)
                {
                    if (i < grammer[n].IndexOf("->") && isExitVN(grammer[n][i]) == false)
                    {
                        VN.Add(grammer[n][i]);
                    }
                    else if (i == grammer[n].IndexOf("->"))
                    {
                        continue;
                    }
                    else if (i == grammer[n].IndexOf("->") + 1)
                        continue;
                    else if (i > grammer[n].IndexOf("->") && grammer[n][i] != '|')
                    {
                        if (!isVN(grammer[n][i]) && isExitVT(grammer[n][i]) == false)
                        {
                            VT.Add(grammer[n][i]);
                            temp += grammer[n][i];
                        }
                        else temp += grammer[n][i];
                    }
                    else if (grammer[n][i] == '|')
                    {
                        temp = grammer[n][0].ToString() + "->" + temp;
                        produ.Add(temp);
                        temp = "";
                        continue;
                    }
                }
                temp = grammer[n][0].ToString() + "->" + temp;
                produ.Add(temp);
            }
            for (int i = 0; i < VN.Count; i++)
            {
                List<string> hxs = new List<string>();
                foreach (var item in produ)
                {
                    if (VN[i]==item[0])
                    {
                        hxs.Add(item.Substring(3));
                    }
                }
                list.Add(VN[i], hxs);
            }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < VT.Count; i++)
                listViewFirst.Columns.Add(VT[i].ToString());

            for (int i = 0; i < VN.Count; i++)
            {
                First.Add(VN[i],getfirst(VN[i]));
            }
            foreach (var key in First.Keys)
            {
                listViewFirst.Items.Add(new ListViewItem(new string[] { key.ToString(),"","","","","","","","","",""}));
            }
            foreach (var key in First.Keys)
            {
                for (int i = 0; i < VN.Count; i++)
                {
                    if (key==VN[i])
                    {
                        for (int j = 0; j < VT.Count; j++)
                        {
                            if (First[key].Contains(VT[j].ToString()))
                            {
                                listViewFirst.Items[i].SubItems[j+1].Text = "1";
                            }
                        }
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rtbText.Text != "")
            {
                Production();
            }
            else
                MessageBox.Show("尚无文法");
        }
        public int isExist_VT(char ch)
        {
            int j = 0;
            foreach (var t in VT)
            {
                if (t.Equals(ch))
                {
                    j = 1;
                }
            }
            return j;
        }
        public int isExist_VN(char ch)
        {
            int j = 0;
            foreach (var t in VN)
            {
                if (t.Equals(ch))
                {
                    j = 1;
                }
            }
            return j;
        }
        public bool ismatch(char ch)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[^->|A-Z]$");
            return regex.IsMatch(ch.ToString());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Compiler compiler = new Compiler();
            compiler.Show();
            this.Hide();
        }

        private void LL_1__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            List<char> Vt = new List<char>();
            Vt = VT;
            for (int i = 0; i < Vt.Count; i++)
            {
                if (Vt[i] != '$')
                    listViewFollow.Columns.Add(Vt[i].ToString());
                else
                { Vt.RemoveAt(i); i--; }
            }
            Vt.Add('#');
            listViewFollow.Columns.Add("#");

            for (int i = 0; i < VN.Count; i++)
            {
                Follow.Add(VN[i], getfollow(VN[i]));
            }

            foreach (var key in Follow.Keys)
            {
                listViewFollow.Items.Add(new ListViewItem(new string[] { key.ToString(), "", "", "", "", "","","", "", "", "" }));
            }
            foreach (var key in Follow.Keys)
            {
                for (int i = 0; i < VN.Count; i++)
                {
                    if (key == VN[i])
                    {
                        for (int j = 0; j < Vt.Count; j++)
                        {
                            List<string> values = new List<string>();
                            values = Follow[key];
                            foreach (var item in values)
                            {
                                if (item.Equals(VT[j].ToString()))
                                {
                                    listViewFollow.Items[i].SubItems[j + 1].Text = "1";
                                }
                            }
                        }
                    }
                }
            }

        }

        private List<string> getfirst(char vn)
        {
            List<string> first = new List<string>();
            for (int i = 0; i < produ.Count; i++)
            {
                if (vn == produ[i][0])
                {
                    int m = produ[i].IndexOf("->");
                    for (int j = 0; j < produ[i].Length; j++)
                        if (j <= m + 1)
                            continue;
                        else if (isVT(produ[i][j]) && isExitVT(produ[i][j]))
                        {
                            first.Add(produ[i][j].ToString());
                            break;
                        }
                        else if (isVN(produ[i][j]))
                            return getfirst(produ[i][j]);
                }
            }
            return first;
        }

        private List<string> getfollow(char vt)
        {
            List<string> follow = new List<string>();

            if (vt == VN[0])                     
            {
                follow.Add("#");
            }
            for (int i = 0; i < produ.Count; i++)
            {
                for (int j = 3; j < produ[i].Length; j++)
                    if (vt == produ[i][j])
                    {
                        if (j != produ[i].Length - 1)
                        {
                            if (isVT(produ[i][j + 1]))
                            {
                                if (produ[i][j + 1] != '$'&&!follow.Contains(produ[i][j+1].ToString()))
                                    follow.Add(produ[i][j + 1].ToString());                          
                            }
                            else if (isVN(produ[i][j + 1]))
                            {
                                List<string>first = getfirst(produ[i][j + 1]);
                                for (int k = 0; k < first.Count; k++)
                                {
                                    if (first[k] != "$" && !follow.Contains(first[k]))
                                        follow.Add(first[k]);
                                }
                                if (isToEmpty(cs(produ[i][j + 1])))
                                {
                                    List<string>temp = getfollow(produ[i][0]);
                                    foreach (var item in temp)
                                    {
                                        follow.Add(item);
                                    }
                                }
                            }
                        }
                        else if (produ[i][produ[i].Length - 1] == vt && produ[i][0] != vt)
                        {
                            List<string> temp = getfollow(produ[i][0]);
                            foreach (var item in temp)
                            {
                                follow.Add(item);
                            }
                            break;
                        }
                    }
                    else continue;
            }
            return follow;
        }
 


        public bool IsMatch(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.
                RegularExpressions.Regex(@"^[\(\)+\-*/a-z][A-Z\)]*$");
            return regex.IsMatch(str);
        }

        private void btnAnaly_Click(object sender, EventArgs e)
        {
            List<char> Vt = new List<char>();
            Vt = VT;
            for (int i = 0; i < Vt.Count; i++)
            {
                if (Vt[i] != '$')
                    listViewAnalysis.Columns.Add(Vt[i].ToString());
                else
                { Vt.RemoveAt(i); i--; }
            }
            foreach (var key in Follow.Keys)
            {
                listViewAnalysis.Items.Add(new ListViewItem(new string[] { key.ToString(), "", "","","", "", "", "", "", "", "" }));
            }
            for (int i = 0; i < VN.Count; i++)
            {
                for (int j = 0; j < Vt.Count; j++)
                {
                    if (First[VN[i]].Contains(Vt[j].ToString()))
                    {
                        List<string> temp = new List<string>();
                        temp = list[VN[i]];
                        foreach (var item in temp)
	                    {
		                    if (item=="$")
	                        {
                                for (int n = 0; n < Vt.Count; n++)
                                {
                                    if (Follow[VN[i]].Contains(Vt[n].ToString()))
                                    {
                                        listViewAnalysis.Items[i].SubItems[n + 1].Text = VN[i] + "->$";
                                    }
                                }
	                        }
                            else
                                listViewAnalysis.Items[i].SubItems[j + 1].Text = VN[i] + "->" + item;
	                    }
                        
                    }
                }
            }
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            Stack<char> s = new Stack<char>();
            Stack<char> input = new Stack<char>();
            char X;
            char a;
            int step = 1;
            s.Push('#');
            if (tbSen.Text!="")
            {
                s.Push(VN[0]);
                string str = tbSen.Text.Trim()+"#";
                for (int i = str.Length-1; i >= 0; i--)
                {
                    input.Push(str[i]);
                }
                for (int i = 0; i < 20; i++)
                {
                    a = input.Peek();
                    X = s.Peek();
                    if (X=='#'&&a=='#')
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (step ++).ToString();
                        lvi.SubItems.Add(PrintStack(s));
                        lvi.SubItems.Add(PrintStackInp(input));
                        lvi.SubItems.Add("接受");
                        listView.Items.Add(lvi);
                        break;
                    }
                    else if (X == a && X != '#')
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (step ++).ToString();
                        lvi.SubItems.Add(PrintStack(s));
                        lvi.SubItems.Add(PrintStackInp(input));
                        lvi.SubItems.Add(X + "匹配");
                        listView.Items.Add(lvi);
                        s.Pop(); input.Pop();
                    }
                    else 
                    {
                        string st = SearchTable(X, a);
                        //if (flag>0)
                        //{
                        //    ListViewItem lvi = new ListViewItem();
                        //        lvi.Text = (step ++).ToString();
                        //        lvi.SubItems.Add(PrintStack(s));
                        //        lvi.SubItems.Add(PrintStackInp(input));
                        //        lvi.SubItems.Add(st);
                        //        listView.Items.Add(lvi);
                        //        flag = 0;
                        //}
                        if (st.Contains("->"))
                        {
                            s.Pop();
                            string hxs = st.Substring(3);
                            if (hxs != "$")
                            {
                                for (int j = hxs.Length - 1; j >= 0; j--)
                                {
                                    s.Push(hxs[j]);
                                }
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = (step++).ToString();
                                lvi.SubItems.Add(PrintStack(s));
                                lvi.SubItems.Add(PrintStackInp(input));
                                lvi.SubItems.Add(st);
                                listView.Items.Add(lvi);
                            }
                            else
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = (step++).ToString();
                                lvi.SubItems.Add(PrintStack(s));
                                lvi.SubItems.Add(PrintStackInp(input));
                                lvi.SubItems.Add(st);
                                listView.Items.Add(lvi);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Error"); break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要分析的句子");
            }
        }
        private string SearchTable(char X, char a)
        {
            string str = "";
            for (int i = 0; i < VN.Count; i++)
            {
                for (int j = 0; j < VT.Count; j++)
                {
                    if (VN[i]==X&&VT[j]==a)
                    {
                        str = listViewAnalysis.Items[i].SubItems[j + 1].Text;
                    }
                }
            }
            return str;
        }
        private string PrintStack(Stack<char> s)
        {
            string str = ""; string str1 = "";
            foreach (var item in s)
            {
                str += item;
            }
            for (int i = str.Length - 1; i >= 0; i--)
            {
                str1 += str[i];
            }
            return str1;
        }
        private string PrintStackInp(Stack<char> s)
        {
            string str = ""; 
            foreach (var item in s)
            {
                str += item;
            }
            return str;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            produ.Clear();
            grammer.Clear();
            list.Clear();
            First.Clear();
            Follow.Clear();
            listViewFirst.Clear();
            listViewFirst.Columns.Add("First");
            listViewFollow.Clear();
            listViewFollow.Columns.Add("Follow");
            listViewAnalysis.Clear();
            listViewAnalysis.Columns.Add("预测表");
            listView.Clear();
            rtbText.Text = "";
            VT.Clear();
            VN.Clear();
            listView.Columns.Add("步骤");
            listView.Columns.Add("分析栈");
            listView.Columns.Add("剩余输入串");
            listView.Columns.Add("推导所用的产生式");
        }

        private void btnStep_Click(object sender, EventArgs e)
        {

        }
    }
    public class sponser
    {
        public char vn;
        public List<string> hxs = new List<string>();
        public List<string> first = new List<string>();
        public List<string> follow = new List<string>();
        public List<char> firstnode = new List<char>();
        public List<char> follownode = new List<char>();
    }
}
