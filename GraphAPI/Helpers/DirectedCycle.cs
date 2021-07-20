using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
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
        public Stack<int> Cycle() => cycle;
    }
}
