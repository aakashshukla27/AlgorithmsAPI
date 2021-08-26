using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.GraphClass
{
    // graph class
    class Graph
    {
        private readonly int V; // number of vertices
        private int E; // number of edges
        private LinkedList<int>[] adj; // adjacency list

        /// <summary>
        /// Constructor for graph class
        /// </summary>
        /// <param name="V">Number of vertices</param>
        public Graph(int V)
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
        /// Add edges to graph
        /// </summary>
        /// <param name="v">starting point</param>
        /// <param name="w">ending point</param>
        public void addEdge(int v, int w)
        {
            adj[v].AddLast(w);
            adj[w].AddLast(v);
            E++;
        }

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

        /// <summary>
        /// Calculates maximum degree
        /// </summary>
        /// <returns>Maximum Degree</returns>
        public int maxDegree()
        {
            int max = 0;
            for (int i = 0; i < V; i++)
            {
                if (degree(i) > max)
                {
                    max = degree(i);
                }
            }
            return max;
        }
        /// <summary>
        /// Average degree
        /// </summary>
        /// <returns>Average degree of the graph</returns>
        public int averageDegree() => 2 * E / V;

        /// <summary>
        /// Number of self loops
        /// </summary>
        /// <returns>total self loops in the graph</returns>
        public int numberOfSelfLoops()
        {
            int count = 0;
            for (int v = 0; v < V; v++)
            {
                foreach (int w in adjacencyList(v))
                {
                    if (v == w) count++;
                }
            }
            return count / 2; //Each edge is counted twice
        }

        /// <summary>
        /// Prints graph
        /// </summary>
        public void printGraph()
        {
            for (int i = 0; i < adj.Length; i++)
            {
                Console.WriteLine("Adjacency List of vertex " + i);
                Console.Write("head");
                foreach (var item in adj[i])
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            }
        }
    }
}
