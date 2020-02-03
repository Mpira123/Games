using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp52
{
    class Program
    {
        public static int count, L = 8;
        public static string phnum;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] telef = new string[L];
            Tree tr = new Tree();
            for (int i = 0; i < N; i++)
            {
                Cell cur = tr.Root;
                phnum = Console.ReadLine();
                foreach (char x in phnum)
                {
                    int digit = x - '0';
                    tr.Add(x, cur);
                }
            }
            tr.Count();
        }
        class Cell
        {

            Cell[] sons = new Cell[10];


            public void Add(int newval)
            {
                if (sons[newval] == null)
                    sons[newval] = new Cell();
            }
        }


        class Tree
        {
            public Cell Root;
            public Tree()
            {
                Root = new Cell();
            }
            public void Add(int newval, Cell cur)
            {
                cur.Add(newval);
            }
            public int Count() => count;
        }
    }
}