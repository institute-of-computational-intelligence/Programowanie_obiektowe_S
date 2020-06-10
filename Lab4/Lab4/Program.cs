using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new MyList<int>();
            l.Add(3);
            l.Add(1);

            Console.WriteLine($"Pierwszy element listy {l[0]}");

            l.RemoveAt(0);
            Console.WriteLine($"Pierwszy element listy {l[0]}");

            l.Insert(0, 12);
            Console.WriteLine($"Pierwszy element listy {l[0]}");

            Console.ReadKey();

            var list = new MyList<Person>
            {
                new Person("Jan", "Kowalski", 12),
                new Person("Ala", "Nowak", 32),
                new Person("Maja", "Marchewka", 14),
                new Person("Jakub", "Kowalski", 17),
                new Person("Janusz", "Nosacz", 65),
            };

            Console.WriteLine("\nPeople:");
            int i = 0;
            foreach (var e in list)
            {
                Console.WriteLine($"\t[{++i}] => {e}");
            }

            Console.WriteLine("\nWoman:");
            var sublist = list.Where(e => e.Firstname.EndsWith("a"));
            sublist.ToList().ForEach(e => Console.WriteLine(e));

            Console.ReadKey();

			Person p1 = new Person("Jan", "Kowalski", 12);
			Person p2 = new Person("Ala", "Nowak", 32);
			Person p3 = new Person("Maja", "Marchewka", 14);
			Person p4 = new Person("Jakub", "Kowalski", 17);
			Person p5 = new Person("Janusz", "Nosacz", 65);

			MyList<Person> myList = new MyList<Person>();
			
			myList.Insert(0, p1);
			myList.Add(p2);
			myList.Insert(2, p3);
			myList.Insert(1, p4);
			myList.Add(p5);
			
			Console.WriteLine("\r\nPeople List:");
			Console.WriteLine(String.Join("\r\n", myList));
			Console.ReadKey();

			Console.WriteLine("\r\nPeople aged 18 or more:");
			Console.WriteLine(String.Join("\r\n", myList.Where(e => e.Age >= 18).ToList()));
			Console.ReadKey();

			myList.Remove(p1);
			myList.RemoveAt(0);
			
			Console.WriteLine("\r\nRemoving People:");
			Console.WriteLine(String.Join("\r\n", myList));
			Console.ReadKey();

			IEnumerable<Person> myDuplexList = new MyDuplexList<Person>();
			((MyDuplexList<Person>)myDuplexList).Insert(0, p1);
			((MyDuplexList<Person>)myDuplexList).Add(p2);
			((MyDuplexList<Person>)myDuplexList).Insert(2, p3);
			((MyDuplexList<Person>)myDuplexList).Insert(1, p4);
			((MyDuplexList<Person>)myDuplexList).Add(p5);

			Console.WriteLine("\r\nForeach:");

			foreach (Person p in myDuplexList)
				Console.WriteLine(p);
			Console.ReadKey();

			Console.WriteLine("\r\nBackwards:");
			
			MyDuplexListBackward<Person> bw = new MyDuplexListBackward<Person>();
			
			foreach (Person p in myDuplexList)
				bw.Add(p);
			
			foreach (Person p in bw)
				Console.WriteLine(p);
			Console.ReadKey();

			Console.WriteLine("\r\nPeople aged 18 or more [Duplex List]:");
			Console.WriteLine(String.Join("\r\n", myDuplexList.Where(e => e.Age >= 18).ToList()));
			Console.ReadKey();

			((MyDuplexList<Person>)myDuplexList).Remove(p1);
			((MyDuplexList<Person>)myDuplexList).RemoveAt(0);
			
			Console.WriteLine("\r\nRemoving People [Duplex List]:");
			Console.WriteLine(String.Join("\r\n", myDuplexList));
			Console.ReadKey();

			Console.WriteLine("\r\nTree:");
			
			MyTree<Person> myTree = new MyTree<Person>();
			Person p6 = new Person("Żabson", "Ziomal", 71);

			TreeNode<Person> boss = new TreeNode<Person>();
			
			boss.Value = p5;
			boss.AddChild(p1);
			boss.AddChild(p2);
			boss.AddChild(p3);
			boss.AddChild(p4).AddChild(p6);
			myTree.Root = boss;

			List<Person> company = myTree.ToList();
			foreach (Person p in company)
				Console.WriteLine(p);

			Console.ReadKey();
		}
    }
}
