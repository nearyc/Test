using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Collections {
    public interface IStack<T> {
        int Count { get; }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Push(T t);
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        T Pop();
        /// <summary>
        /// 取顶
        /// </summary>
        /// <returns></returns>
        T Peak();
    }
}
