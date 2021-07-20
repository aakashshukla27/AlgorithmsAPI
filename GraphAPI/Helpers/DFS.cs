using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class DFS
    {
        private bool[] marked; //Has DFS been called to this vertex?
        private int[] edgeTo; //Last vertex on known path to this vertex
        private readonly int s; //source

        public DFS(Graph G, int s)
        {
            marked = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            this.s = s;
            dfs(G, s);
        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            foreach (int w in G.adjacencyList(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(G, w);
                }
            }
        }

        private void dfsIterative(Graph G, int v)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(v);
            marked[v] = true;
            while (stack.Any())
            {
                v = stack.Pop();

                foreach (int w in G.adjacencyList(v))
                {
                    edgeTo[w] = v;
                    marked[w] = true;
                    stack.Push(w);
                }
            }
        }

        public bool hasPathTo(int v) => marked[v];

        public Stack<int> PathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for(int x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
    }
}
