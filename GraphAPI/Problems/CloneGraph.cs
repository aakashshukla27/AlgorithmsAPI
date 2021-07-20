using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Problems
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    class CloneGraph
    {
        public Node CloneGraphSolution(Node node)
        {
            if (node == null) return null;

            Dictionary<Node, Node> returnList = new Dictionary<Node, Node>();
            Queue<Node> queue = new();
            returnList.Add(node, new Node(node.val));

            queue.Enqueue(node);

            while (queue.Any())
            {
                Node temp = queue.Dequeue();
                foreach(var item in temp.neighbors)
                {
                    if (!returnList.ContainsKey(item))
                    {
                        returnList.Add(item, new Node(item.val));
                        queue.Enqueue(item);
                    }
                    returnList[temp].neighbors.Add(returnList[item]);
                }
            }
           
            return returnList[node];
        }

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        public Node CloneGraphAlter(Node node)
        {
            if (node == null) return null;
            if (!map.ContainsKey(node))
            {
                map.Add(node, new Node(node.val));
                foreach (var nei in node.neighbors)
                {
                    map[node].neighbors.Add(CloneGraphAlter(nei));
                }
            }
            return map[node];
        }

        public void bfs(Node node)
        {

        }

       

    }

}



