using System.IO;
using System.Text;
using static System.Console;

namespace AdvancedCSharp {

    public class UsingDeclarations : ITutorial {

        public void Run() {
            var str = "Hello, World!";
            var bytes = Encoding.ASCII.GetBytes(str);

            using var stream = new MemoryStream(bytes);
            using var reader = new StreamReader(stream);

            var text = reader.ReadToEnd();
            WriteLine(text);
            // usings will be disposed here (scope ending)
        }
    }
}