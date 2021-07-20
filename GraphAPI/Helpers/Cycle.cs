using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class Cycle
    {
        private bool[] marked;
        private bool hasCycle = false;
        public Cycle(Graph G)
        {
            marked = new bool[G.Vertex()];
            for(int s=0; s<G.Vertex(); s++)
            {
                if (!marked[s])
                {
                    dfs(G, s, s);
                }
            }

        }

        private void dfs(Graph G, int v, int u)
        {
            marked[v] = true;
            foreach (int w in G.adjacencyList(v))
            {
                if (!marked[w])
                {
                    dfs(G, w, v);
                }
                else if(w != u)
                {
                    hasCycle = true;
                }

            }
        }
    }
}
