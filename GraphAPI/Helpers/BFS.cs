using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class BFS
    {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;

        public BFS(Graph G, int s)
        {
            marked = new bool[G.Vertex()];
            edgeTo = new int[G.Vertex()];
            this.s = s;
        }

        private void bfs(Graph G, int S)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(S);
            marked[S] = true;
            while (queue.Any())
            {
                int v = queue.Dequeue();
                foreach(int w in G.adjacencyList(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public bool hasPathTo(int v)
        {
            return marked[v];
        }
        public Stack<int> pathTo(int v)
        {
            if (!hasPathTo(v))
            {
                return null;
            }
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
    }
}
