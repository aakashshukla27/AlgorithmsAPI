using GraphAPI.GraphClass;
using GraphAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.ShortestPaths
{
    class AcyclicShortestPath
    {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        IndexMinPQ pq;
        public AcyclicShortestPath(EdgeWeightedDigraph G, int s)
        {
            edgeTo = new DirectedEdge[G.Vertex()];
            distTo = new double[G.Vertex()];
            pq = new IndexMinPQ(G.Vertex());

            for (int i = 0; i < G.Vertex(); i++)
            {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[s] = 0;
            TopologicalOrder topological = new TopologicalOrder(G);

            foreach (int v in topological.Order())
            {
                Relax(G, v);
            }

        }

        private void Relax(EdgeWeightedDigraph G, int v)
        {
            foreach (DirectedEdge e in G.AdjacencyList(v))
            {
                int w = e.To();
                if (distTo[w] > distTo[v] + e.weight)
                {
                    distTo[w] = distTo[v] + e.weight;
                    edgeTo[w] = e;
                    if (pq.contains(w)) pq.changeKey(w, distTo[w]);
                    else pq.insert(w, distTo[w]);
                }
            }
        }

        public double DistTo(int v) => distTo[v];

        public bool hasPathTo(int v) => distTo[v] < double.PositiveInfinity;
        public Stack<DirectedEdge> PathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From()])
                path.Push(e);
            return path;
        }
    }
}
