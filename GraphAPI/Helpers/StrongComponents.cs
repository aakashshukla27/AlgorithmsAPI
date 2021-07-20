using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class StrongComponents
    {
        private bool[] marked; // reached vertices
        private int[] id; // component identifiers
        private int count; // number of strong components

        public StrongComponents(Digraph G)
        {
            marked = new bool[G.Vertex()];
            id = new int[G.Vertex()];
            // First run dfs on reversed graph and get reverse postorder
            DepthFirstOrder depthFirstOrder = new DepthFirstOrder(G.Reverse());
            var temp = depthFirstOrder.ReversePost();
            foreach (int v in depthFirstOrder.ReversePost())
            {
                if (!marked[v])
                {
                    dfs(G, v);
                    count++;
                }
            }
        }

        private void dfs(Digraph G, int v)
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

        public bool stronglyConnected(int v, int w) => id[v] == id[w]; 
        public int ComponentId(int v) => id[v];
        public int ComponentCount() => count;
    }
}
