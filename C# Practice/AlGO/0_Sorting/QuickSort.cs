using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    /// <summary>
    /// （随机）快速排序
    /// </summary>
    public class QuickSort : ISort {
        private readonly bool _isRandomPivot;
        public QuickSort(bool isRandomPivot) {
            _isRandomPivot = isRandomPivot;
        }
        public QuickSort() : this(false) {

        }
        public IEnumerable<T> Sorting<T>(IEnumerable<T> elements) where T : IComparable {
            if (elements.Count() < 2)
                return elements;
            Console.WriteLine("排序前：");
            var tempArr = elements.ToArray();

            foreach (var item in tempArr) {
                Console.Write($"{item.ToString()} ,");
            }
            Console.WriteLine("\n排序后：");

            var left = 0;
            var right = tempArr.Length - 1;
            Sorting(ref tempArr, left, right, _isRandomPivot);

            return tempArr;
        }
        /// <param name="elements">待排序数组</param>
        /// <param name="left">左标</param>
        /// <param name="right">右标</param>
        /// <param name="isRandomPivot">是否为随机快速排序</param>
        /// <returns></returns>
        private T[] Sorting<T>(ref T[] elements, int left, int right, bool isRandomPivot) where T : IComparable {
            //! 如果左右标相等，结束递归调用
            if (left >= right) return elements;

            //如果是随机快速排序...否则pivot为最左侧点
            var pivot = isRandomPivot? new System.Random().Next(left, right + 1) : left;
            var switchPoint = left; //初始交换点是pivot
            SwitchPos(ref elements, left, pivot); //! 将pivot点先放置到最左侧
            for (int i = left; i < right + 1; i++) {
                var compareResult = elements[i].CompareTo(elements[left]);
                if (compareResult == -1) {
                    //! if--ele[i] < pivot--则需要发生交换，交换点自增后交换
                    switchPoint++;
                    SwitchPos(ref elements, i, switchPoint);
                }
            }

            SwitchPos(ref elements, left, switchPoint); //! 将pivot点先放置到交换点，此时左侧数字皆小于等于pivot，反之
            Sorting(ref elements, left, switchPoint - 1, isRandomPivot); //递归左侧
            Sorting(ref elements, switchPoint + 1, right, isRandomPivot); //递归右侧

            return elements;

        }
        /// <summary>
        /// 交换位置
        /// </summary>
        private void SwitchPos<T>(ref T[] elements, int firstIndex, int secondIndex) where T : IComparable {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}
