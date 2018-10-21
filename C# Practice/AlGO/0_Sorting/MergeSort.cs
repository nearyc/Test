using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Sorting {
    //归并排序
    public class MergeSort : ISort {
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
            tempArr = Sorting(tempArr, left, right);

            return tempArr;
        }
        private T[] Sorting<T>(T[] elements, int left, int right) where T : IComparable {
            //! 如左右标相等，结束递归调用
            if (left == right) return elements;

            //?划分方法  切半（黄金分割比应为最佳）
            var mid = (left + right) / 2;
            if (mid == right) {
                mid = left;
            }
            //递归调用
            Sorting(elements, left, mid);
            Sorting(elements, mid + 1, right);
            //! 拷贝到临时数组
            var tempArr = new T[elements.Length];
            elements.CopyTo(tempArr, 0);

            var leftPoint = left; //左侧初始点
            var rightPoint = mid + 1; //右侧初始点
            var insertPoint = left; //初始插入点

            //! 左右两数组取一进行比较，小的放入原数组，进行下一轮，直到其中一个数组取完
            while (leftPoint <= mid && rightPoint <= right) {
                // Console.WriteLine($"{leftPoint} + {rightPoint}");
                var compareResult = tempArr[leftPoint].CompareTo(tempArr[rightPoint]);
                //左侧偏小  <   右侧偏大
                if (compareResult == -1) {
                    elements[insertPoint] = tempArr[leftPoint];
                    leftPoint++;
                    insertPoint++;
                }
                //左侧偏小  >=  右侧偏大
                else {
                    elements[insertPoint] = tempArr[rightPoint];
                    rightPoint++;
                    insertPoint++;
                }
            }
            //! 取另一数组剩下的
            while (leftPoint <= mid) {
                elements[insertPoint] = tempArr[leftPoint];
                leftPoint++;
                insertPoint++;
            }
            while (rightPoint <= right) {
                elements[insertPoint] = tempArr[rightPoint];
                rightPoint++;
                insertPoint++;
            }
            return elements;
        }
    }
}
