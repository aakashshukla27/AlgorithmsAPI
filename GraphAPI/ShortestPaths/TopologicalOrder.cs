using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.ShortestPaths
{
    class TopologicalOrder
    {
        private bool[] marked;
        private Stack<int> reversePost;

        public TopologicalOrder(EdgeWeightedDigraph G)
        {
            marked = new bool[G.Vertex()];
            reversePost = new Stack<int>();

            DirectedCycle cycle = new DirectedCycle(G);
            if (!cycle.hasCycle())
            {
                DepthFirstOrder depth = new DepthFirstOrder(G);
                reversePost = depth.ReversePost();
            }
        }

        public Stack<int> Order() => reversePost;
        public bool IsDAG() => reversePost == null;
    }
}
