using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphAPI.GraphClass;
using GraphAPI.Helpers;

namespace GraphAPI.Helpers
{
    class KruskalMST
    {
        private Queue<Edge> mst;
        public KruskalMST(EdgeWeightedGraph G)
        {
            mst = new Queue<Edge>();
            MinPQ pq = new MinPQ(G.Edges().Count);
            var temp = G.Edges();
            while (temp.Any())
            {
                pq.Insert(temp.Pop());
            }

            UnionFind uf = new UnionFind(G.Vertex());
            while(!pq.IsEmpty() && mst.Count() < G.Vertex() - 1)
            {
                Edge e = pq.delMin();
                int v = e.either();
                int w = e.other(v);
                if (uf.Connected(v, w)) continue;
                uf.Union(v, w);
                mst.Enqueue(e);               
            }
        }

        public Queue<Edge> MinimumSpanningTree() => mst;
    }
}
