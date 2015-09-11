using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    public class DFAD
        {
            #region 定义不确定的NFAM结构体
            /// <summary>
            /// 定义不确定的NFAM结构体
            /// </summary>
            public struct DFA
            {
                public int From;//起始状态
                public int To;//结束状态
                public char Varch;//弧
                /// <summary>
                /// NFA的构造函数
                /// </summary>
                /// <param name="cfrom">要构造的状态图的起始状态</param>
                /// <param name="cto">要构造的状态图的结束状态</param>
                /// <param name="ch">起始状态到结束状态的弧</param>
                public DFA(int from, int to, char ch)
                {
                    this.From = from;
                    this.To = to;
                    this.Varch = ch;
                }
            }
            #endregion
        }
}
