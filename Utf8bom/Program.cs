using System;
using System.Linq;

namespace Utf8bom
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in Directory.GetFiles(Environment.CurrentDirectory, "*.cs", SearchOption.AllDirectories))
            {
                var currentBytes = File.ReadAllBytes(file);
                var bom = new byte[] {239, 187, 191};
                if (!currentBytes.Take(3).ToArray().SequenceEqual(bom))
                {
                    File.WriteAllBytes(file, bom.Concat(currentBytes).ToArray());
                    Console.WriteLine(file.Substring(Environment.CurrentDirectory.Length));
                }
            }
        }
    }
}
