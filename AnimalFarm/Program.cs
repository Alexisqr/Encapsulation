using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm
{
    class Chicken
    {
        private const int min_age = 0;
        private const int max_age = 15;
        private string name ;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }
     
        public string Name
        {
            get => this.name;
            set
            {
                if (!(value == " "|| value == null|| value == ""))
                {
                    this.name = value;
                }

            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (!(value <min_age  || value >max_age))
                {
                    this.age = value;
                }
            }
        }
        public double ProductPerDay()
        {
            return CalculateProductPerDay();
        }
        private double CalculateProductPerDay()
        {
            if (Age <= 5)
            {
                return 1.50;
            }
            else if (Age <= 10)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }
        }



        }

        internal class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int Age = Convert.ToInt32(Console.ReadLine());
            Chicken chick = new Chicken(Name,Age);

            if (chick.Name!=null && Convert.ToBoolean(chick.Age) )
            {
                Console.Write("Chicken " + chick.Name + " ( " + chick.Age + " ) " + "can produce " + chick.ProductPerDay() + " eggs per day.");
                
            }
            else
            {
                if (chick.Name == null)
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                 if (!(Convert.ToBoolean(chick.Age)))
                {
                    Console.WriteLine("Age should be between 0 and 15.");
                }
                


            }
        }
    }
}
