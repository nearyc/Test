namespace Csharp_Practice {
    public class PracticeTwo {
        public static int Function(int num) {
            int a = 0;
            while (num >= 0) {
                a++;
                num -= a * a;
            }
            return a;
        }
    }
}