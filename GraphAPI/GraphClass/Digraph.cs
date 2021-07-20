using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.GraphClass
{
    class Digraph
    {
        private readonly int V;
        private int E;
        private LinkedList<int>[] adj;

        public Digraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new LinkedList<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<int>();
            }
        }

        /// <summary>
        /// Vertex Count
        /// </summary>
        /// <returns>Number of vertices</returns>
        public int Vertex() => V;
        /// <summary>
        /// Edge Count
        /// </summary>
        /// <returns>Number of edges</returns>
        public int Edge() => E;

        /// <summary>
        /// adjacency list of a vertex
        /// </summary>
        /// <param name="v">Vertex number</param>
        /// <returns>Adjacency List of vertex</returns>
        public LinkedList<int> adjacencyList(int v) => adj[v];

        /// <summary>
        /// degree of a vartex
        /// </summary>
        /// <param name="v">Vertex Number</param>
        /// <returns>Returns degree of the vertex</returns>
        public int degree(int v)
        {
            int degree = 0;
            foreach (int w in adjacencyList(v))
            {
                degree++;
            }
            return degree;
        }

        public void AddEdge(int i, int j)
        {
            adj[i].AddLast(j);
            E++;
        }

        public Digraph Reverse()
        {
            Digraph r = new Digraph(V);
            for (int i = 0; i < V; i++)
            {
                foreach (int w in adjacencyList(i))
                {
                    r.AddEdge(w, i);
                }
            }
            return r;
        }
    }
}
