using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Helpers
{
    class TopologicalOrder
    {
        private bool[] marked;
        private Stack<int> reversePost;

        public TopologicalOrder(Digraph G)
        {
            marked = new bool[G.Vertex()];
            reversePost = new Stack<int>();
            DirectedCycle dg = new DirectedCycle(G);
            if (!dg.hasCycle())
            {
                DepthFirstOrder depthFirstOrder = new DepthFirstOrder(G);
                reversePost = depthFirstOrder.ReversePost();
            }
           
        }

        public Stack<int> Order() => reversePost;
        public bool IsDAG() => reversePost == null;
    }
}
