using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hideNseek
{
    public class Node
    {
        // Contains the neighbors for each vertex of the graph
        private List<int> neighbors;
        private int weight;

        public Node {
            this.neighbors = new List<int>();
        }

        public int GetWeight
        {
            return weight;
        }

        public int CountNeighbors
        {
            return this.neighbors.size;
        }

        public void AddNeighbor(int x)
        {
            neighbors.Add(x);
        }

        public void RemoveNeighbor(int x)
        {
            neighbors.Remove(x);
        }

        public bool HasNeighbor(int x)
        {
            return neighbors.Contains(x);
        }

        /// <summary>Returns the successors of a given vertex
        /// </summary>
        /// <param name="v">the vertex</param>
        /// <returns>list of all successors of vertex v</returns>
        public IList<int> GetSuccessors()
        {
            return neighbors;
        }
    }
}
