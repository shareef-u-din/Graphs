using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        public Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        private int verticies;

        public Graph(int v)
        {
            verticies = v;
            for (int i = 0; i < v; i++)
            {
                adjacencyList.Add(i, new List<int>());
            }
        }
        public Graph(int v, int[][] array)
        {
            verticies = v;
            int i = 0;
            foreach (var item in array)
            {
                AddEdge(i, item);
            }
        }

        public void AddEdge(int u, int[] linkedVerticies)
        {
            for (int i = 0; i < linkedVerticies.Length; i++)
            {
                //adjacencyList[u] returns list to store connected vertices
                adjacencyList[u].Add(linkedVerticies[i]);
            }
        }

        public bool UndirectedHasCycle()
        {
            int parent = -1;
            bool[] visited = new bool[verticies];
            Stack<int> stack = new Stack<int>();

            //Loop through every element (Graph can be disconnected)
            for (int i = 0; i < verticies; i++)
            {
                //Get the first vertex from adjacency list
                int nodeInAdjList = adjacencyList.ElementAt(i).Key;
                //if vertex is already visited, continue with next vertex
                if (visited[i]) continue;
                //push the vertex into stack
                stack.Push(nodeInAdjList);

                while (stack.Count > 0)
                {
                    //take the vertex back and remove from stack
                    int current = stack.Pop();
                    
                    //make the vertex visited
                    visited[current] = true;

                    //push all the linked vertex with the current vertex into stack
                    foreach (var item in adjacencyList[current])
                    {
                        if (visited[item])
                        {
                            if (parent != item) return true;
                            continue;
                        }
                        parent = current;
                        stack.Push(item);
                    }
                }
            }
            return false;
        }

        public List<int> DFS()
        {
            Stack<int> stack = new Stack<int>();
            List<int> nodes = new List<int>();
            bool[] visited = new bool[verticies];

            //Loop through every element (Graph can be disconnected)
            for (int i = 0; i < verticies; i++)
            {
                //Get the first vertex from adjacency list
                int nodeInAdjList = adjacencyList.ElementAt(i).Key;

                //if vertex is already visited, continue with next vertex
                if (visited[i]) continue;

                //push the vertex into stack
                stack.Push(nodeInAdjList);

                while (stack.Count > 0)
                {
                    //take the vertex back, remove from stack
                    int current = stack.Pop();
                    //if vertex is already visited, continue with next vertex from stack
                    if (visited[current]) continue;

                    //make the vertex visited
                    visited[current] = true;
                    //add the visited vertex to output list
                    nodes.Add(current);

                    //push all the linked vertex with the current vertex into stack
                    //As the adjacencyList[current] returns back list, we can sort it and do the desired 
                    //push if we want least element to be pushed first or last
                    foreach (var item in adjacencyList[current])
                    {
                        stack.Push(item);
                    }
                }
                //if the Graph is connected, all the element are added to list 
                //we can break the loop
                if (nodes.Count == verticies) break;
            }
            return nodes;
        }


        public List<int> BFS()
        {
            Queue<int> queue = new Queue<int>();
            List<int> nodes = new List<int>();
            bool[] visited = new bool[verticies];

            //Loop through every element (Graph can be disconnected)
            for (int i = 0; i < verticies; i++)
            {
                //Get the first vertex from adjacency list
                int nodeInAdjList = adjacencyList.ElementAt(i).Key;

                //if vertex is already visited, continue with next vertex
                if (visited[i]) continue;

                //push the vertex into queue
                queue.Enqueue(nodeInAdjList);

                while (queue.Count > 0)
                {
                    //take the vertex back and remove from queue
                    int current = queue.Dequeue();
                    //if vertex is already visited, continue with next vertex from queue
                    if (visited[current]) continue;

                    //make the vertex visited
                    visited[current] = true;
                    //add the visited vertex to output list
                    nodes.Add(current);

                    //push all the linked vertex with the current vertex into queue
                    //As the adjacencyList[current] returns back list, we can sort it and do the desired 
                    //push if we want least element to be pushed first or last
                    foreach (var item in adjacencyList[current])
                    {
                        queue.Enqueue(item);
                    }
                }
                //if the Graph is connected, all the element are added to list 
                //we can break the loop
                if (nodes.Count == verticies) break;
            }
            return nodes;
        }


    }
}
