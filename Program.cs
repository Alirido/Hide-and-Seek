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
            Console.Write("File loaded, press enter...");
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
                    List<int> lewat = new List<int>();
                    visited[c] = true;
                    lewat.Add(c);
                    dfs(i,visited,lewat);
                }
            }

            if (sol==1) Console.WriteLine("\nYA");
            else Console.WriteLine("\nTIDAK");
            Console.WriteLine();
        }

        static void dfs(int v, bool[] visited, List<int> lewat){ //pencarian jalur dengan algoritma DFS
            visited[v] = true;
            lewat.Add(v);
            for (int w=0; w<g.Size; w++){
                if ((g.nodes[v].HasNeighbor(w)) && (!visited[w])){
                    if (g.nodes[v].HasNeighbor(b) || sol==1){
                        sol = 1;
                        return;
                    }
                    if (a==0 && g.nodes[v].HasNeighbor(1)) return;
                    dfs(w,visited,lewat); //rekurens
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
                if (!visited[w]) setweight(w,visited);
            }
        }
    }
}
