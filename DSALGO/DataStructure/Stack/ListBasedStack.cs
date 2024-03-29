﻿namespace DSALGO.DataStructure.Stack {
    public class ListBasedStack : IStack {
        class Node {
            public int data;
            public Node next;
            public Node(int data, Node next) {
                this.data = data;
                this.next = next;
            }
        }
        Node top;
        private int count;
        public int Count => count;
        public ListBasedStack() {
            count = 0;
        }
        public int Pop() {
            if (count == 0) {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            int pop = top.data;
            top = top.next;
            count--;
            return pop;
        }

        public void Push(int data) {
            if (top == null) {
                top = new Node(data, null);
                count = 1;
                return;
            }
            Node node = new Node(data, top);
            top = node;
            count++;
        }

        public int Peek() {
            if (top != null) {
                return top.data;
            }
            return -1;
        }
        public override string ToString() {
            string s = $"[{count}] ";
            Node current = top;
            while (current != null) {
                s += current.data + " -> ";
                current = current.next;
            }
            return s;
        }
    }
}
