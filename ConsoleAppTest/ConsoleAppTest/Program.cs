using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
namespace ConsoleAppTest
{
    class Person
    {
        public int index { get; set; }

    }

    class ComparePerson : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            if (x.index > y.index)
            {
                return 1;
            }
            else if (x.index == y.index)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    class Program
    {
        private delegate int Op(string message,int data);

        static void Main(string[] args)
        {
            //SortedSet<Person> sortPerson = new SortedSet<Person>(new ComparePerson()) {
            //     new Person(){ index = 1},
            //     new Person(){ index = 0},
            //     new Person(){ index = 2}
            //};
            //foreach (var i in sortPerson)
            //{
            //    Console.WriteLine(i.index);

            //    ObservableCollection<Person> obp = new ObservableCollection<Person>() {
            //        new Person(){ index = 11},
            //        new Person(){ index = 9}
            //    };

            //    obp.CollectionChanged += OnCollectionChanged;
            //    obp.Add(new Person() { index = 10 });
            //}

            //string[] words = { "cherry", "apple", "blueberry", "devision", "format", "empty" };
            //string[] digits = { "zero", "1", "two", "three", "four", "five",
            //"six", "seven", "eight", "nine" };
            //int shortestWordLength = words.Min(w => w.Length);
            //var rs = digits.Where((digit, index) => digit.Length < index);
            ////Console.WriteLine(shortestWordLength);
            //foreach (var r in rs) {
            //    Console.WriteLine(r);
            //}

            Op op = new Op(Opreateion);
            IAsyncResult optask = op.BeginInvoke("end invoke", 1, null, null);
            while (!optask.IsCompleted) {
                Console.WriteLine("main thread is running ...");
                Thread.Sleep(500);
            }
            Console.Write("call back {0}", op.EndInvoke(optask));
            Console.ReadLine();
        }

        static int Opreateion(string message, int data) {
            Console.WriteLine("begin invoke");
            Thread.Sleep(3000);
            Console.WriteLine(message);
            return 1;
        }

        public static void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            List<Person> re_P = new List<Person>();
            Console.WriteLine(e.Action);
            var items = e.NewItems;
            for (int i = 0; i < items.Count; i++)
            {
                re_P.Add((Person)items[i]);
            }
            Console.WriteLine();
        }
    }
}