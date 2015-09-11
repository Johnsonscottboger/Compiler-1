using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
    public static class NFA
    {
        #region 定义不确定的NFAM结构体
        /// <summary>
        /// 定义不确定的NFAM结构体
        /// </summary>
        public struct NFAM
        {
            public int startstatus;//起始状态
            public int endstatus;//结束状态
            public char varch;//弧
            /// <summary>
            /// NFA的构造函数
            /// </summary>
            /// <param name="cfrom">要构造的状态图的起始状态</param>
            /// <param name="cto">要构造的状态图的结束状态</param>
            /// <param name="ch">起始状态到结束状态的弧</param>
            public NFAM(int from, int to, char ch)
            {
                this.startstatus = from;
                this.endstatus = to;
                this.varch = ch;
            }
        }
        #endregion
    }
}
