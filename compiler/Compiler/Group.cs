using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    class Group
    {
        public struct Node
        {
            public int pos;
            public int num;
            public int accept;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="pos">组号</param>
            /// <param name="num">状态号</param>
            /// <param name="accept">是否为非终结状态1表示非 0表示终结</param>
            public Node(int Pos,int num,int accept)
            {
                this.pos = Pos;
                this.num = num;
                this.accept = accept;
            }
            public Boolean CompareTo(Node node)
            {
                if (this.pos == node.pos && this.num == node.num && this.accept == node.accept)
                    return true;
                else
                    return false;
            }
        }
        public struct Arc
        {
            public int start;
            public char input;
            public int end;
            public Arc(int start,char input,int end)
            {
                this.start = start;
                this.end = end;
                this.input = input;
            }

        }
        
    }
}
