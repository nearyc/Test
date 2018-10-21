using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    /// <summary>
    /// 基数排序
    /// </summary>
    public class RadixSort {
        public IEnumerable<int> Sorting(IEnumerable<int> elements) {
            if (elements.Count() < 2)
                return elements;
            Console.WriteLine("排序前：");
            var tempArr = elements.ToArray();
            foreach (var item in tempArr) {
                Console.Write($"{item.ToString()} ,");
            }

            Console.WriteLine("\n排序后：");
            Sorting(ref tempArr, 0);
            return tempArr;
        }
        public void Sorting(ref int[] elements, int digit) {
            var container = new Queue<int>[10];
            for (int i = 0; i < container.Length; i++) {
                container[i] = new Queue<int>();
            }
            //! k=1 对应个位数，k=2 对应十位数......
            var k = System.Convert.ToInt32(Math.Pow(10, digit));
            //存入container
            for (int i = 0; i < elements.Length; i++) {
                var remainder = elements[i] / k % 10;
                container[remainder].Enqueue(elements[i]);
            }
            //! 如果...则结束递归调用
            if (container[0].Count == elements.Length)
                return;
            //从container取出
            var index = 0;
            for (int i = 0; i < container.Length; i++) {
                while (container[i].Count > 0) {
                    elements[index] = container[i].Dequeue();
                    index++;
                }
            }

            Sorting(ref elements, digit + 1);
        }
    }
}
