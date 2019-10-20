using System;
using static System.Console;

namespace AdvancedCSharp {

    public class NumericImprovements : ITutorial {

        public void Run() {
            var binary = 0b_0101_0101;
            WriteLine($"Binary 0b_0101_0101 in decimal is {binary}.");

            var hex = 0x1b_a0_44_fe;
            WriteLine($"Hexadecimal 0x1b_a0_44_fe in decimal is {hex}.");

            var dec = 33_554_432;
            WriteLine($"33_554_432 is in fact {dec}.");
        }
    }
}