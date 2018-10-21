using System;

public class Sort {
    public static void BubbleSorting<T>(ref T[] arr) where T : System.IComparable {
        if (arr.Length < 2) return;

        var nextRoundStartIndex = 0;
        for (int round = 0; round < arr.Length - 1; round++) {
            var isSwitched = false;
            for (int index = nextRoundStartIndex; index < arr.Length - round - 1; index++) {
                var compareResult = arr[index].CompareTo(arr[index + 1]);
                if (compareResult == 1) {
                    Swap(ref arr, index, index + 1);
                    if (!isSwitched) {
                        isSwitched = true;
                        nextRoundStartIndex = (index - 1) > 0 ? index - 1 : 0;
                    }
                }
            }
        }
    }

    private static void Swap<T>(ref T[] arr, int first, int second) where T : IComparable {
        var temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }
    public static void SelectSorting<T>(ref T[] arr) where T : System.IComparable {
        if (arr.Length < 2) return;

        for (int round = 0; round < arr.Length - 1; round++) {
            var minIndex = round;
            for (int index = round + 1; index < arr.Length - round; index++) {
                var compareResult = arr[index].CompareTo(arr[minIndex]);
                if (compareResult == -1) {
                    minIndex = index;
                }
            }
            Swap(ref arr, minIndex, round);
        }
    }
    public static void InsertSorting<T>(ref T[] arr) where T : System.IComparable {
        if (arr.Length < 2) return;

        for (int round = 0; round < arr.Length - 1; round++) {
            for (int index = round + 1; index > 0; index--) {
                var compareResult = arr[index].CompareTo(arr[index - 1]);
                if (compareResult == -1) {
                    Swap(ref arr, index, index - 1);
                }
                else {
                    break;
                }
            }
        }
    }

    public static void MergeSort(ref int[] inputAray, int first, int end) {
        if (first < end) {
            int midIndex = (first + end) / 2;
            MergeSort(ref inputAray, first, midIndex);
            MergeSort(ref inputAray, midIndex + 1, end);
            MergeMethod(ref inputAray, first, midIndex, end);
        }
    }

    private static void MergeMethod(ref int[] inputAray, int first, int midIndex, int end) {
        int[] temp = new int[end - first + 1];
        int m = first;
        int n = midIndex + 1;
        int k = 0;
        while (m <= midIndex && n < end) {
            if (inputAray[m] < inputAray[n]) {
                temp[k] = inputAray[m];
                k++;
                m++;
            }
            else {
                temp[k] = inputAray[n];
                k++;
                n++;
            }
        }
        while (m <= midIndex) {
            temp[k] = inputAray[m];
            k++;
            m++;
        }
        while (n < end) {
            temp[k] = inputAray[n];
            k++;
            n++;
        }
        for (k = 0, m = first; m < end; k++, m++) {
            inputAray[m] = temp[k];
        }
    }
    public static void QuickSorting<T>(ref T[] arr, int left, int right) where T : System.IComparable {
        if (left >= right) return;

        var swapPoint = left;
        for (int i = left + 1; i <= right; i++) {
            var compareResult = arr[i].CompareTo(arr[left]);
            if (compareResult == -1) {
                swapPoint++;
                Swap(ref arr, i, swapPoint);
            }
        }
        Swap(ref arr, left, swapPoint);
        QuickSorting(ref arr, left, swapPoint - 1);
        QuickSorting(ref arr, swapPoint + 1, right);
    }
}
