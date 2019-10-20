using System;
using System.Linq;
using static System.Console;

namespace AdvancedCSharp {

    public class RefLocalReturn : ITutorial {

        public void Run() {
            var arr = Enumerable.Range(0, 10).ToArray();
            ref var item = ref SelectRandom(arr);
            item = 42;
            WriteLine(string.Join(", ", arr));
        }

        private static ref int SelectRandom(int[] arr) {
            var index = new Random().Next(0, 9);
            return ref arr[index];
        }
    }
}