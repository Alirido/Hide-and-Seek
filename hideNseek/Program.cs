using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hideNseek
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hide and Seek!");
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.Write("Enter to read the text file...");
            Console.ReadLine();
            using (TextReader r = File.OpenText("test.txt"))
            {
                int x = int.Parse(r.ReadLine());
                Graph g = new Graph(x);
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] bits = line.Split(' ');
                    int a = int.Parse(bits[0]);
                    int b = int.Parse(bits[1]);
                    g.AddNode(a, b);
                    //Console.WriteLine(line);
                }
                g.Print();
            }

            //var fileStream = new FileStream(@"test.txt", FileMode.Open, FileAccess.Read);
            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            //{
            //    string line;
            //    while ((line = streamReader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            Console.WriteLine();
            Console.Write("Enter to exit...");
            Console.ReadLine();
        }
    }
}
