using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Problems
{
    class CanFinishCourses
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Digraph G = new Digraph(numCourses);
            for(int i=0; i<prerequisites.Length; i++)
            {
                G.AddEdge(prerequisites[i][0], prerequisites[i][1]);
            }

            DirectedCycle directedCycle = new DirectedCycle(G);
            return !directedCycle.hasCycle();
        }
    }

    class Digraph
    {
        private int V;
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
        public int Vertex() => V;
        public int Edge() => E;
        public LinkedList<int> adjacencyList(int v) => adj[v];
        public void AddEdge(int i, int j)
        {
            adj[i].AddLast(j);
            E++;
        }
    }

    class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;
        public DirectedCycle(Digraph G)
        {
            onStack = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            marked = new bool[G.Vertex()];
            for (int i = 0; i < G.Vertex(); i++)
            {
                if (!marked[i])
                {
                    dfs(G, i);
                }
            }
        }

        private void dfs(Digraph G, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (int w in G.adjacencyList(v))
            {
                if (this.hasCycle()) return;
                else if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(G, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int i = v; i != w; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }

        public bool hasCycle() => cycle != null;
    }

  
}
