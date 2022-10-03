using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    class Pizza
    {
        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;

        private const int MaxRangeToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length >= NameMinLength && value.Length <= NameMaxLength && value != " " && value != null && value != "")
                  
                {

                    this.name = value;
                }else if(value.Length < NameMinLength|| value.Length > NameMaxLength)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);

                }

            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count < MaxRangeToppings)
            {
                this.toppings.Add(topping);
            }
            else
            {
                Console.WriteLine("Number of toppings should be in range[0..10].");
                Environment.Exit(0);

            }

        }
        public int ToppingCon()
        {

            return toppings.Count;
        }
        public string ToppingCon(int y)
        {

            return toppings[y].Name;
        }
        public int ToppingCon2(int y)
        {

            return toppings[y].Weight;
        }
        public double ToppingCon3(int y)
        {

            return toppings[y].GetCalories();
        }
        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }

    }

class Topping
    {
        private const int min_gr = 1;
        private const int max_gr = 50;
        private string name;
        private int weight;

        public Topping(string name,  int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get => this.name;
            set
            {
             
                if (value == "meat" || value == "veggies"|| value == "cheese" || value == "sauce")
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Cannot place " + value + " on top of your pizza");
                    Environment.Exit(0);

                }

            }
        }
        
        public int Weight
        {
            get => this.weight;
            set
            {
                if (value >= min_gr && value <= max_gr)
                {
                    this.weight = value;
                }

            }
        }

        public double GetCalories()
        {
            var f = NModifier();
          
            return (this.Weight * 2 * f );
        }

        
        private double NModifier()
        {

            if (name == "meat")
            {
                return 1.2;
            }
            else if (name == "veggies")
            {
                return 0.8;
            }
            else if(name == "cheese")
            {
                return 1.1;
            }
            else
            {
                return 0.9;
            }


        }
    }
    class Dough
    {
        private const int min_gr = 1;
        private const int max_gr = 200;
        private string flour_t;
        private int weight;
        private string baking_t;
        public Dough(string flour_t, string baking_t, int weight)
        {
            this.Flour_t = flour_t;
            this.Baking_t = baking_t;
            this.Weight = weight;
        }
        public string Flour_t
        {
            get => this.flour_t;
            set
            {
                
                if (value == "White" || value == "Wholegrain")
                {
                    this.flour_t = value;
                }
     
            }
        }
        public string Baking_t
        {
            get => this.baking_t;
            set
            {
             
                if (value == "Crispy" || value == "Chewy" || value == "Homemade")
                {
                    this.baking_t = value;
                }
                
            }
        }
        public int Weight
        {
            get => this.weight;
            set
            {
                if (value >=min_gr && value <=max_gr )
                {
                    this.weight = value;
                }
              
            }
        }

        public double GetCalories()
        {
            var f = FlourModifier();
            var b = BakingModifier();
            return (this.Weight * 2 * f * b);
        }

        private double BakingModifier()
        {
            if (Baking_t == "Crispy")
            {
                return 0.9;
            }else if(Baking_t == "Chewy")
            {
                return 1.1;
            }
            else 
            {
                return 1.0;
            }
        }
        private double FlourModifier()
        {
        
            if (Flour_t == "White")
            {
                return 1.5;
            }
            else
            {
                return 1;
            }

           
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var per = new List<Dough>();
            var per2 = new List<Topping>();
            string Str0 = Console.ReadLine();
            var Spus0 = Str0.Split(' ');
            string Str;
            Str = Console.ReadLine();
            var Spus = Str.Split(' ');
           
            Dough dough = new Dough(Spus[1], Spus[2], int.Parse(Spus[3]));
            Pizza pizza = new Pizza(Spus0[1], dough);
            string Str2;
            int i=0;
            while ((Str2 = Console.ReadLine()) != "END")
            {
               
               
                var Spus2 = Str2.Split(' ');
                Topping topping = new Topping(Spus2[1], int.Parse(Spus2[2]));

                pizza.AddTopping(topping);
                i++;
            }
         
                if (dough.Flour_t != null && dough.Baking_t != null && Convert.ToBoolean(dough.Weight))
                {
                    
                    
                }
                else
                {
                    if (dough.Flour_t == null || dough.Baking_t == null)
                    {
                        Console.WriteLine("Invalid type of dough.");
                    
                        Environment.Exit(0);

                }
                if (!Convert.ToBoolean(dough.Weight))
                    {
                        Console.WriteLine("Dough weight should be in the range [1..200]");
                    Environment.Exit(0);

                }
            }
            
            for (i = 0; i < pizza.ToppingCon(); i++)
            {
                if (pizza.ToppingCon(i) != null  && Convert.ToBoolean(pizza.ToppingCon2(i)))
                {
                    
                        
                    
                }
                else
                {

                    if (!Convert.ToBoolean(pizza.ToppingCon2(i)))
                    {
                        Console.WriteLine(pizza.ToppingCon(i) + " weight should be in the range [1..50].");
                        Environment.Exit(0);

                    }
                }
            }
            
            Console.WriteLine(pizza.GetCalories());
        }
    }
}
