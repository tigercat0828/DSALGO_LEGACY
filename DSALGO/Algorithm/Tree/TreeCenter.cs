﻿

using DSALGO.DataStructures.Graph;

namespace DSALGO.Algorithm.Tree {
    public static class TreeCenter {
        public static List<int> Get(AdjacencyList graph) {
            Dictionary<int, int> degreeMap = new();
            List<int> leaves = new();

            foreach (var vertex in graph.GetAllNodes()) {
                degreeMap[vertex] = graph[vertex].Count;
                if (graph[vertex].Count <= 1) {
                    leaves.Add(vertex);
                }
            }

            int processLeaves = leaves.Count;
            int total = graph.nodeCount;
            while (processLeaves < total) {
                List<int> newLeaves = new();

                foreach (var leaf in leaves) {

                    foreach (var node in graph[leaf]) {
                        if (--degreeMap[node] == 1) {
                            newLeaves.Add(node);
                        }
                    }

                    degreeMap[leaf] = 0;
                }
                processLeaves += newLeaves.Count;
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
