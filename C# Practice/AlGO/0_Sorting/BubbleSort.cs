using System;
using System.Collections.Generic;
using System.Linq;
namespace Practice.Sorting {
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public struct BubbleSort : ISort {
        public IEnumerable<T> Sorting<T>(IEnumerable<T> elements) where T : IComparable {
            if (elements.Count() < 2)
                return elements;

            // var tempArr = new T[elements.Count()];
            // var i = 0;
            // foreach (var ele in elements) {
            //     tempArr[i] = ele;
            //     i++;
            // }
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
            //round --多少轮
            var firstSwitchIndex = 0;
            for (int round = 0; round < elements.Length - 1; round++) {
                var isSwtched = false;
                var nextRoundfirstSwitchIndex = firstSwitchIndex;
                //index --交换位置
                for (int index = firstSwitchIndex; index < elements.Length - round - 1; index++) {
                    //!比较J与J+1的大小
                    var compareResult = elements[index].CompareTo(elements[index + 1]);
                    //!如果J大于J+1;交换J和J+1;
                    if (compareResult == 1) {
                        var switchTemp = elements[index + 1];
                        elements[index + 1] = elements[index];
                        elements[index] = switchTemp;
                        //? 改进，记录下一轮从什么位置开始（不必再从index为0的位置开始了）
                        if (!isSwtched) {
                            isSwtched = true;
                            nextRoundfirstSwitchIndex = firstSwitchIndex;
                        }
                    }
                }

                if (!isSwtched)
                    firstSwitchIndex = nextRoundfirstSwitchIndex; //? 前面不需要交换，可以跳过省去重复步骤
                else
                    break; //? 没有找到需要交换的，结束循环
            }
        }
    }
}
