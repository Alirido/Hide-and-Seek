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
            Graph tes = new Graph(3);
            tes.AddNode(1, 2);
            tes.AddNode(1, 3);
            foreach (int x in tes.GetSuccessors(1))
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
            var fileStream = new FileStream(@"tes.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadLine();
        }
    }
}
