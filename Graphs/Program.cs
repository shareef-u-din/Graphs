using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(3);
            //graph.AddEdge(0, new int[] { 1, 3 });
            //graph.AddEdge(1, new int[] { 0, 2 });
            //graph.AddEdge(2, new int[] { 1, 3 });
            //graph.AddEdge(3, new int[] { 0, 2, 4 });
            //graph.AddEdge(4, new int[] { 1, 3 });
            //graph.AddEdge(5, new int[] { 3, 6 });
            //graph.AddEdge(6, new int[] { 5 });
            graph.AddEdge(0, new int[] { 1, 2 });
            graph.AddEdge(1, new int[] {  2 });
            graph.AddEdge(2, new int[] { });

            Console.WriteLine(graph.UndirectedHasCycle());

            //var x = graph.adjacencyList;
            //var depthFirt = graph.DFS();

            //Console.Write("Depth First: ");
            //for (int i = 0; i < depthFirt.Count; i++)
            //{
            //    Console.Write(depthFirt.ElementAt(i));
            //    Console.Write(i == depthFirt.Count - 1 ? "" : " -> ");
            //}
            //Console.WriteLine();
            //Console.Write("Breadth First: ");
            //var breadthFirst = graph.BFS();
            //for (int i = 0; i < breadthFirst.Count; i++)
            //{
            //    Console.Write(breadthFirst.ElementAt(i));
            //    Console.Write(i == breadthFirst.Count - 1 ? "" : " -> ");
            //}
            Console.ReadKey();
        }
    }
}
