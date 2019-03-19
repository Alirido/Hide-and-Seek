using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hideNseek{
    class Program{
        static Graph g;
        static int a,b,c,sol = 0, bobot = 0;
        static int ctr = 0;
        static void Main(string[] args){
            Console.WriteLine("Hide and Seek!");
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.Write("Enter to read the text file...");
            Console.ReadLine();
            using (TextReader r = File.OpenText(args[0])){
                int x = int.Parse(r.ReadLine());
                g = new Graph(x);
                string line;
                while ((line = r.ReadLine()) != null){
                    string[] bits = line.Split(' ');
                    int a = int.Parse(bits[0]);
                    int b = int.Parse(bits[1]);
                    g.AddNode(a, b);
                    //Console.WriteLine(line);
                }
            }
            bool[] visit = new bool[g.Size+1];
            setweight(1,visit);
            g.Print();
            a = 1;
            b = 6;
            c = 5;
        
            foreach (int i in g.nodes[c].GetNeighbors){
                if (g.nodes[c].HasNeighbor(i)){
                    bool[] visited = new bool[g.Size+1];
                    visited[c] = true;
                    Console.Write(c+", ");
                    dfs(i,visited);
                }
            }

            if (sol==1) Console.WriteLine("YA");
            else Console.WriteLine("TIDAK");
            Console.WriteLine();
            Console.Write("Enter to exit...");
            Console.ReadLine();
        }

        static void dfs(int v, bool[] visited){ //pencarian jalur dengan algoritma DFS
            visited[v] = true;
            Console.Write(v);
            for (int w=0; w<g.Size; w++){
                if ((g.nodes[v].HasNeighbor(w)) && (!visited[w])){
                    if (g.nodes[v].HasNeighbor(b) || sol==1){
                        sol = 1;
                        return;
                    }
                    if (a==0 && g.nodes[v].HasNeighbor(1)) return;
                    Console.Write(", ");
                    dfs(w,visited); //rekurens
                }
            }
        }

        static void setweight(int v, bool[] visited){
            visited[v] = true;
            g.nodes[v].weight = bobot;
            Console.Write(v+" ");
            bobot++;
            foreach (int w in g.nodes[v].GetNeighbors){
                if (!visited[w]){
                    g.nodes[w].weight = bobot;
                    visited[w] = true;
                    ctr++;
                }
            }
            if (ctr>=g.Size) return;
            foreach (int w in g.nodes[v].GetNeighbors){
                setweight(w,visited);
            }
        }
    }
}
