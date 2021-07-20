using Graphs.Helpers;
using Graphs.Problems;
using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            EdgeWeightedGraph edgeWeightedGraph = new EdgeWeightedGraph(8);

            List<Edge> list = new List<Edge>();
            list.Add(new Edge(0, 7, 0.16));
            list.Add(new Edge(2, 3, 0.17));
            list.Add(new Edge(1, 7, 0.19));
            list.Add(new Edge(0, 2, 0.26));
            list.Add(new Edge(5, 7, 0.28));
            list.Add(new Edge(1, 3, 0.29));
            list.Add(new Edge(1, 5, 0.32));
            list.Add(new Edge(2, 7, 0.34));
            list.Add(new Edge(4, 5, 0.35));
            list.Add(new Edge(1, 2, 0.36));
            list.Add(new Edge(4, 7, 0.37));
            list.Add(new Edge(0, 4, 0.38));
            list.Add(new Edge(6, 2, 0.40));
            list.Add(new Edge(3, 6, 0.52));
            list.Add(new Edge(6, 0, 0.58));
            list.Add(new Edge(6, 4, 0.93));

            for (int i = 0; i < list.Count; i++)
            {
                edgeWeightedGraph.AddEdge(list[i]);
            }


            //LazyPrimMST prim = new LazyPrimMST(edgeWeightedGraph);
            //var temp = prim.MinimumSpanningTree();
            //foreach(var item in temp)
            //{
            //    Console.WriteLine(item.v + " -> " + item.w + " : " + item.weight);
            //}

            //int[][] temp = new int[10][];
            //temp[0] = new int[2] { 1, 2 };
            //temp[1] = new int[2] { 2, 3 };

            //for (int i = 0; i < temp.Length; i++)
            //{
            //    int temp1 = temp[0][0];
            //}
            //int[][] arr = new int[1][];
            //arr[0] = new int[2] { 1,0 };
            ////arr[1] = new int[2] { 0, 1 };
            //CanFinishCourses can = new CanFinishCourses();
            //can.CanFinish(2, arr);


        }
    }
}
