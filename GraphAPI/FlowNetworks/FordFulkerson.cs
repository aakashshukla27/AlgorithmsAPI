using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.FlowNetworks
{
    class FordFulkerson
    {
        private bool[] marked;
        private FlowEdge[] edgeTo;
        private double value;

        public FordFulkerson(FlowNetwork G, int s, int t)
        {
            while (HasAugmentingPath(G, s, t))
            {
                double bottle = double.PositiveInfinity;
                for(int v = t; v!=s; v= edgeTo[v].Other(v))
                {
                    bottle = Math.Min(bottle, edgeTo[v].ResidualCapacityTo(v));
                }

                for(int v = t; v != s; v = edgeTo[v].Other(v))
                {
                    edgeTo[v].AddResidualFlowTo(v, bottle);
                }
                value += bottle;
            }
        }

        private bool HasAugmentingPath(FlowNetwork G, int s, int t)
        {
            marked = new bool[G.Vertex()];
            edgeTo = new FlowEdge[G.Vertex()];
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            while (queue.Any())
            {
                int v = queue.Dequeue();
                foreach(FlowEdge e in G.AdjacencyList(v))
                {
                    int w = e.Other(v);
                    if(e.ResidualCapacityTo(w) > 0 && !marked[w])
                    {
                        edgeTo[w] = e;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
            return marked[t];
        }

        public double Value() => value;
        public bool InCut(int v) => marked[v]; 
    }
}
