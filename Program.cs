using System;
using System.IO;
using System.Linq;

namespace advanced_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var path = @"C:\Code\github.com\DogusTeknoloji\advanced-csharp";
            var directories = Directory.GetDirectories(path)
                .Select(d => Path.GetFileName(d))
                .Where(d => char.IsNumber(d[0]))
                .ToList();
                
            foreach (var dir in directories) {
                var filePath = Path.Combine(path, dir);
                File.Create(filePath);
            }
        }
    }
}
