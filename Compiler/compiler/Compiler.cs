using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace compiler
{
    public partial class Compiler : Form
    {
        public Compiler()
        {
            InitializeComponent();

            txtContent.AllowDrop = true;
            txtContent.DragEnter += new DragEventHandler(txtContent_DragEnter);
            txtContent.DragDrop += new DragEventHandler(txtContent_DragDrop);
        }

        string msgError = "";
        
        private void txtContent_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtContent_DragDrop(object sender, DragEventArgs e)
        {
            Array arrayFileName = (Array)e.Data.GetData(DataFormats.FileDrop);

            string strFileName = arrayFileName.GetValue(0).ToString();

            StreamReader sr = new StreamReader(strFileName, System.Text.Encoding.Default);
            txtContent.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            //j为textbox文本的行数 
            int j = txtContent.GetLineFromCharIndex(txtContent.Text.Length) + 1;
            showRow(j);
        }

        void showRow(int line)
        {
            txtRow.Text = "";
            for (int i = 1; i <= line; i++)
            {
                txtRow.Text += i.ToString() + "\r\n";
            }
            txtRow.TextAlign = HorizontalAlignment.Center;
        }

        private void 工具栏ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (工具栏ToolStripMenuItem1.Checked == true)
            {
                工具栏ToolStripMenuItem1.Checked = false;
                toolStrip1.Hide();
            }
            else if (工具栏ToolStripMenuItem1.Checked == false)
            {
                工具栏ToolStripMenuItem1.Checked = true;
                toolStrip1.Show();
            }
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked == false)
            {
                状态栏ToolStripMenuItem.Checked = true;
                statusStrip1.Show();
            }
            else if (状态栏ToolStripMenuItem.Checked == true)
            {
                状态栏ToolStripMenuItem.Checked = false;
                statusStrip1.Hide();
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            of.Filter = "*.txt|*.txt|所有文件(*.*)|*.*";
            of.FileName = "Test";
            if (of.ShowDialog()==DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(of.FileName))
                {
                    txtContent.Text = sr.ReadToEnd();
                    this.Text = "编译原理算法演示系统--" + Path.GetFullPath(of.FileName);
                    tsbSave.Enabled = true;
                }
            }
            
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtContent.Text != "")
            {
                StreamWriter sw = new StreamWriter(of.FileName);
                sw.WriteLine(txtContent.Text);
                sw.Close();
            }
            else
                MessageBox.Show("当前无可保存内容！");
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "save file";
            saveFile.FileName = "未命名.txt";
            saveFile.Filter = "Text File(*.txt)|*.txt|All File(*.*)|(*.*)";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.WriteLine(txtContent.Text);
                sw.Close();
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 词法分析器AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scanner scan = new Scanner();
            txtMsg.Text = "";
            Scanner.LineNo = 1;
            txtToken.Text = "------------------token表信息...-----------------" + "\r\n\r\n" + "行" + "\t" + "单词" + "\t\t" + "种别码" + "\r\n";
            string str = txtContent.Text + '\0';
            txtMsg.Text = "---------------词法分析信息...---------------" + "\r\n\r\n";
            scan.scanner(str);
            scan.write_token();
            scan.write_sym();

            try
            {
                FileStream fs = new FileStream("token.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                txtToken.Text += sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            txtMsg.Text += "词法分析结束 " + "- " + scan.errors + " error(s)" + "\r\n";
            显示符号表信息ToolStripMenuItem.Checked = false;
            if (scan.errorList.Count != 0)
            {
                foreach (var i in scan.errorList)
                {
                    txtMsg.Text += i.ToString() + "\r\n";
                }
            }
            msgError = txtMsg.Text;
            if (scan.errorList.Count==0)
            {
                Parser paresr = new Parser();
                paresr.parser(scan.list);
                txtMsg.Text = "";
                for (int i = 0; i < paresr.error.Count; i++)
                {
                    txtMsg.Text += paresr.error[i] + "\r\n";
                }
                txtMsg.Text += "\r\n" + "语法分析结束 " + "- " + paresr.error.Count + " error(s)" + "\r\n";
                语法分析器ToolStripMenuItem.Enabled = true;
                toolStripButton1.Enabled = true;
                txtToken.Text = "------------------中间代码...-----------------" + "\r\n\r\n" + "NO" + "\t" + "OP" + "\t\t" + "arg1" + "\t\t" + "arg2" + "\t\t" + "result" + "\r\n";
            }
            
        }

        private void show_error()
        {
            txtMsg.Text = msgError;
        }

        private void txtContent_MouseClick(object sender, MouseEventArgs e)
        {
            //j为textbox中光标所在的行数
            int j = txtContent.GetLineFromCharIndex(txtContent.SelectionStart) + 1;
            toolStripStatusLabel1.Text = "Line " + j.ToString();
        }

        private void show_sym(object sender, EventArgs e)
        {
            if (显示符号表信息ToolStripMenuItem.Checked == false)
            {
                显示符号表信息ToolStripMenuItem.Checked = true;
                txtMsg.Text = "符号表信息...\r\n" + "\r\n" + "变量名" + "\t" + "token值" + "\t\t" + "变量类型" + "\r\n";
                try
                {
                    FileStream fs = new FileStream("symbol.txt", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    txtMsg.Text += sr.ReadToEnd();
                    sr.Close();
                    txtMsg.Text += "\r\n" + "符号表信息结束。";
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                显示符号表信息ToolStripMenuItem.Checked = false;
                show_error();
            }

        }

        private void Compiler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.S&&e.Control)
            {
                保存SToolStripMenuItem_Click(sender,e);
            }
            if (e.KeyCode==Keys.O&&e.Control)
            {
                打开OToolStripMenuItem_Click(sender, e);
            }
        }

        private void lL1预测分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LL_1_ llform = new LL_1_();
            llform.Show();
            this.Hide();
        }

        private void Compiler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 正规式NFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NDMFA r = new NDMFA();
            r.Show();
        }

        private void 运算符优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperatorFirst opf = new OperatorFirst();
            opf.Show();
            this.Hide();
        }

        private void lRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LR0 lr = new LR0();
            lr.Show();
            this.Hide();
            
        }

        private void nFADFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NFA_DFA_MFA ndf = new NFA_DFA_MFA();
            ndf.Show(); 
        }

        private void dFA最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DFAmin d = new DFAmin();
            d.Show();
        }

        private void 语法分析器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///测试语法分析
            //Parser paresr = new Parser();
            //paresr.parser(scan.list);
            //txtMsg.Text = "";
            //for (int i = 0; i < paresr.error.Count; i++)
            //{
            //    txtMsg.Text += paresr.error[i] + "\r\n";
            //}
            语法分析器ToolStripMenuItem.Enabled = false;
            toolStripButton1.Enabled = false;
        }

        private void 中间代码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Middle_Code md = new Middle_Code();
            md.Show();
        }
    }    
    
}
