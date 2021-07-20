using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.GraphClass
{
    class EdgeWeightedGraph
    {
        private readonly int V;
        private int E;
        private LinkedList<Edge>[] adj;

        public EdgeWeightedGraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new LinkedList<Edge>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<Edge>();
            }
        }

        public int Vertex() => V;
        public int Edge() => E;

        public void AddEdge(Edge e)
        {
            int v = e.either();
            int w = e.other(v);
            adj[v].AddLast(e);
            adj[w].AddLast(e);
            E++;
        }

        public LinkedList<Edge> AdjacencyList(int v) => adj[v];


        public Stack<Edge> Edges()
        {
            Stack<Edge> stack = new Stack<Edge>();
            for (int v = 0; v < V; v++)
                foreach (Edge e in adj[v])
                    if (e.other(v) > v) stack.Push(e);
            return stack;
        }
    }
}
