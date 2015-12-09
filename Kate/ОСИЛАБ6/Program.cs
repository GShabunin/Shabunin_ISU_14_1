using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static IList<Thread> _thread = new List<Thread>();
        static Queue<Thread> _queueToPrinter = new Queue<Thread>();
        static Queue<Thread> _queueToFiles = new Queue<Thread>();
        static List<int> files = new List<int>();
        static int _printer = 1;
        static int secfile = 1;
        static readonly object _locking= new object();
        static readonly Random _random= new Random();



        static void tr()
        {
            while (true)
            {
                int numfile = _random.Next(0, 2);
                Getfile(numfile);
            }
        }
        static void Getfile
        static void Main(string[] args)
        {
        }
    }
}
