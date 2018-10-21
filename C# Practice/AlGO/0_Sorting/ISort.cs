using System;
using System.Collections.Generic;

namespace Practice.Sorting {

    public interface ISort {
        IEnumerable<T> Sorting<T>(IEnumerable<T> elements) where T : IComparable;
    }
}
