using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class Edge
    {
        public readonly int v, w;
        public readonly double weight;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight() => weight;
       

        public int either() => v;

        public int other(int vertex) => (vertex == v) ? w : v;

        public int compareTo(Edge that)
        {
            if (this.weight < that.weight) return -1;
            else if (this.weight > that.weight) return 1;
            else return 0;
        }

        public string EdgeToString() => ("%d-%d %.2f", v, w, weight).ToString();

    }
}
