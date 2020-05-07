using System;
using System.Collections.Generic;
using System.Text;
using CommonTypes;

namespace LibStructures
{
    [ExecuteClass("Связанный список")]
    public struct StructLinkedList
    {
        double[] list;
        int linkedListSize;

        Node head;
        Node tail;

        public void Push(double key)
        {
            Node node = new Node(key);
            node.next = head;
            if (head != null)
            {
                head.prev = node;
            }
            head = node;
            node.prev = null;
        }

        Node ListSearch(double _key)
        {
            Node current = head;
            while (current!=null && current.key != _key)
            {                
                current = current.next;
            }
            return current;
        }
        
        public void Pop(double _key)
        {
            Node node = ListSearch(_key);
            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            {
                head = node.next;
            }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
        }

        public int GetSize
        {
            get { return this.linkedListSize; }
        }

        public void MakeArray()
        {
            Node current = head;
            List<double> nodeList = new List<double>();
            while (current != null)
            {
                nodeList.Add(current.key);
                current = current.next;
            }
            this.list = nodeList.ToArray();
        }

        public double[] GetStruct
        {
            get { this.MakeArray(); return this.list; }
        }
    }

    class Node
    {
        public double key { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node(double _key)
        {
            this.key = _key;
        }
    }
}
