﻿
using DSALGO.DataStructure.Graph;

namespace DSALGO.Algorithm.GraphTheory {
    /// <summary>
    /// For DAG, Directed Acyclic Graph
    /// </summary>
    public class TopologicalSort {
        bool[] isVisited;
        int[] result;
        int nodeCount;
        int current;
        readonly Graphz graph;
        public TopologicalSort(Graphz graph) {
            this.graph = graph;
            nodeCount = graph.nodeCount;
            isVisited = new bool[nodeCount];
            result = new int[nodeCount];
            current = nodeCount - 1;
        }
        public int[] Topsort() {
            List<int> nodes = graph.GetAllNodes();
            
            foreach (var node in nodes) {
                if (isVisited[node]) continue;
                DFS(node);
            }
            return result;
        }
        private void DFS(int node) {
            if (isVisited[node]) return;
            isVisited[node] = true;
            List<int> linked = graph.GetAdjacentNode(node);
            foreach (var dest in linked) {
                if (isVisited[dest]) continue;
                DFS(dest);
            }
            result[current--] = node;
        }

        
    }
}