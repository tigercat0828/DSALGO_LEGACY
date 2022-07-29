﻿using DSALGO.DataStructure.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.GraphTheory.FindShortestPath {
    public static  class BellmanFordAlgo  {
        const double UNVISITED = double.MaxValue;
        const double IN_NEGATIVE_CYCLE = double.MinValue;
        static double[] dest;
        static int[] previous;

        private static void Init(int nodeCount) {
            dest = new double[nodeCount];
            Array.Fill(dest, UNVISITED);
            previous = new int[nodeCount];
            Array.Fill(previous, -1);

        }
        
        public static double FindPath(GraphList graph, int start, int end, ref List<int> path) {
            Init(graph.NodeCount);
           
            int loopTime = graph.NodeCount - 1;
            dest[start] = 0;
            for (int i = 0; i < loopTime; i++) {
                foreach (var node in graph.GetAllNodes()) {
                    if (dest[node] == UNVISITED) continue;
                    foreach (var link in graph.GetAdjLinks(node)) {
                        // relaxing
                        if(dest[node] + link.weight < dest[link.to]) {
                            dest[link.to] = dest[node] + link.weight;
                            previous[link.to] = node;
                        }
                    }
                }
            }
            // check node caught in negative cycle
            for (int i = 0; i < loopTime; i++) {
                foreach (var node in graph.GetAllNodes()) {
                    if (dest[node] == UNVISITED) continue;
                    foreach (var link in graph.GetAdjLinks(node)) {
                        // relaxing
                        if (dest[node] + link.weight < dest[link.to]) {
                            dest[link.to] = IN_NEGATIVE_CYCLE;
                        }
                    }
                }
            }

            if (dest[end] != UNVISITED) {
                path = BuildPath(start, end);
                return dest[end];   
            }
            Console.WriteLine($"There is no path from [{start}] to [{end}].");
            return 0;
        }
        public static List<int> BuildPath(int start, int end) {
            List<int> path = new List<int>();
            for (int i = end; i != start ; i= previous[i]) {
                path.Add(i);
            }
            path.Add(start);
            path.Reverse();
            return path; 
        }
        
    }
}