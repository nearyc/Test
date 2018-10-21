using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SelectSort : ISort {
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
            for (int i = 0; i < elements.Length - 1; i++) {
                var minIndex = i;
                //! 每第I+1轮提取一个最小值minIndex，与i交换位置
                for (int j = i + 1; j < elements.Length; j++) {
                    var compareResult = elements[minIndex].CompareTo(elements[j]);
                    if (compareResult == 1) {
                        minIndex = j;
                    }
                }
                //! 交换位置
                var switchTemp = elements[i];
                elements[i] = elements[minIndex];
                elements[minIndex] = switchTemp;
            }
        }
    }
}
