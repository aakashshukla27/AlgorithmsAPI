using GraphAPI.GraphClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAPI.Helpers
{
    class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre; //preorder
        private Queue<int> post; //postorder
        private Stack<int> reversePost; //reverse postorder

        public DepthFirstOrder(Digraph G)
        {
            marked = new bool[G.Vertex()];
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            for (int i = 0; i < G.Vertex(); i++)
            {
                if(!marked[i])
                    dfs(G, i);
            }
        }

        private void dfs(Digraph G, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach(int w in G.adjacencyList(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public Queue<int> Preorder() => pre;
        public Queue<int> PostOrder() => post;
        public Stack<int> ReversePost() => reversePost;
    }
}
