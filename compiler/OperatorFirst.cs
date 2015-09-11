using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace compiler
{

    public partial class OperatorFirst : Form
    {
        public OperatorFirst()
        {
            InitializeComponent();
        }
        List<char> VT = new List<char>();//终结符
        List<char> VN = new List<char>();//非终结符
        List<string> produ = new List<string>();//预处理后的所有句子
        List<string> grammer = new List<string>();
        Dictionary<char, List<char>> FirstVT = new Dictionary<char, List<char>>();
        Dictionary<char, List<string>> list = new Dictionary<char, List<string>>();
        Dictionary<char, List<char>> LastVT = new Dictionary<char, List<char>>();
        List<string> Spon = new List<string>();
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
        private void Production()
        {
            VN.Clear();
            VT.Clear();
            grammer.Clear();
            produ.Clear();
            string sponser = rtbText.Text;
            string str = "";
            for (int i = 0; i < sponser.Length; i++)
            {
                if (sponser[i] != '\n')
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
                    if (VN[i] == item[0])
                    {
                        hxs.Add(item.Substring(3));
                    }
                }
                list.Add(VN[i], hxs);
            }
            foreach (var item in produ)
            {
                string st = "";
                for (int i = 0; i < item.Substring(3).Length; i++)
                {
                    if (isVN(item.Substring(3)[i]))
                    {
                        st += 'F';
                    }
                    else
                        st += item.Substring(3)[i];
                }
                Spon.Add(st);
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rtbText.Text == "")
            {
                MessageBox.Show("尚无文法！");
            }
            else
                Production();
        }

        private List<char> getFirstVT(char vn)
        {
            int i;
            List<char> firstVT = new List<char>();
            for (i = 0; i < produ.Count; i++)
            {
                if (produ[i][0] == vn)
                {


                    if (isVN(produ[i][3]) && produ[i].Length == 4)//P->Q型
                    {
                        List<char> temp = getFirstVT(produ[i][3]);
                        foreach (var item in temp)
                        {
                            if (!firstVT.Contains(item))
                            {
                                firstVT.Add(item);
                            }
                        }
                    }
                    else
                    {
                        if (produ[i][3] < 'A' || produ[i][3] > 'Z')//P->a...型
                        {
                            if (!firstVT.Contains(produ[i][3]))
                            {
                                firstVT.Add(produ[i][3]);
                            }
                        }
                        else if (produ[i][4] < 'A' || produ[i][4] > 'Z')//P->Qa...型
                        {
                            if (!firstVT.Contains(produ[i][4]))
                            {
                                firstVT.Add(produ[i][4]);
                            }
                        }
                    }
                }
            }
            return firstVT;
        }
        private List<char> getLastVT(char vn)
        {
            int i;
            List<char> lastVT = new List<char>();
            for (i = 0; i < produ.Count; i++)
            {
                if (produ[i][0] == vn)
                {
                    int length = produ[i].Length;
                    if (isVN(produ[i][3]) && produ[i].Length == 4)//P->Q型
                    {
                        List<char> temp = getLastVT(produ[i][3]);
                        foreach (var item in temp)
                        {
                            if (!lastVT.Contains(item))
                            {
                                lastVT.Add(item);
                            }
                        }
                    }
                    else
                    {
                        if (produ[i][length - 1] < 'A' || produ[i][length - 1] > 'Z')//P->...a型
                        {
                            if (!lastVT.Contains(produ[i][length - 1]))
                            {
                                lastVT.Add(produ[i][length - 1]);
                            }
                        }
                        else if (produ[i][length - 2] < 'A' || produ[i][length - 2] > 'Z')//P->...aQ型
                        {
                            if (!lastVT.Contains(produ[i][length - 2]))
                            {
                                lastVT.Add(produ[i][length - 2]);
                            }
                        }
                    }
                }
            }
            return lastVT;
        }
        private void btnFirstVT_Click(object sender, EventArgs e)
        {
            listViewFirst.Clear();
            listViewFirst.Columns.Add("FirstVT");
            for (int i = 0; i < VT.Count; i++)
                listViewFirst.Columns.Add(VT[i].ToString());
            for (int i = 0; i < VN.Count; i++)
                listViewFirst.Items.Add(new ListViewItem(new string[] { VN[i].ToString(), "", "", "", "", "", "", "", "" }));
            foreach (var vn in VN)
            {
                FirstVT.Add(vn, getFirstVT(vn));
            }
            foreach (var key in FirstVT.Keys)
            {
                for (int i = 0; i < VN.Count; i++)
                {
                    if (key == VN[i])
                    {
                        for (int j = 0; j < VT.Count; j++)
                        {
                            if (FirstVT[key].Contains(VT[j]))
                            {
                                listViewFirst.Items[i].SubItems[j + 1].Text = "1";
                            }
                        }
                    }
                }
            }

        }

        private void btnLastVT_Click(object sender, EventArgs e)
        {
            listViewLast.Clear();
            listViewLast.Columns.Add("LastVT");
            for (int i = 0; i < VT.Count; i++)
                listViewLast.Columns.Add(VT[i].ToString());
            for (int i = 0; i < VN.Count; i++)
                listViewLast.Items.Add(new ListViewItem(new string[] { VN[i].ToString(), "", "", "", "", "", "", "", "" }));
            foreach (var vn in VN)
            {
                LastVT.Add(vn, getLastVT(vn));
            }
            foreach (var key in LastVT.Keys)
            {
                for (int i = 0; i < VN.Count; i++)
                {
                    if (key == VN[i])
                    {
                        for (int j = 0; j < VT.Count; j++)
                        {
                            if (LastVT[key].Contains(VT[j]))
                            {
                                listViewLast.Items[i].SubItems[j + 1].Text = "1";
                            }
                        }
                    }
                }
            }

        }

        private void btnAnaly_Click(object sender, EventArgs e)
        {
            listViewTable.Clear();
            listViewTable.Columns.Add("优先表");
            List<string> p = new List<string>();
            foreach (var item in produ)
            {
                p.Add(item + '\0');
            }
            p.Add("S->#" + produ[0][0] + "#" + '\0');
            List<char> Vt = new List<char>();
            Vt = VT;
            Vt.Add('#');
            for (int i = 0; i < Vt.Count; i++)
            {
                listViewTable.Columns.Add(Vt[i].ToString());
                listViewTable.Items.Add(new ListViewItem(new string[] { Vt[i].ToString(), "", "", "", "", "", "", "", "" }));
            }
            for (int i = 0; i < p.Count; i++)
            {
                int j = 3;
                while (p[i][j] != '\0')
                {
                    if (!isVN(p[i][j]) && !isVN(p[i][j + 1]) && p[i][j + 1] != '\0')//P->..ab..
                    {
                        for (int m = 0; m < Vt.Count; m++)
                        {
                            for (int n = 0; n < Vt.Count; n++)
                            {
                                if (Vt[m] == p[i][j] && Vt[n] == p[i][j + 1])
                                {
                                    listViewTable.Items[m].SubItems[n + 1].Text = "=";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!isVN(p[i][j]) && isVN(p[i][j + 1]) && !isVN(p[i][j + 2]) && p[i][j + 2] != '\0')//P->..aQb..
                        {
                            for (int m = 0; m < Vt.Count; m++)
                            {
                                for (int n = 0; n < Vt.Count; n++)
                                {
                                    if (Vt[m] == p[i][j] && Vt[n] == p[i][j + 2])
                                    {
                                        listViewTable.Items[m].SubItems[n + 1].Text = "=";
                                    }
                                }
                            }
                        }
                        if (!isVN(p[i][j]) && isVN(p[i][j + 1]))//P->..aQ..
                        {
                            for (int m = 0; m < Vt.Count; m++)
                            {
                                for (int n = 0; n < Vt.Count; n++)
                                {
                                    foreach (var item in FirstVT[p[i][j + 1]])
                                    {
                                        if (Vt[m] == p[i][j] && Vt[n] == item)
                                        {
                                            listViewTable.Items[m].SubItems[n + 1].Text = "<";
                                        }
                                    }
                                }
                            }
                        }
                        if (isVN(p[i][j]) && !isVN(p[i][j + 1]) && p[i][j + 1] != '\0')//P->..Qa..
                        {
                            for (int m = 0; m < Vt.Count; m++)
                            {
                                for (int n = 0; n < Vt.Count; n++)
                                {
                                    foreach (var item in LastVT[p[i][j]])
                                    {
                                        if (Vt[m] == item && Vt[n] == p[i][j + 1])
                                        {
                                            listViewTable.Items[m].SubItems[n + 1].Text = ">";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    j++;
                }
            }
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
        private string SearchTable(char a, char b)
        {
            string str = "";
            for (int i = 0; i < VT.Count; i++)
            {
                for (int j = 0; j < VT.Count; j++)
                {
                    if (VT[i] == a && VT[j] == b)
                    {
                        str = listViewTable.Items[i].SubItems[j + 1].Text;
                    }
                }
            }
            return str;
        }
        private void btnAn_Click(object sender, EventArgs e)
        {
            Analysis();

        }
        public string print(char[] s)
        {
            string str = "";
            for (int i = 1; i <100; i++)
            {
                str += s[i];
            }
            return str;
        }
        private void Analysis()
        {
            int i, j, top;
            char a; int step = 1;
            i = 0; top = 1;
            char[] s = new char[100]; char q;
            s[top] = '#';
            string input = tbSen.Text.Trim() + "#";
            ListViewItem lv = new ListViewItem();
            lv.Text = (step).ToString();
            lv.SubItems.Add(print(s));
            lv.SubItems.Add(input);
            lv.SubItems.Add("初始状态");
            listView.Items.Add(lv);
            while ((a = input[i]) != '#')
            {
                if (isVT(s[top]))
                {
                    j = top;
                }
                else j = top - 1;
                string opt = SearchTable(s[j], a);
                if (opt == "<" || opt == "=")
                {
                    top = top + 1;
                    s[top] = a;
                    input = input.Substring(1);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (++step).ToString();
                    lvi.SubItems.Add(print(s));
                    lvi.SubItems.Add(input);
                    lvi.SubItems.Add("移进");
                    listView.Items.Add(lvi);
                }
                else
                {
                    if (opt == ">")
                    {
                        char N = ' ';
                        do
                        {
                            q = s[j];
                            if (isVT(s[j - 1]))
                            {
                                j = j - 1;
                            }
                            else j = j - 2;
                        } while (SearchTable(s[j], q) != "<");
                        int m; string temp = "";
                        for (m = j + 1; m <= top; m++)
                        {
                            temp += s[m];
                        }
                        foreach (var key in list.Keys)
                        {
                            foreach (var item in list[key])
                            {
                                if (item.Equals(temp))
                                {
                                    N = key;
                                }
                            }
                        }
                        top = j + 1;
                        s[top] = N;
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (++step).ToString();
                        lvi.SubItems.Add(print(s));
                        lvi.SubItems.Add(input);
                        lvi.SubItems.Add("规约");
                        listView.Items.Add(lvi);
                        if (top == 2 && a == '#')
                        {
                            ListViewItem l = new ListViewItem();
                            l.Text = (step + 1).ToString();
                            l.SubItems.Add(print(s));
                            l.SubItems.Add(input);
                            l.SubItems.Add("成功");
                            listView.Items.Add(l);
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                        break; 
                    }
                } 
            }
            while (input == "#")
            {
                if (isVT(s[top]))
                {
                    j = top;
                }
                else j = top - 1;
                string opt = SearchTable(s[j], '#');
                
                if (opt == ">")
                {
                    char N = ' ';
                    do
                    {
                        q = s[j];
                        if (isVT(s[j - 1]))
                        {
                            j = j - 1;
                        }
                        else j = j - 2;
                    } while (SearchTable(s[j], q) != "<");
                    int m; string temp = "";
                    for (m = j + 1; m <= top; m++)
                    {
                        temp += s[m];
                    }
                    foreach (var item in Spon)
                    {
                        if (item == temp)
                        {
                            N = 'F';
                        }
                    }
                    top = j + 1;
                    s[top] = N;
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (++step).ToString();
                    lvi.SubItems.Add(print(s));
                    lvi.SubItems.Add(input);
                    lvi.SubItems.Add("规约");
                    listView.Items.Add(lvi);
                    if (top == 2)
                    {
                        ListViewItem l = new ListViewItem();
                        l.Text = (step + 1).ToString();
                        l.SubItems.Add(print(s));
                        l.SubItems.Add(input);
                        l.SubItems.Add("成功");
                        listView.Items.Add(l);
                        break;
                    }
                }
                
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Compiler compiler = new Compiler();
            compiler.Show();
            this.Close();
        }

        private void OperatorFirst_Load(object sender, EventArgs e)
        {

        }
    }
}
