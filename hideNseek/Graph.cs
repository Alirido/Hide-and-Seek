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

        /// <summary>Constructs an empty graph of given size</summary>
        /// <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.nodes = new Node[size];
            for (int i = 0; i < size; i++)
            {
                // Assign an empty list of adjacents for each vertex
                this.nodes[i] = new Node();
            }
        }

        /// <summary>Constructs a graph by given list of
        /// child nodes (successors) for each vertex</summary>
        /// <param name="childNodes">children for each node</param>
        public Graph(Node[] nodes)
        {
            this.nodes = nodes;
        }

        /// <summary>
        /// Return the size of the graph (number of vertices)
        /// </summary>
        public int Size
        {
            get { return this.nodes.Length; }
        }
    }
}
