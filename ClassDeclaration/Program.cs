using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDeclaration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Persons = new List<Person>();

            Person myPerson1 = new Person();
            Person myPerson2 = new Person();
            Person myPerson3 = new Person();
            Person myPerson4 = new Person();
            Person myPerson5 = new Person();
            Person myPerson6 = new Person();

            Persons.Add(myPerson1);
            Persons.Add(myPerson2);
            Persons.Add(myPerson3);
            Persons.Add(myPerson4);
            Persons.Add(myPerson5);
            Persons.Add(myPerson6);

            foreach (Person pers in Persons)
            {
                pers.Input();
            }

            foreach (Person pers in Persons)
            {
                int age = pers.Age();
                Console.WriteLine("\nPerson Name: \"{0}\", \nAge: {1}", pers.Name, age);
                if (age < 16)
                {
                    pers.ChangeName("Very Young");
                }
            }

            Console.WriteLine("");

            foreach (Person pers in Persons)
            {
                pers.Output();
            }

            Console.WriteLine("");

            for (int i = 0; i < Persons.Count; i++)
            {
                for (int j = i + 1; j < Persons.Count; j++)
                {
                    if (Persons[i] == Persons[j])
                    {
                        Console.Write($"\n{i+1}  {Persons[i]}        {j+1} {Persons[j]}");
                    }
                }
            }

            Console.WriteLine("\npress any key..");
            Console.ReadKey();
        }
    }

    class Person
    {
        private string name;
        private DateTime birthYear;

        public string Name { get { return name; } }
        public DateTime BirthYear { get { return birthYear; } }

        public Person()
        {
        }

        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        public int Age()
        {
            return (DateTime.Now).Year - this.birthYear.Year;
        }

        public void Input()
        {
            Console.Write("Enter Person name: ");
            this.name = Console.ReadLine();
            Console.Write("Enter Person birthYear: ");
            this.birthYear = DateTime.ParseExact(Console.ReadLine(),
                                "yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        public void ChangeName(string newName)
        {
            this.name = newName;
        }

        public void Output()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return string.Format("Person name: {0}, birthYear {1}", name, birthYear.Year);
        }

        public static bool operator ==(Person first, Person second)
        {
            return first.Name == second.Name;
        }

        public static bool operator !=(Person first, Person second)
        {
            return !(first.Name == second.Name);
        }
    }
}
