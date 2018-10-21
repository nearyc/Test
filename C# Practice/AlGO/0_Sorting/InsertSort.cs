using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    public class InsertSort : ISort {
        public IEnumerable<T> Sorting<T>(IEnumerable<T> elements) where T : IComparable {
            if (elements.Count() < 2)
                return elements;
            Console.WriteLine("排序前：");
            var tempArr = elements.ToArray();
            foreach (var item in tempArr) {
                Console.Write($"{item.ToString()} ,");
            }
            Console.WriteLine("\n排序后：");

            Sorting(ref tempArr);

            return tempArr;
        }
        private void Sorting<T>(ref T[] elements) where T : IComparable {
            for (int round = 0; round < elements.Length - 1; round++) {
                for (int index = round + 1; index > 0; index--) {
                    var compareResult = elements[index].CompareTo(elements[index - 1]);
                    //! 从大到小逐值比较，如果发现有比自己小的，则插入并进入下一轮循环
                    if (compareResult == -1) {
                        var switchTemp = elements[index - 1];
                        elements[index - 1] = elements[index];
                        elements[index] = switchTemp;
                    }
                    else {
                        break;
                    }
                }
            }
        }
    }
}
