using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    /// <summary>
    /// 希尔排序
    /// </summary>
    public class ShellSort : ISort {
        private const int GAP_RATIO = 2;
        public IEnumerable<T> Sorting<T>(IEnumerable<T> elements) where T : IComparable {
            if (elements.Count() < 2)
                return elements;
            Console.WriteLine("排序前：");
            var tempArr = elements.ToArray();
            foreach (var item in tempArr) {
                Console.Write($"{item.ToString()} ,");
            }

            Console.WriteLine("\n排序后：");
            Sorting(ref tempArr, tempArr.Length);
            return tempArr;
        }
        private void Sorting<T>(ref T[] elements, int lastRoundGap) where T : IComparable {
            //! Gap为1则结束递归;
            var thisRoundGap = lastRoundGap / GAP_RATIO;
            if (thisRoundGap == 0) return;
            var dividedIndexArrs = DivideArrayByGap(elements, thisRoundGap);
            for (int i = 0; i < dividedIndexArrs.Length; i++) {
                SortingSubArray(ref elements, dividedIndexArrs[i]);
            }
            //递归
            Sorting(ref elements, thisRoundGap);
        }
        private void SortingSubArray<T>(ref T[] elements, int[] indexArr) where T : IComparable {
            for (int i = 0; i < indexArr.Length - 1; i++) {
                var isSwitched = Switch(ref elements, indexArr[i], indexArr[i + 1]);
                //! 如果发生了交换，则需往回交换
                if (isSwitched) {
                    for (int j = i; j >= 0; j--) {
                        //! 从右往左交换，直到未发生交换或者到达最左端
                        if (j - 1 < 0) break;
                        var isSwitchedBack = Switch(ref elements, indexArr[j - 1], indexArr[j]);
                        if (!isSwitchedBack) break;
                        else continue;
                    }
                }
            }
        }
        private bool Switch<T>(ref T[] elements, int firstIndex, int secondIndex) where T : IComparable {
            //! 如果左侧数字大于右侧数字，则发生交换
            if (elements[firstIndex].CompareTo(elements[secondIndex]) == 1) {
                var temp = elements[firstIndex];
                elements[firstIndex] = elements[secondIndex];
                elements[secondIndex] = temp;
                return true;
            }
            return false;
        }
        //! 根据Gap来拆分数组
        private int[][] DivideArrayByGap<T>(T[] elements, int gap) where T : IComparable {
            //! 包含gap个数组的交错数组
            var arrs = new int[gap][];
            for (int i = 0; i < gap; i++) {
                //! 交错数组中第I个的新的数组数量为(elements.Length - i) / gap， 且向上取整
                float newArrCountFloat = ((float) elements.Length - i) / gap;
                int newArrCountInt = (int) Math.Ceiling(newArrCountFloat);
                arrs[i] = new int[newArrCountInt];

                var index = 0;
                //! 添加index
                for (int j = i; j < elements.Length; j += gap) {
                    arrs[i][index] = j;
                    index++;
                }
            }
            return arrs;
        }
    }
}
