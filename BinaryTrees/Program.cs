using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree<string> tree = new BSTree<string>(new BSNode<string>(1, "Test"));

            tree.Insert(8, "Hello");
            tree.Insert(4, "World");
            tree.Insert(10, "Hey");
            tree.Insert(2, "Dude");
            tree.Insert(12, "I'm drunk");

            tree.Log();

            Console.WriteLine($"Element with key = 10 is { tree.Lookup(10) }");

            Console.WriteLine($"The smallest key is { tree.GetMinKey() }");

            Console.WriteLine();

            tree.Traverse((key, value) => Console.WriteLine($"{ key }: { value }"));

            Console.ReadKey();
        }
    }
}
