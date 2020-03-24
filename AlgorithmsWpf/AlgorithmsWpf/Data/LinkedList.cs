using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Data
{
    struct StructLinkedList : IStructures
    {
        double[] list;
        int linkedListSize;

        Node head;
        Node tail;

        public void ListInsert(double key)
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

        public Node ListSearch(double _key)
        {
            Node current = head;
            while (current!=null && current.key != _key)
            {                
                current = current.next;
            }
            return current;
        }
        
        public void ListDelete(Node node)
        {
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

        public int Size
        {
            get { return this.linkedListSize; }
        }

        public double[] GetStruct
        {
            get { return this.list; }
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
