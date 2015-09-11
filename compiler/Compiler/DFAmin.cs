using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compiler
{
    public partial class DFAmin : Form
    {
        public DFAmin()
        {
            InitializeComponent();
        }
        private string filename;
        string strState = "";
        private void DFAmin_Load(object sender, EventArgs e)
        {
            lvDFAD.Width = lvDFAN.Width;
            for (int i = 0; i < lvDFAD.Columns.Count; i++)
            {
                lvDFAD.Columns[i].Width = lvDFAD.Width / 3;
                lvDFAN.Columns[i].Width = lvDFAN.Width / 3;
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
                    lvDFAD.Items.Clear();
                    filename = ofd.FileName;
                    ReadDFAD(filename);
                }
                else
                {

                }
            }
        }
        private void ReadDFAD(string filename)
        {
            string strDFAD = System.IO.File.ReadAllText(filename);
            string[] strsDFAD = strDFAD.Split('\n');
            for (int i = 0; i < strsDFAD.Length - 1; i++)
            {
                string[] DFAD = strsDFAD[i].Split('\t');
                if (DFAD[2] != "-1")
                {
                ListViewItem item = new ListViewItem(DFAD);
                lvDFAD.Items.Add(item);
                }
            }
            lblStarts.Text = strsDFAD[strsDFAD.Length - 1].Split('\t')[0].ToString();
            lblEnds.Text = strsDFAD[strsDFAD.Length - 1].Split('\t')[1].ToString();
            strState = strsDFAD[strsDFAD.Length - 1].Split('\t')[2].ToString();
        }

        private void btnDFADtoDFAM_Click(object sender, EventArgs e)
        {
            List<DFAD.DFA> list = new List<DFAD.DFA>();
            DFAD.DFA dfa = new DFAD.DFA();
            for (int i = 0; i < lvDFAD.Items.Count; i++)
            {
                dfa.From = Convert.ToInt16(lvDFAD.Items[i].SubItems[0].Text);
                dfa.Varch = Convert.ToChar(lvDFAD.Items[i].SubItems[1].Text);
                dfa.To = Convert.ToInt16(lvDFAD.Items[i].SubItems[2].Text);
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
