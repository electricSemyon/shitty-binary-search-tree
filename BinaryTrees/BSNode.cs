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
        public int Key { get; }
        public T Data { get; set; }

        public delegate void TraverseLambda(int key, T value);

        public BSNode(int key, T data)
        {
            Data = data;
            Key = key;
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
                if (Left == null) Left = new BSNode<T>(key, value);
                else Left.Insert(key, value);
            }
            else
            {
                if (Right == null) Right = new BSNode<T>(key, value);
                else Right.Insert(key, value);
            }
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

            Console.WriteLine($"({ Key }: { Data })");

            var children = new List<BSNode<T>>();

            if (this.Right != null) children.Add(this.Right);

            if (this.Left != null) children.Add(this.Left);

            for (int i = 0; i < children.Count; i++)
                children[i].PrintPretty(indent, i == children.Count - 1);
        }
    }
}
