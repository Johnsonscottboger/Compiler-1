using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
namespace Compiler
{
    class Stack
    {
        ArrayList stack = new ArrayList();
        /// <summary>
        /// 堆栈构造函数
        /// </summary>
        public Stack()
        {
            this.Push('#');
            this.Push(123);
            this.Push("abc");
        }
        /// <summary>
        /// 向堆栈中加入一个元素
        /// </summary>
        /// <param name="obj">一个任意类型的数据</param>
        public void Push(Object obj)
        {
            stack.Add(obj);
        }
        /// <summary>
        /// 从堆栈中
        /// </summary>
        /// <returns>从堆栈中取出的数据</returns>
        public Object Pop()
        {
            Object obj;
            obj = stack[stack.Count - 1];
            return obj;
        }
    }
}
