using System;
using System.Text.RegularExpressions;

namespace Csharp_Practice {
    public class RegularExpression {
        public static void Function() {

            // while (true) {
            // string a = Console.ReadLine();
            string a = "<sadasdasd>\n<sdasd>";
            string p = @"<.*>";
            MatchCollection m = Regex.Matches(a, p);
            foreach (var mm in m) {
                Console.WriteLine(mm);
            }
            // }
        }
    }
}