using System;

namespace AdvancedCSharp {

    public class Partial : ITutorial {

        public void Run() {
            var s = new Shape();
            
            s.SetData(40, 32);
        }
        
        public partial class Shape {
            public uint Height { get; private set; }
            public uint Width { get; private set; }

            public void SetData(uint height, uint width) {
                this.Height = height;
                this.Width = width;

                Calculate();
            }

            partial void Calculate();
        }

        public partial class Shape {

            partial void Calculate() {
                Console.WriteLine(this.Height * this.Width);
            }
        }
    }
}
