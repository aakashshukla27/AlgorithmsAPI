using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class LazyPrimMST
    {
        private bool[] marked;
        private Queue<Edge> mst;
        private MinPQ pq;

        public LazyPrimMST(EdgeWeightedGraph G)
        {
            marked = new bool[G.Vertex()];
            mst = new Queue<Edge>();
            pq = new MinPQ(0);
            Visit(G, 0);
            while (!pq.IsEmpty())
            {
                Edge e = pq.delMin();
                int v = e.either();
                int w = e.other(v);
                if (marked[v] && marked[w]) continue;
                mst.Enqueue(e);
                if (!marked[v]) Visit(G, v);
                if (!marked[w]) Visit(G, w);
            }
        }

        private void Visit(EdgeWeightedGraph G, int v)
        {
            marked[v] = true;
            foreach(Edge e in G.AdjacencyList(v))
            {
                if (!marked[e.other(v)])
                    pq.Insert(e);
            }
        }

        public Queue<Edge> MinimumSpanningTree() => mst;

    }
}
