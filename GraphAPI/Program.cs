using GraphAPI.GraphClass;
using GraphAPI.Helpers;
using System;
using System.Collections.Generic;

namespace GraphAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            EdgeWeightedGraph edgeWeightedDigraph = new EdgeWeightedGraph(8);

            List<Edge> list = new List<Edge>();

            list.Add(new Edge(0, 1, 1));
            list.Add(new Edge(0, 6, 12));
            list.Add(new Edge(0, 5, 10));
            list.Add(new Edge(6, 4, 12));
            list.Add(new Edge(6, 7, 5));
            list.Add(new Edge(6, 3, 18));
            list.Add(new Edge(3, 4, 6));
            list.Add(new Edge(4, 7, 5));
            list.Add(new Edge(1, 2, 4));
            for (int i = 0; i < list.Count; i++)
            {
                edgeWeightedDigraph.AddEdge(list[i]);
            }

            Dijkstra2 dijkstra2 = new Dijkstra2(edgeWeightedDigraph, 0);
            var temp = dijkstra2.PathTo(4);
        }
    }
}
