using System;

namespace AdvancedCSharp {

    public class Events : ITutorial {

        public void Run() {
            var p = new Printer();
            p.Printed += (sender, args) => Console.WriteLine("Printed: " + args.PrintStr);

            p.Print("Hello, Class!");
        }

        public class Printer {
            public event PrintEventHandler Printed;

            public void Print(string value) {
                Console.WriteLine(value);

                OnPrinted(value);
            }

            protected virtual void OnPrinted(string data) {
                var handler = Printed;
                if (handler != null) {
                    handler.Invoke(this, new PrintEventArgs(data));
                }
            }
        }

        public delegate void PrintEventHandler(object sender, PrintEventArgs e);

        public class PrintEventArgs : EventArgs {

            public PrintEventArgs(string printStr) {
                PrintStr = printStr;
            }

            public string PrintStr { get; }
        }
    }
}
