using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace compiler
{
    public partial class LR0 : Form
    {
        public LR0()
        {
            InitializeComponent();
        }
        #region var
        List<Item> ItemC = new List<Item>();
        List<List<char>> state_word = new List<List<char>>();
        List<List<Item>> temp_I = new List<List<Item>>();
        List<NFANode> L_arc = new List<NFANode>();
        List<char> char_form = new List<char>();
        List<List<string>> erwei = new List<List<string>>();


        int d_serial = 0;
        string d_source = "";
        SymbolStack d_sysk = new SymbolStack();
        List<int> d_state_stack = new List<int>();
        Boolean d_flag_wan = false;
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Txt文件(*.txt)|*.txt|C文件(*.c)|*.c|所有文件(*.*)|*.* ";
            openFileDialog1.Title = "打开文件 ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                textBox1.Text = System.IO.File.ReadAllText(file, Encoding.Default);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int look_char(char a)
        {
            int b = 0;

            return b;
        }
        private void LR0_Load(object sender, EventArgs e)
        {
            textBox1.Text = "E->aA|bB" + "\r\nA->cA|d" + "\r\nB->cB|e";

        }
        private void write_hang(int serial, List<int> state_stack, SymbolStack sysk, string css, string source_text, string shuoming)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = serial.ToString();   //序列

            string tmp_state = "";
            for (int i = 0; i < state_stack.Count; i++)
            {
                tmp_state = tmp_state + state_stack[i].ToString() + " ";
            }
            lvi.SubItems.Add(tmp_state);


            lvi.SubItems.Add(sysk.sys_string());


            lvi.SubItems.Add(css);

            lvi.SubItems.Add(source_text);


            lvi.SubItems.Add(shuoming);
            listView3.Items.Add(lvi);
        }
        private closure_word go_function(List<Item> tt, char w)
        {
            closure_word fff = new closure_word();

            for (int i = 0; i < tt.Count; i++)
            {
                if (tt[i].VT.IndexOf('.') == tt[i].VT.Length - 1)
                {
                    List<Item> t6 = new List<Item>();
                    t6.Add(tt[i]);
                    fff.closure = t6;


                    List<char> ssa = new List<char>();
                    ssa.Add(' ');
                    fff.word = ssa;
                }
                else
                {
                    if (w == tt[i].VT[tt[i].VT.IndexOf('.') + 1])
                    {
                        string str = tt[i].VT;
                        string temp_s = "";

                        for (int k = 0; k < str.Length; k++) //取出点后面的字符，并将点后移一位
                        {

                            if (str[k] != '.')
                            {
                                temp_s = temp_s + str[k];
                            }
                            else
                            {
                                temp_s = temp_s + str[k + 1] + '.';
                                k = k + 1;
                            }
                        }
                        Item ttd = new Item();
                        ttd.VN = tt[i].VN;
                        ttd.VT = temp_s;
                        fff.closure = closure(ttd); //获得下一个状态的子集

                        List<char> word_form = new List<char>();

                        for (int ii = 0; ii < fff.closure.Count; ii++)
                        {
                            char aad = ' ';
                            if (fff.closure[ii].VT.IndexOf('.') == fff.closure[ii].VT.Length - 1)
                            {

                            }
                            else
                            {
                                aad = fff.closure[ii].VT[fff.closure[ii].VT.IndexOf('.') + 1];
                            }
                            word_form.Add(aad);
                        }
                        fff.word = word_form;
                        break;
                    }
                }
            }

            return fff;
        }

        private List<Item> closure(Item tt)
        {
            List<Item> aa = new List<Item>();
            char nt;
            aa.Add(tt);

            if (tt.VT.IndexOf('.') == tt.VT.Length - 1)
            {
                return aa;
            }
            else
            {
                nt = tt.VT[tt.VT.IndexOf('.') + 1];
                if (nt >= 'A' && nt <= 'Z')
                {
                    for (int i = 0; i < ItemC.Count; i++)
                    {
                        if (ItemC[i].VN == nt)
                        {
                            Item tt1 = new Item();
                            tt1.VN = ItemC[i].VN;
                            tt1.VT = '.' + ItemC[i].VT;
                            aa.Add(tt1);
                        }
                    }
                }
                return aa;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string source_txt = textBox1.Text.Trim() + "\r\n";
            string temp_txt = "";
            List<string> temp_str = new List<string>();
            Item asdf = new Item();
            int state = 0;
            string vt = "";
            char vn = ' ';
            int fla = 0;
            ItemC.Clear();
            ItemC.Add(asdf);
            for (int i = 0; i < source_txt.Length; i++)
            {
                if (source_txt[i] != '\r')
                {
                    temp_txt = temp_txt + source_txt[i];
                }
                else
                {
                    for (int j = 0; j < i - fla; j++)
                    {
                        switch (state)
                        {
                            case 0:
                                {
                                    if (temp_txt[j] >= 'A' && temp_txt[j] <= 'Z')
                                    {
                                        state = 1;
                                        vn = temp_txt[j];
                                    }
                                    else
                                    {
                                        state = 0;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (temp_txt[j] == '-' && temp_txt[j + 1] == '>')
                                    {
                                        state = 2;
                                        j++;
                                    }
                                    else
                                    {
                                        state = 1;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (temp_txt[j] == ' ')
                                    {
                                        state = 2;
                                    }
                                    else if (temp_txt[j] != '|')
                                    {
                                        state = 2;
                                        vt = vt + temp_txt[j];
                                    }
                                    else
                                    {
                                        state = 2;
                                        temp_str.Add(vt);
                                        vt = "";
                                    }
                                    break;
                                }
                        }
                    }
                    temp_str.Add(vt);
                    vt = "";
                    for (int k = 0; k < temp_str.Count; k++)
                    {
                        Item itm = new Item();
                        itm.VN = vn;
                        itm.VT = temp_str[k];
                        ItemC.Add(itm);
                    }
                    i = i + 1;
                    fla = i + 1;
                    temp_str.Clear();
                    temp_txt = "";
                    state = 0;
                }
            }
            ItemC[0].VN = 'X';
            ItemC[0].VT = ItemC[1].VN.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textBox2.Text = "accd";

            List<char> vn = new List<char>();
            List<char> vt = new List<char>();

            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("状态");
            for (int i = 0; i < state_word.Count; i++)
            {
                for (int j = 0; j < state_word[i].Count; j++)
                {
                    char tmp = state_word[i][j];
                    if (tmp >= 'A' && tmp <= 'Z')
                    {
                        Boolean fla = false;
                        for (int k = 0; k < vn.Count; k++)
                        {
                            if (vn[k] == tmp)
                            {
                                fla = true;
                                break;
                            }
                        }
                        if (fla == false)
                        {
                            vn.Add(tmp);
                        }
                    }
                    else if (tmp >= 'a' && tmp <= 'z')
                    {
                        Boolean fla = false;
                        for (int k = 0; k < vt.Count; k++)
                        {
                            if (vt[k] == tmp)
                            {
                                fla = true;
                                break;
                            }
                        }
                        if (fla == false)
                        {
                            vt.Add(tmp);
                        }
                    }
                }
            }
            //char[] char_ = new char[vt.Count + vn.Count + 2];
            // int tm = 1;
            for (int j = 0; j < vt.Count; j++)
            {
                char_form.Add(vt[j]);
                //char_[tm] = vt[j];
                listView2.Columns.Add(vt[j].ToString());
                // tm++;
            }
            char_form.Add('#');
            //char_[tm] = '#';
            //  tm++;
            listView2.Columns.Add('#'.ToString());
            for (int j = 0; j < vn.Count; j++)
            {
                char_form.Add(vn[j]);
                //char_[tm] = vn[j];
                listView2.Columns.Add(vn[j].ToString());
                //       tm++;
            }
            for (int ffs = 0; ffs < temp_I.Count; ffs++)
            {
                List<string> afs = new List<string>();
                for (int fs = 0; fs < char_form.Count; fs++)
                {
                    afs.Add(null);
                }
                erwei.Add(afs);
            }
            //     tm--;

            //    int pkd = tm+1;
            //string[,] syn = new string[temp_I.Count, pkd];

            for (int ik = 0; ik < temp_I.Count; ik++) //集合个数
            {
                for (int k = 0; k < temp_I[ik].Count; k++) //该集合中的项目个数
                {
                    if (temp_I[ik][k].VT.IndexOf('.') == temp_I[ik][k].VT.Length - 1) //A->x.
                    {
                        char tmp1 = temp_I[ik][k].VT[temp_I[ik][k].VT.IndexOf('.') - 1];
                        if (tmp1 == temp_I[0][0].VT[1])  //可接受
                        {
                            int tmp_ik = 0;
                            for (int vv = 0; vv < char_form.Count; vv++)
                            {
                                if (char_form[vv] == '#')
                                {
                                    tmp_ik = vv;
                                    break;
                                }
                            }
                            //syn[ik, tmp_ik] = "acc";
                            erwei[ik][tmp_ik] = "acc";
                        }
                        else  //规约
                        {
                            int rj = 0;
                            string av = temp_I[ik][k].VT;
                            av = av.Remove(av.Length - 1, 1);
                            for (int pv = 0; pv < ItemC.Count; pv++)
                            {
                                if (ItemC[pv].VT == av)
                                {
                                    rj = pv;
                                    break;
                                }
                            }

                            for (int wv = 0; wv < char_form.Count; wv++)
                            {
                                if ((char_form[wv] >= 'a' && char_form[wv] <= 'z') || char_form[wv] == '#')
                                {
                                    erwei[ik][wv] = "r" + rj.ToString();
                                }
                            }

                        }
                    }
                    else //A->a.Bc
                    {
                        char tmp1 = temp_I[ik][k].VT[temp_I[ik][k].VT.IndexOf('.') + 1];
                        if (tmp1 >= 'A' && tmp1 <= 'Z')  //查弧表
                        {
                            for (int w = 0; w < L_arc.Count; w++)
                            {
                                if (tmp1 == L_arc[w].Word && ik == L_arc[w].From)
                                {
                                    int ij = L_arc[w].To;
                                    int tmp_ij = 0;
                                    for (int i = 0; i < char_form.Count; i++)
                                    {
                                        if (char_form[i] == tmp1)
                                        {
                                            tmp_ij = i;
                                            break;
                                        }
                                    }
                                    erwei[ik][tmp_ij] = ij.ToString();
                                    break;
                                }
                            }
                        }
                        else if (tmp1 >= 'a' && tmp1 <= 'z')
                        {
                            for (int w = 0; w < L_arc.Count; w++)
                            {
                                if (tmp1 == L_arc[w].Word && ik == L_arc[w].From)
                                {
                                    int ij = L_arc[w].To;
                                    int tmp_ij = 0;
                                    for (int i = 0; i < char_form.Count; i++)
                                    {
                                        if (char_form[i] == tmp1)
                                        {
                                            tmp_ij = i;
                                            break;
                                        }
                                    }
                                    erwei[ik][tmp_ij] = "S" + ij.ToString();
                                    //syn[ik, tmp_ij] = "S" + ij.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = ik.ToString();
                for (int ps = 0; ps < char_form.Count; ps++)
                {
                    lvi.SubItems.Add(erwei[ik][ps]);
                }
                listView2.Items.Add(lvi);
            }  
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Item> temp_item = new List<Item>();
            List<char> word_form = new List<char>();

            listView1.Items.Clear();
            L_arc.Clear();
            state_word.Clear();
            temp_I.Clear();
            if (ItemC.Count == 0)
            {
                MessageBox.Show("请先确认文法");
                //  this.Close();
            }
            else
            {
                //---------------------获得起始状态的#_Closure----------------------//

                temp_item.Add(ItemC[0]);
                for (int i = 0; i < ItemC.Count; i++)
                {
                    if (ItemC[i].VN.ToString() == temp_item[0].VT)
                    {
                        Item tt = new Item();
                        tt.VN = ItemC[i].VN;
                        tt.VT = '.' + ItemC[i].VT;
                        temp_item.Add(tt);
                    }
                }
                temp_item[0].VT = '.' + temp_item[0].VT;
                temp_I.Add(temp_item);

                for (int i = 0; i < temp_I[0].Count; i++)
                {
                    char aad = temp_I[0][i].VT[temp_I[0][i].VT.IndexOf('.') + 1];
                    word_form.Add(aad);
                }
                state_word.Add(word_form);

                //----------------------------------------------------------------//
                int tmp2 = 0;
                for (int ii = 0; ii < temp_I.Count; ii++)
                {
                    int tmp_num = temp_I[ii].Count;

                    for (int jj = 0; jj < state_word[ii].Count; jj++)
                    {
                        closure_word cw = new closure_word();
                        cw = go_function(temp_I[ii], state_word[ii][jj]);
                        //--------------------判断是否已经存在--------------------------------//
                        Boolean fla = false;
                        int num = 0;
                        int p;
                        for (p = 0; p < temp_I.Count; p++)
                        {
                            if (cw.closure.Count == temp_I[p].Count)
                            {
                                for (int pp = 0; pp < cw.closure.Count; pp++)
                                {
                                    for (int ppp = 0; ppp < cw.closure.Count; ppp++)
                                    {
                                        if ((cw.closure[ppp].VN == temp_I[p][pp].VN) && (cw.closure[ppp].VT == temp_I[p][pp].VT))
                                        {
                                            num++;
                                            break;
                                        }
                                    }
                                }
                                if (num == cw.closure.Count)
                                {
                                    fla = true;
                                    break;
                                }
                                num = 0;
                            }
                        }
                        //----------------------------------------------------------------------------------------//
                        if (fla == false)
                        {
                            tmp_num--;
                            if (tmp_num >= 0)
                            {
                                tmp2++;
                            }
                            state_word.Add(cw.word);
                            temp_I.Add(cw.closure);

                            NFANode ARC = new NFANode();
                            ARC.From = ii;
                            ARC.To = tmp2;
                            ARC.Word = state_word[ii][jj];
                            L_arc.Add(ARC);
                        }
                        else
                        {
                            fla = false;

                            NFANode ARC = new NFANode();
                            ARC.From = ii;
                            ARC.To = p;
                            ARC.Word = state_word[ii][jj];
                            L_arc.Add(ARC);
                        }
                    }
                }
                /////////////////////////////////
                listView1.Items.Clear();
                for (int ab = 0; ab < temp_I.Count; ab++)
                {
                    string asf = "";
                    for (int dsf = 0; dsf < temp_I[ab].Count; dsf++)
                    {
                        asf = asf + temp_I[ab][dsf].VN + "->" + temp_I[ab][dsf].VT + "  ";
                    }
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = ab.ToString();
                    lvi.SubItems.Add(asf);
                    listView1.Items.Add(lvi);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SymbolStack sysk = new SymbolStack();
            List<int> state_stack = new List<int>();
            listView3.Items.Clear();
            string source_text = textBox2.Text.Trim() + '#';
            Boolean jieshu = false;
            Boolean flag_wan = false;
            int serial = 0;
            int lie = 0;
            sysk.Push('#');
            state_stack.Add(0);
            write_hang(serial, state_stack, sysk, "", source_text, "初始状态");
            while (!(jieshu))
            {
                serial++;
                string shuoming = "";
                string css = "";
                char shou_char = source_text[0];
                for (int a = 0; a < char_form.Count; a++)
                {
                    if (shou_char == char_form[a])
                    {
                        lie = a;
                        break;
                    }
                }

                string ff = erwei[state_stack[state_stack.Count - 1]][lie];
                if (ff == null)
                {
                    flag_wan = true;
                    break;
                }
                else if (ff[0] == 'S')
                {
                    ff = ff.Remove(0, 1);
                    state_stack.Add(Convert.ToInt16(ff));
                    sysk.Push(shou_char);
                    source_text = source_text.Remove(0, 1);

                    shuoming = ff + "移进状态栈" + shou_char.ToString() + "移进符号栈";
                }
                else if (ff[0] == 'a')
                {
                    shuoming = "接受";
                    jieshu = true;
                }
                else if (ff[0] == 'r')
                {
                    ff = ff.Remove(0, 1);
                    int ba = Convert.ToInt16(ff);
                    int vtl = ItemC[ba].VT.Length;

                    css = ItemC[ba].VN + "->" + ItemC[ba].VT;
                    for (int ide = 0; ide < vtl; ide++)
                    {
                        sysk.Pop();
                        state_stack.RemoveAt(state_stack.Count - 1);
                    }

                    sysk.Push(ItemC[ba].VN);

                    for (int a = 0; a < char_form.Count; a++)
                    {
                        if (ItemC[ba].VN == char_form[a])
                        {
                            lie = a;
                            break;
                        }
                    }
                    state_stack.Add(Convert.ToInt16(erwei[state_stack[state_stack.Count - 1]][lie]));
                    shuoming = "规约";
                }
                else
                {
                    flag_wan = true;
                    break;
                    //MessageBox.Show("分析失败，不是该文法的句子！");
                }

                write_hang(serial, state_stack, sysk, css, source_text, shuoming);

            }
            if (flag_wan)
            {
                MessageBox.Show("分析失败，不是该文法的句子！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Boolean jieshu = false;
            //int serial = 0;
            int lie = 0;
            if (d_serial == 0)
            {
                listView3.Items.Clear();
                d_source = textBox2.Text.Trim() + '#';
                d_sysk.Push('#');
                d_state_stack.Add(0);
                write_hang(d_serial, d_state_stack, d_sysk, "", d_source, "初始状态");
                d_serial++;
            }
            else
            {
                string shuoming = "";
                string css = "";
                char shou_char = d_source[0];
                for (int a = 0; a < char_form.Count; a++)
                {
                    if (shou_char == char_form[a])
                    {
                        lie = a;
                        break;
                    }
                }

                string ff = erwei[d_state_stack[d_state_stack.Count - 1]][lie];
                if (ff == null)
                {
                    d_flag_wan = true;
                }
                else if (ff[0] == 'S')
                {
                    ff = ff.Remove(0, 1);
                    d_state_stack.Add(Convert.ToInt16(ff));
                    d_sysk.Push(shou_char);
                    d_source = d_source.Remove(0, 1);

                    shuoming = ff + "移进状态栈" + shou_char.ToString() + "移进符号栈";
                }
                else if (ff[0] == 'a')
                {
                    shuoming = "接受";
                    jieshu = true;
                }
                else if (ff[0] == 'r')
                {
                    ff = ff.Remove(0, 1);
                    int ba = Convert.ToInt16(ff);
                    int vtl = ItemC[ba].VT.Length;

                    css = ItemC[ba].VN + "->" + ItemC[ba].VT;
                    for (int ide = 0; ide < vtl; ide++)
                    {
                        d_sysk.Pop();
                        d_state_stack.RemoveAt(d_state_stack.Count - 1);
                    }

                    d_sysk.Push(ItemC[ba].VN);

                    for (int a = 0; a < char_form.Count; a++)
                    {
                        if (ItemC[ba].VN == char_form[a])
                        {
                            lie = a;
                            break;
                        }
                    }
                    d_state_stack.Add(Convert.ToInt16(erwei[d_state_stack[d_state_stack.Count - 1]][lie]));
                    shuoming = "规约";
                }
                else
                {
                    d_flag_wan = true;
                }

                write_hang(d_serial, d_state_stack, d_sysk, css, d_source, shuoming);
                d_serial++;
            }


            if (d_flag_wan)
            {
                MessageBox.Show("分析失败，不是该文法的句子！");
                d_flag_wan = false;
                d_serial = 0;
                d_source = "";
                d_sysk.out_clear();
                d_state_stack.Clear();
            }
            else
            {
                if (jieshu)
                {
                    MessageBox.Show("分析完成");
                    d_serial = 0;
                    d_source = "";
                    d_sysk.out_clear();
                    d_state_stack.Clear();
                }
            }
        }
    }

    class Item
    {
        public char VN;
        public string VT;
    }


    [Serializable]
    class NFANode
    {
        public int From;
        public int To;
        public char Word;
    }


    class SymbolStack
    {
        string strStack = "";
        public char Top
        {
            get
            {
                if (strStack != "")
                {
                    return strStack[strStack.Length - 1];
                }
                else
                {
                    return ' ';
                }
            }
        }
        public void Push(char _Symbol)
        {
            strStack = strStack + _Symbol;
        }
        public char Pop()
        {
            char c;
            if (strStack != "")
            {
                c = strStack[strStack.Length - 1];
                strStack = strStack.Remove(strStack.Length - 1);
            }
            else
            {
                c = ' ';
            }
            return c;
        }

        public string sys_string()
        {
            return strStack;
        }

        public void out_clear()
        {
            strStack = "";
        }
    }


    class closure_word
    {
        public List<Item> closure;
        public List<char> word;
    }
}
