using static System.Console;

namespace AdvancedCSharp {

    public class OutVar : ITutorial {

        public void Run() {
            string address1;
            int port1;
            Helper.ReadOptions(out address1, out port1);
            WriteLine($"Old way sucks! Address: {address1}, port: {port1}.");

            Helper.ReadOptions(out string address2, out int port2);
            WriteLine($"Out var rules! Address: {address2}, port: {port2}.");
        }

        public static class Helper {

            public static bool ReadOptions(out string address, out int port) {
                address = "http://umutozel.com";
                port = 80;

                return true;
            }
        }
    }
}