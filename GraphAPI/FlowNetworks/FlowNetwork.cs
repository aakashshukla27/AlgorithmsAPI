using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.FlowNetworks
{
    class FlowNetwork
    {
        private int V;
        private int E;
        private List<FlowEdge>[] adj;

        public FlowNetwork(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new List<FlowEdge>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<FlowEdge>();
            }
        }

        public int Vertex() => V;

        public int Edge() => E;

        public void AddEdge(FlowEdge e)
        {
            int v = e.From();
            int w = e.To();
            adj[v].Add(e);
            adj[w].Add(e);
            E++;
        }

        public List<FlowEdge> AdjacencyList(int v) => adj[v];

        public List<FlowEdge> Edges()
        {
            List<FlowEdge> list = new List<FlowEdge>();
            for (int i = 0; i < V; i++)
            {
                foreach (var item in AdjacencyList(i))
                {
                    if(item.To() != i)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }


        public string NetworkToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(V + " " + E + "\n");
            for (int v = 0; v < V; v++)
            {
                s.Append(v + ":  ");
                foreach (FlowEdge e in adj[v])
                {
                    if (e.To() != v) s.Append(e + "  ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}
