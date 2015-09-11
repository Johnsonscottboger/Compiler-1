using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace compiler
{
    public partial class NDMFA : Form
    {
        public NDMFA()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        string filename = "";
        private void btnTonfa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxRegex.Text))
            {
                MessageBox.Show("请输入正规式", "找不到正规式", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                string[] AddToListView = new string[3];
                Reg_nfa rn = new Reg_nfa();
                Queue<compiler.Reg_nfa.NFAM> ResultQueue = rn.StartTransform(tbxRegex.Text.Trim());
                if (ResultQueue == null)
                {
                    MessageBox.Show("请输入正确的正规式", "不正确的正规式", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                listResult.Items.Clear();
                string strNfa = "";
                int n = ResultQueue.Count;
                for (; i < n; i++)
                {
                    Reg_nfa.NFAM nfa = ((compiler.Reg_nfa.NFAM)ResultQueue.Dequeue());
                    AddToListView[0] = nfa.startstatus.ToString();
                    AddToListView[1] = nfa.varch.ToString();
                    AddToListView[2] = nfa.endstatus.ToString();
                    strNfa += AddToListView[0] + "\t" + AddToListView[1] + "\t" + AddToListView[2] + "\n";
                    ListViewItem item = new ListViewItem(AddToListView);
                    listResult.Items.Add(item);
                }
                int[] StartEndNode = rn.GetStartEndNode();
                this.lblStartNode.Text = StartEndNode[0].ToString();
                this.lblEndNode.Text = StartEndNode[1].ToString();
                strNfa += this.lblStartNode.Text + "\t" + this.lblEndNode.Text;
                if (filename != "")
                {
                    string savefile = filename.Substring(0, filename.LastIndexOf('.')) + ".NFAN";
                    System.IO.File.WriteAllText(savefile, strNfa);
                }
                else
                {
                    string savefile = Application.StartupPath + "\\未命名.NFAN";
                    System.IO.File.WriteAllText(savefile, strNfa);
                }
            }
        }

        private void RegToNfa_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReadTXT_Click(object sender, EventArgs e)
        {
            ofd.InitialDirectory = Application.StartupPath + "/";
            ofd.Filter = "正规式文件|*.RS|文本文件|*.txt";
            ofd.FileName = "";
            if (ofd.ShowDialog() == DialogResult.OK)
                if (ofd.FileName != "")
                {
                    this.tbxRegex.Text = System.IO.File.ReadAllText(ofd.FileName);
                    filename = ofd.FileName;
                }
        }

        private void btnReadnfafile_Click(object sender, EventArgs e)
        {
            string str = "";
            string[] nfa = new string[3];
            ofd.InitialDirectory = Application.StartupPath + "/";
            ofd.Filter = "NFA_N文件|*.NFAN";
            ofd.FileName = "";
            if (ofd.ShowDialog() == DialogResult.OK)
                if (ofd.FileName != "")
                {
                    str = System.IO.File.ReadAllText(ofd.FileName);
                    //str = "0\tε\t1\n1\ta\t1\n1\tb\t1\n2\ta\t3\n2\tb\t4\n3\ta\t5\n4\tb\t5\n5\tε\t6\n6\ta\t6\n6\tb\t6\n6\tε\t7\n0\t7";
                    listResult.Items.Clear();
                    string[] strnfa = str.Split('\n');
                    for (int i = 0; i < strnfa.Length - 1; i++)
                    {
                        nfa = strnfa[i].Split('\t');
                        ListViewItem item = new ListViewItem(nfa);
                        listResult.Items.Add(item);
                    }
                    this.lblStartNode.Text = str.Substring(str.LastIndexOf('\n') + 1, str.LastIndexOf('\t') - str.LastIndexOf('\n'));
                    this.lblEndNode.Text = str.Substring(str.LastIndexOf('\t'));
                }
        }

        private void RegToNfa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Control)
            {
                e.Handled = true;
                btnReadTXT.PerformClick();
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                e.Handled = true;
                btnReadnfafile.PerformClick();
            }
            if (e.KeyCode == Keys.T && e.Control)
            {
                e.Handled = true;
                btnTonfa.PerformClick();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            lstDfa.Items.Clear();
            NFA.NFAM[] Nfam = new NFA.NFAM[listResult.Items.Count];
            NFA.NFAM Nfa = new NFA.NFAM();
            string Dfad = "";
            List<DFAD.DFA> Result = new List<DFAD.DFA>();
            if (listResult.Items.Count > 0)
            {
                for (int i = 0; i < listResult.Items.Count; i++)
                {
                    Nfa.startstatus = Convert.ToInt16(listResult.Items[i].SubItems[0].Text.Trim());
                    Nfa.varch = Convert.ToChar(listResult.Items[i].SubItems[1].Text.Trim());
                    Nfa.endstatus = Convert.ToInt16(listResult.Items[i].SubItems[2].Text);
                    Nfam[i] = Nfa;//得到所有的nfa组成的数组
                }
                NFANtoNFAD nnn = new NFANtoNFAD();
                Result = nnn.Transfrom(Nfam, lblStartNode.Text, lblEndNode.Text);

                lblStarts.Text = nnn.GetStartEndsNode(lblStartNode.Text, lblEndNode.Text)[0];

                lblStarts.Text = lblStarts.Text.Substring(0, lblStarts.Text.Length - 1);
                lblEnds.Text = nnn.GetStartEndsNode(lblStartNode.Text, lblEndNode.Text)[1];
                lblEnds.Text = lblEnds.Text.Substring(0, lblEnds.Text.Length - 1);
                for (int i = 0; i < Result.Count; i++)
                {
                    string[] str = new string[3];
                    str[0] = Result[i].From.ToString();
                    str[1] = Result[i].Varch.ToString();
                    str[2] = Result[i].To.ToString();
                    if (str[2] != "-1")
                    {
                    ListViewItem item = new ListViewItem(str);
                    lstDfa.Items.Add(item);
                    Dfad += str[0] + "\t" + str[1] + "\t" + str[2] + "\n";
                    }
                }
                Dfad += lblStarts.Text + "\t" + lblEnds.Text + "\t";
                for (int i = 0; i < nnn.getaaaa().Count; i++)
                {
                    Dfad += nnn.getaaaa()[i].ToString() + ",";
                }
                if (filename != "")
                {
                    string savefile = filename.Substring(0, filename.LastIndexOf('.')) + ".DFAD";
                    System.IO.File.WriteAllText(savefile, Dfad);
                }
                else
                {
                    string savefile = Application.StartupPath + "\\未命名.DFAD";
                    System.IO.File.WriteAllText(savefile, Dfad);
                }

            }
            else
            {
                MessageBox.Show("请先读取NFAN文件或者输入正规式得到NFAN文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadDFAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath + "\\";
            ofd.Filter = "DFAD文件|*.DFAD";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName != null && ofd.FileName != "")
                {
                    lstDfa.Items.Clear();
                    filename = ofd.FileName;
                    ReadDFAD(filename);
                }
            }
        }
        string strState = "";
        private void ReadDFAD(string filename)
        {
            if (filename!="")
            {
                string strDFAD = System.IO.File.ReadAllText(filename);
                string[] strsDFAD = strDFAD.Split('\n');
                for (int i = 0; i < strsDFAD.Length - 1; i++)
                {
                    string[] DFAD = strsDFAD[i].Split('\t');
                    if (DFAD[2] != "-1")
                    {
                        ListViewItem item = new ListViewItem(DFAD);
                        lstDfa.Items.Add(item);
                    }
                }
                lblStarts.Text = strsDFAD[strsDFAD.Length - 1].Split('\t')[0].ToString();
                lblEnds.Text = strsDFAD[strsDFAD.Length - 1].Split('\t')[1].ToString();
                strState = strsDFAD[strsDFAD.Length - 1].Split('\t')[2].ToString();
            }
            
        }

        private void btnDFADtoDFAM_Click(object sender, EventArgs e)
        {
            lvDFAN.Items.Clear();
            List<DFAD.DFA> list = new List<DFAD.DFA>();
            DFAD.DFA dfa = new DFAD.DFA();
            for (int i = 0; i < lstDfa.Items.Count; i++)
            {
                dfa.From = Convert.ToInt16(lstDfa.Items[i].SubItems[0].Text);
                dfa.Varch = Convert.ToChar(lstDfa.Items[i].SubItems[1].Text);
                dfa.To = Convert.ToInt16(lstDfa.Items[i].SubItems[2].Text);
                list.Add(dfa);
            }
            DFAD.DFA[] dfad = new DFAD.DFA[list.Count];
            list.CopyTo(dfad);
            List<DFAD.DFA> result = new List<DFAD.DFA>();
            DfaMinClass dmc = new DfaMinClass();
            result=dmc.DMC(dfad, lblStarts.Text, lblEnds.Text, strState);
            string[] aa = new string[3];
            for (int i = 0; i < result.Count; i++)
            {
                aa[0] = result[i].From.ToString();
                aa[1] = result[i].Varch.ToString();
                aa[2] = result[i].To.ToString();
                ListViewItem item = new ListViewItem(aa);
                lvDFAN.Items.Add(item);
            }
        }
    }
}
