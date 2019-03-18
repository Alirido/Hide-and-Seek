using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hideNseek
{
    public class Graph
    {
        private Node[] nodes;

        // Constructs an empty graph of given size
        // <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.nodes = new Node[size+1];
            for (int i = 0; i <= size; i++)
            {
                // Assign an empty list of adjacents for each vertex
                this.nodes[i] = new Node();
            }
        }

        // Constructs a graph by given list of
        // child nodes (successors) for each vertex
        // <param name="childNodes">children for each node</param>
        public Graph(Node[] nodes)
        {
            this.nodes = nodes;
        }

        // Return the size of the graph (number of vertices)
        public int Size
        {
            get { return (this.nodes.Length-1); }
        }

        public void AddNode(int a, int b)
        {
            this.nodes[a].AddNeighbor(b);
            this.nodes[b].AddNeighbor(a);
        }

        public void RemoveNode(int a, int b)
        {
            this.nodes[a].RemoveNeighbor(b);
            this.nodes[b].RemoveNeighbor(a);
        }

        // Returns the successors of a given vertex
        // <param name="v">the vertex</param>
        // <returns>list of all successors of vertex v</returns>
        public IList<int> GetSuccessors(int v)
        {
            return nodes[v].GetNeighbors;
        }

        public void Print()
        {
            for (int i = 1; i <= this.Size; i++)
            {
                Console.Write("Node-" + i + " neighbors: ");
                foreach (int x in this.GetSuccessors(i))
                {
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
