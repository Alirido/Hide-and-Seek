using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hideNseek{
    class Program{
        static Graph g; //representasi graph dengan list tetangga dari simpul-simpulnya
        static int a,b,c,sol = 0, bobot = 0;
        static void Main(string[] args){
            Console.WriteLine("Hide and Seek!\n");
            using (TextReader r = File.OpenText(args[0])){ //membuka file input yang berupa argumen program di command-line
                int x = int.Parse(r.ReadLine());
                g = new Graph(x);
                string line;
                while ((line = r.ReadLine()) != null){
                    string[] bits = line.Split(' ');
                    int a = int.Parse(bits[0]);
                    int b = int.Parse(bits[1]);
                    g.AddNode(a, b);
                }
            }
            setweight(1); //mengatur bobot graph berdasarkan jarak dari istana
            g.Print();
            a = 0;
            b = 9;
            c = 1;

            bool[] visited = new bool[g.Size+1];
            Queue<int> lewat = new Queue<int>(); //jalur yang dilewati
            if (a==1) dfs1(c,visited,lewat);
            else dfs0(c,visited,lewat);

            if (sol==1) Console.WriteLine("\nYA"); //variabel sol menyatakan apakah b ketemu atau tidak
            else Console.WriteLine("\nTIDAK");
        }

        static void dfs0(int v, bool[] visited, Queue<int> lewat){ // jalur yang menuju ke istana
            visited[v] = true;
            lewat.Enqueue(v);
            Console.Write(v+" ");
            if (v==1) return;
            if (v==b){
                sol = 1;
                return;
            }
            foreach (int w in g.nodes[v].GetNeighbors){
                if (!visited[w] && g.nodes[w].GetWeight<g.nodes[v].GetWeight){
                    dfs0(w,visited,lewat); //rekurens
                }
            }
        }

        static void dfs1(int v, bool[] visited, Queue<int> lewat){ //jalur yang menjauhi istana
            visited[v] = true;
            lewat.Enqueue(v);
            Console.Write(v+" ");
            if (v==b){
                sol = 1;
                return;
            }
            foreach (int w in g.nodes[v].GetNeighbors){
                if (!visited[w] && g.nodes[w].GetWeight>g.nodes[v].GetWeight){
                    dfs1(w,visited,lewat); //rekurens
                }
            }
        }

        static void setweight(int v){ //mengatur bobot dari tiap simpul yang menyatakan jarak dari istana
            Queue<int> antri = new Queue<int>();
            List<int> visit = new List<int>();
            antri.Enqueue(v);
            visit.Add(v);
            while (antri.Count!=0){
                int x = antri.Dequeue();
                bobot++;
                foreach (int w in g.nodes[x].GetNeighbors){
                    if (!visit.Contains(w)){
                        antri.Enqueue(w);
                        visit.Add(w);
                        g.nodes[w].weight = bobot;
                    }
                }
            }
        }
    }
}
