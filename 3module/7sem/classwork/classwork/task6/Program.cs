using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{

    public class Node<T> where T:IComparable<T>
    {
        public T Value { get; set; }

        public int Cnt { get; private set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Cnt = 1;
        }

        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.Cnt = 1;
        }

        public Node(Node<T> node)
        {
            if (node != null)
            {
                this.Value = node.Value;
                this.LeftChild = node.LeftChild;
                this.RightChild = node.RightChild;
            }
        }

        public bool Exists(T val)
        {
            if (val.CompareTo(this.Value) == 0)
            {
                return true;
            }

            if (val.CompareTo(this.Value) < 0)
            {
                return LeftChild?.Exists(val) ?? false;
            }
            else
            {
                return RightChild?.Exists(val) ?? false;
            }
        }

        public Node<T> MinNodeInSubtree()
        {
            if (this.LeftChild == null)
            {
                return this;
            }
            return this.LeftChild.MinNodeInSubtree();
        }

        public Node<T> Erase(T val)
        {
            if (this == null)
            {
                return null;
            }


            if (this.Value.CompareTo(val) == 0)
            {
                if (this.LeftChild == null)
                {
                    return this.RightChild;
                }
                else if (this.RightChild == null)
                {
                    return this.LeftChild;
                }
                else
                {
                    var minNode = this.RightChild?.MinNodeInSubtree();
                    this.Value = minNode.Value;
                    this.RightChild = this.RightChild.Erase(minNode.Value);
                    return this;
                }
            }
            else
            {
                if (val.CompareTo(this.Value) < 0)
                {
                    this.LeftChild = this.LeftChild?.Erase(val);
                }
                else
                {
                    this.RightChild = this.RightChild?.Erase(val);
                }
                return this;
            }
        }

        public void Insert(T val)
        {

            if (val.CompareTo(this.Value) < 0)
            {
                if (LeftChild != null)
                {
                    LeftChild.Insert(val);
                }
                else
                {
                    LeftChild = new Node<T>(val);
                }
            } 
            else if (val.CompareTo(this.Value) > 0)
            {
                if (RightChild != null)
                {
                    RightChild.Insert(val);
                }
                else
                {
                    RightChild = new Node<T>(val);
                }
            }
            else
            {
                this.Cnt++;
            }
        }
    }

    public class BinaryTree<T> where T:IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public void Insert(T val)
        {
            if (Root == null)
            {
                Root = new Node<T>(val);
            }
            else
            {
                Root.Insert(val);
            }
        }

        public void Erase(T val)
        {
            this.Root = this.Root?.Erase(val);
        }

        public bool Exists(T val)
        {
            return this.Root?.Exists(val) ?? false;
        }

        public string PreOrderDFS(Node<T> node)
        {
            if  (node != null)
            {
                return $"El:{node.Value}, Cnt:{node.Cnt}" + PreOrderDFS(node.LeftChild) + PreOrderDFS(node.RightChild);
            }
            else
            {
                return "";
            }
        }

        public string InOrderDFS(Node<T> node)
        {
            if (node != null)
            {
                return InOrderDFS(node.LeftChild) + $" {node.Value} " + InOrderDFS(node.RightChild);
            }
            else
            {
                return "";
            }
        }

        public string PostOrderDFS(Node<T> node)
        {
            if (node != null)
            {
                return PostOrderDFS(node.LeftChild) + PostOrderDFS(node.RightChild) + $" {node.Value}";
            }
            return "";
        }

        public override string ToString()
        {
            return $"Tree: {PreOrderDFS(this.Root)}";
        }

        public void Clear()
        {
            this.Clear(this.Root);
            this.Root = null;
        }

        private void Clear(Node<T> node)
        {
            if (node.RightChild != null) {
                this.Clear(node.RightChild);
                node.RightChild = null;
            }
            if (node.LeftChild != null)
            {
                this.Clear(node.LeftChild);
                node.LeftChild = null;
            }
            node = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);
            Console.WriteLine(tree.PostOrderDFS(tree.Root));
            Console.WriteLine(tree.InOrderDFS(tree.Root));
            tree.Erase(20);
            Console.WriteLine(tree.InOrderDFS(tree.Root));
            tree.Erase(30);
            Console.WriteLine(tree.InOrderDFS(tree.Root));
            tree.Erase(50);
            Console.WriteLine(tree.InOrderDFS(tree.Root));
            tree.Clear();
            Console.WriteLine(tree.InOrderDFS(tree.Root));
            Console.ReadKey();
        }
    }
}
