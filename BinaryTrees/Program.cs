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
            BSTree<string> tree = new BSTree<string>(97, "Test");

            tree.Insert(10, "Hello");
            tree.Insert(35, "World");
            tree.Insert(3, "World");


            Console.WriteLine($"Element with key = 10 is { tree.Lookup(10) }");

            Console.WriteLine($"The smallest key is { tree.GetMinKey() }");

            Console.WriteLine("\nBefore deleting:");
            tree.Log();

            tree.Delete(10);
            tree.Delete(3);

            Console.WriteLine("After deleting:");
            tree.Log();

            Console.WriteLine();

            tree.Traverse((key, value) => Console.WriteLine($"{ key }: { value }"));

            Console.ReadKey();
        }
    }
}
