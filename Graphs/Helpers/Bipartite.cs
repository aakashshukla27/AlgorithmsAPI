using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class Bipartite
    {
        private bool[] marked;
        private bool[] color;
        private bool isBipartiteGraph = true;

        public Bipartite(Graph G)
        {
            marked = new bool[G.Vertex()];
            color = new bool[G.Vertex()];
            for(int s =0; s<G.Vertex(); s++)
            {
                if (!marked[s])
                {
                    dfs(G, s);
                }
            }
        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            foreach(int w in G.adjacencyList(v))
            {
                if (!marked[w])
                {
                    color[w] = !color[v];
                    dfs(G, w);
                }
                else if(color[w] == color[v])
                {
                    isBipartiteGraph = false;
                }
            }
        }

        public bool isBipartite() => isBipartiteGraph;
    }
}
