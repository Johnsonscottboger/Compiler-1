using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
namespace Compiler
{
    public partial class Complier : Form
    {
        public Complier()
        {
            InitializeComponent();
        }
        string txtSourceCode = null;
        string txtSourceCodeModified = null;
        OpaFile of = new OpaFile();
        public void showlines()
        {
            int row, col = 1;
            string text = tbx_sourcecode.Text.Substring(0, tbx_sourcecode.SelectionStart);
            string[] lines = text.Split('\n');
            row = lines.Length;
            if (lines.Length - 1 >= 0)
                col = lines[lines.Length - 1].Length + 1;
            linescols.Text = "行 " + row + " 列 " + col;
        }

        private void timer_lines_Tick(object sender, EventArgs e)
        {
            showlines();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            of.IsOpen = true;
            of.IsModifid = false;
            tbx_sourcecode.Text = of.OpenFile();
            txtSourceCode = tbx_sourcecode.Text;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            of.SaveFile(tbx_sourcecode.Text);
            of.IsModifid = false;
            txtSourceCode = tbx_sourcecode.Text;
        }

        private void SaveFileAs_Click(object sender, EventArgs e)
        {
            of.SaveFileAs(tbx_sourcecode.Text);
            of.IsModifid = false;
            txtSourceCode = tbx_sourcecode.Text;
        }

        private void Tool_Open_Click(object sender, EventArgs e)
        {
            of.IsOpen = true;
            of.IsModifid = false;
            tbx_sourcecode.Text = of.OpenFile();
            txtSourceCode = tbx_sourcecode.Text;
        }

        private void Tool_Save_Click(object sender, EventArgs e)
        {
            of.SaveFile(tbx_sourcecode.Text);
            of.IsModifid = false;
            txtSourceCode = tbx_sourcecode.Text;
        }

        private void Menu_Wordany_Click(object sender, EventArgs e)
        {
            if (tbx_sourcecode.Text != "")
            {
                #region
                lst_error.Items.Clear();
                lst_output.Items.Clear();
                lst_table.Items.Clear();
                string txtsave = "";
                WordAnalysis wa = new WordAnalysis();
                List<string> wordslist = new List<string>();
                wordslist = wa.Analysis(tbx_sourcecode.Text + " ");
                bool isrepeat = false;
                for (int i = 0; i < wordslist.Count; i++)
                {
                    string[] lstWords = { wordslist[i], wa.sort(wordslist[i]).ToString(), wa.Get_Lines_Cols()[i] };
                    txtsave = txtsave + lstWords[0] + "\t" + lstWords[1] + "\r\n";
                    ListViewItem lstvi = new ListViewItem(lstWords);
                    lst_output.Items.Add(lstvi);
                    if (wa.sort(wordslist[i]) == 34 || wa.sort(wordslist[i]) == 20 || wa.sort(wordslist[i]) == 19 || wa.sort(wordslist[i]) == 35 || wa.sort(wordslist[i]) == 36 || wa.sort(wordslist[i]) == 37)
                    {
                        for (int j = 0; j < lst_table.Items.Count; j++)
                        {
                            if (lst_table.Items[j].SubItems[1].Text != wordslist[i])
                            {
                                isrepeat = false;
                                continue;
                            }
                            else
                            {
                                isrepeat = true;
                                break;
                            }
                        }
                        if (!isrepeat)
                        {
                            string[] table = new string[7];
                            table[0] = (lst_table.Items.Count + 1).ToString();
                            table[1] = wordslist[i];
                            table[2] = wordslist[i].Length.ToString();
                            table[3] = "";
                            switch (wa.sort(wordslist[i]))
                            {
                                case 34:
                                    table[4] = "简单变量";
                                    break;
                                case 20:
                                    table[4] = "布尔常数";
                                    break;
                                case 19:
                                    table[4] = "布尔常数";
                                    break;
                                case 35:
                                    table[4] = "整常数";
                                    break;
                                case 36:
                                    table[4] = "实常数";
                                    break;
                                case 37:
                                    table[4] = "字符常量";
                                    break;
                            }
                            table[5] = "未知";
                            table[6] = "未知";
                            ListViewItem item = new ListViewItem(table);
                            lst_table.Items.Add(item);
                        }
                    }
                }
                foreach (string error in wa.Get_Errors())
                {
                    string[] errorinfo = error.Split(',');
                    errorinfo[1] = (Convert.ToInt16(errorinfo[1]) + 1).ToString();
                    ListViewItem item = new ListViewItem(errorinfo);
                    lst_error.Items.Add(item);

                }
                #endregion

                System.IO.File.WriteAllText(Application.StartupPath +"\\output.token", txtsave);
                
            }
            else
            {
                MessageBox.Show("没有输入源代码", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WordAny_Click(object sender, EventArgs e)
        {

        }

        private void tbx_sourcecode_TextChanged(object sender, EventArgs e)
        {
            txtSourceCodeModified = tbx_sourcecode.Text;
            if (txtSourceCode == txtSourceCodeModified)
            {
                of.IsModifid = false;
            }
            else
            {
                of.IsModifid = true;
            }
            if (tbx_sourcecode.Text != "")
            {
                SetTxtColor(tbx_sourcecode.Text);
                string[] s = tbx_sourcecode.Text.Split('\n');
                int n = 0;
                int index = this.tbx_sourcecode.SelectionStart;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].StartsWith("/*") || s[i].EndsWith("*/") || s[i].StartsWith("*"))
                    {
                        n=tbx_sourcecode.GetFirstCharIndexFromLine(i);
                        tbx_sourcecode.Select(n, s[i].Length);
                        tbx_sourcecode.SelectionColor = Color.SlateGray;
                        this.tbx_sourcecode.Select(index, 0);
                    }
                }
            }
            MyPictureBox.Invalidate();
        }
        private void SetTxtColor(string str)
        {
            
            string[] keystr = { "program", "var", "integer", "bool", "real", "char", "const", "begin", "if", "then", "else", "while", "do", "for", "to", "end", "read", "write", "true", "false", "not", "and", "or" };
            
            int index = this.tbx_sourcecode.SelectionStart;    //记录修改的位置

            this.tbx_sourcecode.SelectAll();

            this.tbx_sourcecode.SelectionColor = Color.Black;

            

            for (int i = 0; i < keystr.Length; i++)

                this.getbunch(keystr[i], this.tbx_sourcecode.Text);

            this.tbx_sourcecode.Select(index, 0);     //返回修改的位置

            this.tbx_sourcecode.SelectionColor = Color.Black;

         }
        public int getbunch(string p, string s) //给关键字上色

