﻿using System;
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

        public Node() {
            this.neighbors = new List<int>();
            this.weight = 0;
        }

        public int GetWeight
        {
            get { return weight; }
        }

        public int CountNeighbors
        {
            get { return this.neighbors.Count; }
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

        public List<int> GetNeighbors
        {
            get { return neighbors; }
        }
    }
}
