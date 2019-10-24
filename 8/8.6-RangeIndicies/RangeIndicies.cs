using System;
using static System.Console;

namespace AdvancedCSharp {

    public class RangeIndicies : ITutorial {

        public void Run() {
            Index i1 = 3;  // 3. from start
            Index i2 = ^4; // 4. from end
            // we can define arrays like this :)
            int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            WriteLine($"3. item is {a[i1]}, 4. from end is {a[i2]}");

            var slice = a[i1..i2];
            WriteLine($"Slice: {string.Join(", ", slice)}");
        }
    }
}