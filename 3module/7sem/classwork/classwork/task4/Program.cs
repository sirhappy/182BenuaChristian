using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{

    class Stack<T>
    {
        private static int MaxStackSize = 100;
        private T[] arr = new T[MaxStackSize];
        public int TopPosition { get; private set; }

        public Stack()
        {
            this.TopPosition = 0;
        }

        public void Push(T item)
        {
            if (this.TopPosition + 1 >= MaxStackSize)
            {
                throw new Exception("Stack overflow");
            }

            arr[++TopPosition] = item;
        }

        public void Pop<T>()
        {
            if (this.TopPosition == 0)
            {
                throw new Exception("Trying to pop stack when stack is empty");
            }

            this.TopPosition--;
        }

        public T Top()
        {
            return arr[this.TopPosition];
        }
    }

    

    public class Queue<T>
    {
        public class Node
        {
            public Node Next { get; set; }

            public T Value { get; set; }

            public Node(T val)
            {
                this.Value = val;
            }
        }

        Node First { get; set; }
        Node Last { get; set; }
        
        public int Capacity { get; set; }

        public bool IsEmpty => First == null;

        public void Enqueue(T item)
        {
            if (Capacity == 0)
            {
                First = new Node(item);
                Last = First;
            }
            else
            {
                Node newNode = new Node(item);
                Last.Next = newNode;
                Last = newNode;
            }
            Capacity++;
        }

        public T Front()
        {
            if (First == null)
            {
                throw new Exception("Queue is empty");
            }
            return First.Value;
        }

        public void Dequeue()
        {
            this.First = this.First.Next;
            Capacity--;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Stack<int> st = new Stack<int>();

            st.Push(15);
            Console.WriteLine(st.Top());

            st.Pop<int>();

            try
            {
                st.Pop<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Stack<double> kek = new Stack<Double>();
            kek.Push(Math.PI);
            Console.WriteLine(kek.Top());*/

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            Console.WriteLine(q.Front());
            q.Enqueue(2);
            Console.WriteLine(q.Front());
            Console.WriteLine(q.Capacity);
            q.Dequeue();
            Console.WriteLine(q.Front());
            q.Dequeue();
            Console.WriteLine(q.Capacity);
        }
    }
}
