using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Solutions
{
    public class AddTwoNumbers
    {
        
        private class Node<T>
        {
            public Node<T> next;
            public T value;

            public Node(T value)
            {
                this.value = value;
            }
        }

        private class LinkedList<T>
        {
            Node<T> head;

            public void Print()
            {
                Node<T> current = head;

                Console.Write("NULL");

                while (current != null)
                {
                    Console.Write(" -> " + current.value.ToString());
                    current = current.next;
                }
            }
            
            public void Add(T data)
            {
                if (head == null)
                {
                    head = new Node<T>(data);
                    head.next = null;
                }
                else
                {
                    Node<T> node = new Node<T>(data);
                    Node<T> current = head;

                    while (current.next != null)
                    {
                        current = current.next;
                    }

                    current.next = node;
                }
            }
        }

        public static void Solutions()
        {

        }

        public static void Test1()
        {
            var list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Print();
        }
    }
}
