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
    public partial class LR : Form
    {
        public LR()
        {
            InitializeComponent();
        }
        List<string> grammer = new List<string>();
        List<string> produ = new List<string>();
        Dictionary<char, List<string>> Grammer = new Dictionary<char, List<string>>();
        Dictionary<char, List<string>> project = new Dictionary<char, List<string>>();
        List<char> VT = new List<char>();//终结符
        List<char> VN = new List<char>();//非终结符
        char start = 'S';
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            of.FileName = "LR";
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
        private void Production()
        {
            string sponser = rtbText.Text;
            string str = "";
            for (int i = 0; i < sponser.Length; i++)
            {
                if (sponser[i] != '\n' && sponser[i] != ' ')
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
                Grammer.Add(VN[i], hxs);
            }
            foreach (var key in Grammer.Keys)
            {
                List<string> t = new List<string>();
                foreach (var item in Grammer[key])
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        t.Add(item.Insert(i, "▪"));
                    }
                    t.Add(item + "▪");
                }
                project.Add(key, t);
            }
            VT.Add('#');
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Compiler compiler = new Compiler();
            compiler.Show();
            this.Close();
        }
        private Dictionary<int, LRstate> projectDFA(Dictionary<char, List<string>> project)
        {
            Dictionary<int, LRstate> lr = new Dictionary<int, LRstate>();
            LRstate ls = new LRstate();
            ls.stateNum = 0;
            ls.from = -1;
            ls.input = '#';
            return lr;
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    struct LRstate
    {
        public int stateNum;//状态编号
        public int from;//来源（来自哪个状态）
        public char input;//转换条件（通过哪个字符）
        public List<string>proj;//结点有哪些项目
    }
}
