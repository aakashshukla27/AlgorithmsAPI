using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.FlowNetworks
{
    class FlowEdge
    {
        private readonly int v;

        private readonly int w;
        private double capacity;
        private double flow;

        public FlowEdge(int v, int w, double capacity)
        {
            this.v = v;
            this.w = w;
            this.capacity = capacity;
            this.flow = 0;
        }

        public int From() => v;

        public int To() => w;

        public double Capacity() => capacity;

        public double Flow() => flow;

        public int Other(int vertex) => (vertex == v) ? w : v;

        public double ResidualCapacityTo(int vertex)
        {
            if (vertex == v) return flow;
            else if (vertex == w) return capacity - flow;
            else throw new Exception("Inconsistent Edge");
        }

        public void AddResidualFlowTo(int vertex, double delta)
        {
            if (vertex == v) flow -= delta;
            else if (vertex == w) flow += delta;
        }

        public string EdgeToString() => ("%d->%d %.2f %.2f", v, w, capacity, flow).ToString();



    }
}
