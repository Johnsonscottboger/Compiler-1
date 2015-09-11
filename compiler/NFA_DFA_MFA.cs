using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace compiler
{
    public partial class NFA_DFA_MFA : Form
    {
        public NFA_DFA_MFA()
        {
            InitializeComponent();
        }
        public char[] sign = { '·', '|', '(', ')', '*', '#' };
        public char[,] table = {{ '>','>','<','>','<','>'},
                                { '<','>','<','>','<','>'},
                                { '<','<','<','=','<','E'},
                                { '>','>','E','>','>','>'},
                                { '>','>','E','>','>','>'},
                                { '<','<','<','E','<','E'}};
        //List<NFA> list = new List<NFA>();
        Stack<char> stack_sym = new Stack<char>();
        Stack<int> stack_state = new Stack<int>();
        //Queue<NFA> Arc_NFA = new Queue<NFA>();
        const int NFA_Length = 128;
       // NFA[] nfa = new NFA[NFA_Length];
        public char search_table(char a,char b)
        {
            int i = -1, j = -1;
            for (int k = 0; k < sign.Length; k++)
            {
                if (sign[k]==a)
                {
                    i = k;
                }
                if (sign[k]==b)
                {
                    j = k;
                }
            }
            return table[i, j];
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lvNFA.Clear();
            string s = textBox1.Text ;
            int i = 0;
            while ( i < s.Length-1)
            {
                if (IsMatch(s.Substring(i, 2)))
                {
                    s = s.Insert(i + 1, "·");
                }
                i++;
            }
            MessageBox.Show(s);

            
        }

        public bool IsMatch(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.
                RegularExpressions.Regex(@"^[a-z]{2}|[)][^|*]|[*][^|]$");
            return regex.IsMatch(str);
        }

        public bool IsAlpOrNum(char ch)
        {
            if (ch >= 'a' && ch <= 'z')
                return true;
            else if (ch >= '0' && ch <= '9')
                return true;
            else
                return false;
        }

        private void NFA_DFA_MFA_Load(object sender, EventArgs e)
        {
            textBox1.Text = "(a|b)*(aa|bb)(a|b)*";
        }

        
    }
    
    
}
