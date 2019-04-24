using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyApp
{
    class Program
    {
        static string Foo(int x)
        {
            Console.WriteLine("Foo(int x)");
            return "";
        }

        static Guid Foo(double y)
        {
            Console.WriteLine("Foo(double y)");
            return Guid.Empty;
        }

        public void B(out List<int> nums)
        {
            nums = new List<int>() { 1, 2 };
            nums.Add(10);
        }

        static (int, int) GetTime(out int min)
        {
            min = 10;
            return (1, 1);
        }

        public static int Fibonacci(int x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Must be greater than 0", nameof(x));
            }
            return Fib(x).current;

            (int current, int previous) Fib(int n)
            {
                if (n == 0) return (1, 0);
                var (current, previous) = Fib(n - 1);
                return (current + previous, current);
            }
        }

        static void Main(string[] args)
        {
            string temp = "1 2 3";
            //int[] villianEnergy = Array.ConvertAll(temp.Split(' '), sr => int.Parse(sr));
            BA av = new BA();
            AB bc = (AB)av;
            bc.SET();
            av.SET();
            Person p = new Person("John", "Quincy", "Adams", "Boston", "MA");

            // Deconstruct the person object.
            var (fName, lName, city) = p;
            int result1 = Fibonacci(3);
            Console.WriteLine(result1);
            Console.ReadLine();

            (int a, int b) = GetTime(out a);

            Sample s = new Sample();
            Console.Write(s.x);
            Child A = new Child();
            A.Foo(x: 1);


            //Singleton obj1 = Singleton.Instance;
            //Singleton obj2 = Singleton.Instance;
            //A a = new A();
            ////B b = new A();
            //B b = new B();
            //A a1 = new B();

            List<string> voteNames = new List<string>()
            {
                "A", "B", "B", "C", "C", "E", "ZZ", "ZZZ", "AAA"
            };

            Dictionary<string, int> votes = new Dictionary<string, int>();

            foreach (string names in voteNames)
            {
                if (votes.TryGetValue(names, out int value))
                {
                    votes[names] = ++value;
                }
                else
                {
                    votes.Add(names, 1);
                }
            }

            int winnerVote = 0;
            string winner = "";

            foreach (KeyValuePair<string, int> kvp in votes)
            {
                if (kvp.Value > 0 && winnerVote > 0)
                {
                    if (kvp.Value > winnerVote)
                    {
                        winnerVote = kvp.Value;
                        winner = kvp.Key;
                    }
                    else if (kvp.Value == winnerVote)
                    {
                        if (string.Compare(kvp.Key, winner, false) > 0)
                        {
                            winner = kvp.Key;
                            winnerVote = kvp.Value;
                        }
                    }
                }
                else
                {
                    winnerVote = kvp.Value;
                    winner = kvp.Key;
                }
            }

            Console.WriteLine(winner);
            Console.ReadLine();

            //Dictionary<string, int> votes = new Dictionary<string, int>();
            //votes.Add("A", 1);
            //votes.Add("B", 3);
            //votes.Add("C", 3);

            //int maxCount = votes.Values.Max();

            //string result = votes.Where(x => x.Value == maxCount)
            //    .OrderByDescending(x => x.Key).Select(x => x.Key).First();
        }
    }

    class AB
    {
        public AB()
        {

        }
        public void SET()
        {

        }
    }

    class BA : AB
    {

        public new void SET()
        {

        }
    }

    class BAA : BA
    {
        public new void SET()
        {

        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string mname, string lname,
                      string cityName, string stateName)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            City = cityName;
            State = stateName;
        }

        // Return the first and last name.
        public void Deconstruct(out string fname, out string lname, out string city)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
        }
    }


    struct Sample
    {
        public int x;
        public int y;
    }

    class Parent
    {
        public void Foo(int x)
        {
            Console.WriteLine("Parent.Foo(int x)");
        }
    }

    class Child : Parent
    {
        public new void Foo(int y)
        {
            Console.WriteLine("Child.Foo(double y)");
        }
    }

    public sealed class Singleton
    {
        // private static readonly Singleton instance = new Singleton();

        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }

    class A
    {
        public A()
        {

        }

        static A()
        {

        }
    }

    class B : A
    {
        public B()
        {

        }

        static B()
        {

        }
    }
}
