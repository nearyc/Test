using System;

namespace Csharp_Practice {
    public class PracticeOne {
        public static void Function() {
            Console.WriteLine("Input the first number");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Input the second number");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("result is " + Add(a, b));
        }
        private static float Add(float a, float b) {
            return a + b;
        }
    }
}