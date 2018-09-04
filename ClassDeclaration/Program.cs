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
            #region PersonM
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
            #endregion

            #region CarM
            string newColor;
            Car[] cars = new Car[3];

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car();
                cars[i].Input();
            }

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].ChangePrice(10);
                cars[i].Print();
            }

            Console.WriteLine("\nEnter color: ");
            newColor = Console.ReadLine();
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].Color == "white")
                    cars[i].Color = newColor;
            }

            Console.WriteLine("\npress any key..");
            Console.ReadKey();
            #endregion

        }
    }

    #region Car
    class Car
    {
        const string CompanyName = "New auto-mark";

        string name;
        string color;
        double price;

        public string Color { get; set; }

        public Car()
        {

        }

        public Car(string name, string color, double price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }

        public void Input()
        {
            Console.Write("Enter car mark: ");
            this.name = Console.ReadLine();

            Console.Write("Enter car color: ");
            this.color = Console.ReadLine();

            Console.Write("Enter car price: ");
            this.price = double.Parse(Console.ReadLine());  
        }

        public void Print()
        {
            Console.WriteLine($"\nCar mark: {this.name} \nEnter car color: {this.color} \nEnter car price: {this.price}");
        }

        public override string ToString()
        {
            return $"\nCar mark: {this.name} \nEnter car color: {this.color} \nEnter car price: {this.price}";
        }

        public void ChangePrice(double percent)
        {
            this.price = this.price - (percent / 100 * this.price);
        }

        public static bool operator ==(Car first, Car second)
        {
            return first.name == second.name && first.price == second.price;
        }

        public static bool operator !=(Car first, Car second)
        {
            return !(first.name == second.name && first.price == second.price);
        }
    }
    #endregion

    #region Person
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
    #endregion
}
