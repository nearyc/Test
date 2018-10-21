using System;
using System.Collections.Generic;
using System.Linq;
namespace Practice.Sorting {
    /// <summary>
    /// 计数排序（对整数皆可--包括负数）
    /// </summary>
    public class CountingSort {
        int O; //最小值与0的offset ，当最小值小于0时
        public IEnumerable<int> Sorting(IEnumerable<int> elements) {
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
        private void Sorting(ref int[] elements) {
            var outputArr = new int[elements.Length];
            var countArr = CreateCountArray(elements);
            //记录有多少个数比自己小
            countArr[0]--;
            for (int i = 1; i < countArr.Length; i++) {
                countArr[i] += countArr[i - 1];
            }
            //取数
            for (int i = elements.Length - 1; i >= 0; i--) {
                outputArr[countArr[elements[i] - O]] = elements[i];
                countArr[elements[i] - O]--;
            }
            elements = outputArr;
        }
        /// <summary>
        /// 得到数组中的最大最小值，根据两者插值创建CountArr，如果最小值为负数，记录offset
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        private int[] CreateCountArray(int[] elements) {
            var min = 0;
            var max = 0;
            foreach (var ele in elements) {
                if (min > ele) min = ele;
                if (max < ele) max = ele;
            }

            O = min;
            if (O >= 0)
                O = 0;
            var countArr = new int[max - O + 1];

            for (int i = 0; i < elements.Length; i++) {
                countArr[elements[i] - O]++;
            }
            return countArr;
        }
    }
}
