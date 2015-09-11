using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ASMEdit : UserControl
    {
        public ASMEdit()
        {
            InitializeComponent();
        }
        private void showLineNo()
        {
            //获得当前坐标信息
            Point p = this.richTextBox1.Location;
            int crntFirstIndex = this.richTextBox1.GetCharIndexFromPosition(p);
            int crntFirstLine = this.richTextBox1.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.richTextBox1.GetPositionFromCharIndex(crntFirstIndex);
            //
            p.Y += this.richTextBox1.Height;
            //
            int crntLastIndex = this.richTextBox1.GetCharIndexFromPosition(p);
            int crntLastLine = this.richTextBox1.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = this.richTextBox1.GetPositionFromCharIndex(crntLastIndex);
            //
            //
            //准备画图
            Graphics g = this.panel1.CreateGraphics();
            Font font = new Font(this.richTextBox1.Font,this.richTextBox1.Font.Style);
            SolidBrush brush = new SolidBrush(Color.Green);
            //
            //
            //画图开始
            //刷新画布
            Rectangle rect = this.panel1.ClientRectangle;
            brush.Color = this.panel1.BackColor;
            g.FillRectangle(brush, 0, 0, this.panel1.ClientRectangle.Width, this.panel1.ClientRectangle.Height);
            brush.Color = Color.Green;//重置画笔颜色
            //
            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = Convert.ToInt32(this.richTextBox1.Font.Size);
            }
            int brushX = this.panel1.ClientRectangle.Width - Convert.ToInt32(font.Size * 3);
            int brushY = crntLastPos.Y+ Convert.ToInt32(font.Size*0.21f);//惊人的算法啊！！
            for (int i = crntLastLine; i >= crntFirstLine;i-- )
            {
                g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            showLineNo();
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }


   
    }
}
