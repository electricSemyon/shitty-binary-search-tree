using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BSNode<T>
    {
        public BSNode<T> Left { get; set; }
        public BSNode<T> Right { get; set; }
        public BSNode<T> Parent { get; set; }
        public int Key { get; set; }
        public T Data { get; set; }

        public delegate void TraverseLambda(int key, T value);

        public BSNode(int key, T data, BSNode<T> parent)
        {
            Data = data;
            Key = key;
            Parent = parent;
        }

        public void Insert(int key, T value)
        {
            if (Key == key)
            {
                Data = value;
                return;
            }

            if (key < Key)
            {
                if (Left == null) Left = new BSNode<T>(key, value, this);
                else Left.Insert(key, value);
            }
            else
            {
                if (Right == null) Right = new BSNode<T>(key, value, this);
                else Right.Insert(key, value);
            }
        }

        private void ReplaceNodeInParent(BSNode<T> newValue = null)
        {
            if (Parent != null)
            {
                if (this == Parent.Left) Parent.Left = newValue;
                else Parent.Right = newValue;
            }
            if (newValue != null) newValue.Parent = Parent;
        }

        public void Delete(int key)
        {

            if (key < Key && Left != null) { Left.Delete(key); return; };
            if (key > Key && Right != null) { Right.Delete(key); return; };

            if (Right != null && Left != null)
            {
                BSNode<T> successor = Right.GetMinNode();
                Key = successor.Key;
                successor.Delete(successor.Key);
            }
            else if (Right == null) ReplaceNodeInParent(Left);
            else if (Left == null) ReplaceNodeInParent(Right);
            else ReplaceNodeInParent();
        }
        
        public T Lookup(int key)
        {
            if (Key == key) return Data;

            if (key < Key)
            {
                if (Left == null) return default(T);
                else return Left.Lookup(key);
            }
            else
            {
                if (Right == null) return default(T);
                else return Right.Lookup(key);
            }
        }

        public int GetMin()
        {
            if (Left == null) return Key;
            return Left.GetMin();
        }

        public BSNode<T> GetMinNode()
        {
            if (Left == null) return this;
            return Left.GetMinNode();
        }

        public void Traverse(TraverseLambda fn)
        {
            if (Left != null) Left.Traverse(fn);

            fn(Key, Data);

            if (Right != null) Right.Traverse(fn);
        }

        public void PrintPretty(string indent, bool last)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            Console.WriteLine(Key);

            var children = new List<BSNode<T>>();

            if (this.Right != null) children.Add(this.Right);

            if (this.Left != null) children.Add(this.Left);

            for (int i = 0; i < children.Count; i++)
                children[i].PrintPretty(indent, i == children.Count - 1);
        }
    }
}
