using System;

namespace AdvancedCSharp {

    public class Events : ITutorial {

        public void Run() {
            var p = new Printer();
            p.Printed += (sender, args) => Console.WriteLine($"Printed: {args.PrintStr}");

            p.Print("Hello, Class!");
        }

        public class Printer {
            public event PrintEventHandler Printed;

            public void Print(string value) {
                Console.WriteLine(value);

                OnPrinted(new PrintEventArgs(value));
            }

            protected virtual void OnPrinted(PrintEventArgs e) {
                var handler = Printed;
                handler?.Invoke(this, e);
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
