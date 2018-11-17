using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BSTree<T>
    {
        public BSNode<T> Root { set; get; }

        public BSTree(int key, T value)
        {
            Root = new BSNode<T>(key, value, null);
        }

        public void Insert(int key, T value)
        {
            Root.Insert(key, value);
        }

        public void Delete(int key)
        {
            Root.Delete(key);
        }

        public T Lookup(int key)
        {
            return Root.Lookup(key);
        }

        public int GetMinKey()
        {
            return Root.GetMin();
        }

        public void Traverse(BSNode<T>.TraverseLambda fn)
        {
            Root.Traverse(fn);
        }

        public void Log()
        {
            Root.PrintPretty("", false);
        }
    }
}