        {

            int cnt = 0; int M = p.Length; int N = s.Length;

            char[] ss = s.ToCharArray(), pp = p.ToCharArray();

            if (M > N) return 0;

            for (int i = 0; i < N - M + 1; i++)

            {

                int j;

                for (j = 0; j < M; j++)

                {

                    if (ss[i + j] != pp[j]) break;

                 }

                if (j == p.Length)

               {

                    this.tbx_sourcecode.Select(i, p.Length);

                    this.tbx_sourcecode.SelectionColor = Color.Blue;

                     cnt++;

                 }

             }

            return cnt;

         }      
        private void Complier_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtSourceCodeModified = tbx_sourcecode.Text;
            if (txtSourceCode == txtSourceCodeModified)
            {
                of.IsModifid = false;
            }
            else
            {
                of.IsModifid = true;
            }
            if (of.IsModifid&&tbx_sourcecode.Text!="")
            {
                if (MessageBox.Show("文件未保存,是否保存文件？", "程序退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    of.SaveFileAs(tbx_sourcecode.Text);
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (of.IsModifid)
            {
                if (MessageBox.Show("保存文件？", "关闭提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    of.SaveFile(tbx_sourcecode.Text);
                    Application.Exit();
                }
                else
                {
                }
            }
            else
            {
                Application.Exit();
            }
        }
        internal void DrawRichTextBoxLineNumbers(Graphics g)
        {
            int font_height = tbx_sourcecode.GetPositionFromCharIndex(tbx_sourcecode.GetFirstCharIndexFromLine(1)).Y - tbx_sourcecode.GetPositionFromCharIndex(tbx_sourcecode.GetFirstCharIndexFromLine(0)).Y;
            //if (font_height == 0) return;

            int firstIndex = tbx_sourcecode.GetCharIndexFromPosition(new Point(0, (int)g.VisibleClipBounds.Y + (int)font_height / 3));
            int firstLine = tbx_sourcecode.GetLineFromCharIndex(firstIndex);
            int firstLineY = tbx_sourcecode.GetPositionFromCharIndex(firstIndex).Y;

            g.Clear(Color.White);
            int i = firstLine;
            int y = 0;
            if (this.tbx_sourcecode.Lines.Length == 0)
            {
                y = firstLineY + 2 + font_height * (i - firstLine - 1);
                g.DrawString(1.ToString(), tbx_sourcecode.Font, Brushes.DarkBlue, MyPictureBox.Width - g.MeasureString((i).ToString(), tbx_sourcecode.Font).Width, y);
                return;
            }
            int actualHeight = tbx_sourcecode.GetPositionFromCharIndex(tbx_sourcecode.GetFirstCharIndexFromLine(tbx_sourcecode.Lines.Length - 1)).Y;
            while (y < (g.VisibleClipBounds.Height < actualHeight ? g.VisibleClipBounds.Height : actualHeight))
            {
                i += 1;
                y = firstLineY + 2 + font_height * (i - firstLine - 1);
                g.DrawString((i).ToString(), tbx_sourcecode.Font, Brushes.DarkBlue, MyPictureBox.Width - g.MeasureString((i).ToString(), tbx_sourcecode.Font).Width, y);
            }
            g.DrawLine(new Pen(DefaultBackColor), MyPictureBox.Location.X + MyPictureBox.Width - 4, firstLineY, MyPictureBox.Location.X + MyPictureBox.Width - 4, MyPictureBox.Location.Y + MyPictureBox.Height);
        }
        private void MyPictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawRichTextBoxLineNumbers(e.Graphics);
        }

        private void tbx_sourcecode_VScroll(object sender, EventArgs e)
        {
            MyPictureBox.Invalidate();
        }

        private void tbx_sourcecode_Resize(object sender, EventArgs e)
        {
            MyPictureBox.Invalidate();
        }
       

        private void Menu_RegularToNfa_Click(object sender, EventArgs e)
        {
            RegToNfa rtn = new RegToNfa();
            rtn.ShowDialog();
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (splitContainer2.SplitterDistance != splitContainer2.Height - 25)
            {
                splitContainer2.SplitterDistance = splitContainer2.Height - 25;
                btn_up.Text = "△";
                this.MyPictureBox.Height = this.tbx_sourcecode.Height;
            }
            else
            {
                splitContainer2.SplitterDistance = 2 * splitContainer2.Height / 3;
                btn_up.Text = "▽";
                this.MyPictureBox.Height = this.tbx_sourcecode.Height;
            }
        }

        private void Complier_Load(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 25;
            lst_output.Columns[0].Width = lst_output.Width / 3;
            lst_output.Columns[1].Width = lst_output.Width / 3;
            lst_output.Columns[2].Width = lst_output.Width - lst_output.Columns[0].Width - lst_output.Columns[1].Width;
            this.MyPictureBox.Height = this.tbx_sourcecode.Height;
            this.MyPictureBox.Top = 0;
            this.MyPictureBox.Left = 0;
            this.MyPictureBox.BackColor = Color.Gray;
            this.MyPictureBox.Cursor = Cursors.Default;
            this.tbx_sourcecode.Controls.Add(this.MyPictureBox);
            this.tbx_sourcecode.SelectionIndent = 35;
        }
        private void Complier_Resize(object sender, EventArgs e)
        {
            lst_output.Columns[0].Width = lst_output.Width / 3;
            lst_output.Columns[1].Width = lst_output.Width / 3;
            lst_output.Columns[2].Width = lst_output.Width - lst_output.Columns[0].Width - lst_output.Columns[1].Width;
            this.MyPictureBox.Height = this.tbx_sourcecode.Height;
        }

        private void fontMenu_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                tbx_sourcecode.Font = fontDlg.Font;
            }
        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Copy();
        }

        private void textMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Clipboard.GetText() == "")
            {
                pasteMenu.Enabled = false;
            }
            else
            {
                pasteMenu.Enabled = true;
            }
        }

        private void cutMenu_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Cut();
        }

        private void pasteMenu_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Paste();
        }

        private void lst_error_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = tbx_sourcecode.Text.IndexOf(lst_error.SelectedItems[0].SubItems[3].Text);
            tbx_sourcecode.Select(index, lst_error.SelectedItems[0].SubItems[3].Text.Length);
        }

        private void Tool_Cut_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Cut();
        }

        private void Tool_Copy_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Copy();
        }

        private void Tool_Paste_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Paste();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            tbx_sourcecode.Undo();
        }

        private void tbx_sourcecode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Menu_NfaToDfa_Click(object sender, EventArgs e)
        {
            RegToNfa rtn = new RegToNfa();
            rtn.ShowDialog();
        }

        private void Menu_MinDfa_Click(object sender, EventArgs e)
        {
            DFAmin dfamin = new DFAmin();
            dfamin.ShowDialog();
        }

       

    }
}
