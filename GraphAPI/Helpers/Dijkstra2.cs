using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class Dijkstra2
    {
        double[] distTo;
        bool[] visited;
        Edge[] edgeTo;

        public Dijkstra2(EdgeWeightedGraph G, int s)
        {
            distTo = new double[G.Vertex()];
            edgeTo = new Edge[G.Vertex()];
            visited = new bool[G.Vertex()];
            for (int i = 0; i < G.Vertex(); i++)
            {
                distTo[i] = Double.PositiveInfinity;
                visited[i] = false;
            }
                
            distTo[s] = 0;
            //visited[s] = true;

            for (int i = 0; i < G.Vertex(); i++)
            {
                //bfs(G, s, distTo);    
                int min = MinDistance(distTo, visited);
                visited[min] = true;
                Relax(G, min);
            }
        }

        private void bfs(EdgeWeightedGraph G, int v, double[] distTo)
        {
            Queue<Edge> queue = new Queue<Edge>();
            foreach(Edge e in G.AdjacencyList(v))
            {                
                int w = (e.either() == v) ? e.other(v) : e.either();

                distTo[w] = e.weight;
            }
        }

        private void Relax(EdgeWeightedGraph G, int v)
        {
            foreach(Edge e in G.AdjacencyList(v))
            {
                int w = e.other(v);
                if(distTo[w] > distTo[v] + e.weight)
                {
                    distTo[w] = distTo[v] + e.weight;
                    edgeTo[w] = e;
                }
            }
        }

        private int MinDistance(double[] distTo, bool[] visited)
        {
            double min = double.PositiveInfinity;
            int minIndex = -1;
            for (int i = 0; i < distTo.Length; i++)
            {
                if((distTo[i] < min) && (visited[i] == false))
                {
                    minIndex = i;
                    min = distTo[i];
                }
            }
            return minIndex;
        }

        public double DistTo(int v) => distTo[v];

        public bool hasPathTo(int v) => distTo[v] < double.PositiveInfinity;
        public Stack<Edge> PathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<Edge> path = new Stack<Edge>();
            for (Edge e = edgeTo[v]; e != null; e = edgeTo[e.other(v)])
                path.Push(e);
            return path;
        }

    }
}
