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
            Graph tes(3);
            tes[1].AddNeighbor(2);
            tes[1].AddNeighbor(3);
            tes[2].AddNeighbor(1);
            tes[3].AddNeighbor(1);
            foreach (int x in tes[1].GetSuccessors())
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
