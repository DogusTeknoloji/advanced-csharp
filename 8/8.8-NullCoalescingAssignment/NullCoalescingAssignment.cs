using System.Collections.Generic;
using static System.Console;

namespace AdvancedCSharp {

    public class NullCoalescingAssignment : ITutorial {

        public void Run() {
            List<int> numbers = null;
            int? a = null;

            // new operator!
            (numbers ??= new List<int>()).Add(5);
            WriteLine(string.Join(" ", numbers));

            numbers.Add(a ??= 0);
            WriteLine(string.Join(" ", numbers));
            WriteLine(a);
        }
    }
}