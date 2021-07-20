using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class ConnectedComponents 
    {
        private bool[] marked;
        private int[] id;
        private int count = 0;

       

        public ConnectedComponents(Graph G)
        {
            marked = new bool[G.Vertex()];
            id = new int[G.Vertex()];
            for (int s = 0; s < G.Vertex(); s++)
            {
                if (!marked[s])
                {
                    dfs(G, s);
                    count++;
                }
            }
        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (int w in G.adjacencyList(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }
        }

        public bool connected(int v, int w) => id[v] == id[w];

        public int componentNumber(int v) => id[v];

        public int Count() => count;

    }
}
