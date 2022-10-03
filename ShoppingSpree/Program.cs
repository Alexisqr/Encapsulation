using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AnimalFarm
{
    class Person
    {

        private string name;
        private int money;
        public List<string[]> bag = new List<string[]>();
        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
           

        }
        public void AddMember(string[] members)
        {
            this.bag.Add(members);
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (!(value == " " || value == null || value == ""))
                {
                    this.name = value;
                }

            }
        }
        public int Money
        {
            get => this.money;
            set
            {
                if (!(value < 0 ))
                {
                    this.money = value;
                }
            }
        }

        public bool BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return false;
            }
            else
            {
                this.money -= product.Cost;
            }
            return true;
            
        }

    }
    class Product
    {

        private string name;
        private int cost;

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;

        }

        public string Name
        {
            get => this.name;
            set
            {
                if (!(value == " " || value == null || value == ""))
                {
                    this.name = value;
                }

            }
        }
        public int Cost
        {
            get => this.cost;
            set
            {
                if (!(value < 0))
                {
                    this.cost = value;
                }
            }
        }




    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var per = new List<Person>();
            string[] R1 = Console.ReadLine().Split(';').ToArray();
            int y =0;
            for (int i = 0; i < R1.Length; i++)
            {
                string[] R2 = R1[i].Split('=').ToArray();
                per.Add(new Person(R2[0], int.Parse(R2[1])));
          
                if (per[i].Name == null || !Convert.ToBoolean(per[i].Money)) {
                    
                    if (per[i].Name == null)
                    {
                        Console.WriteLine("Name cannot be empty");
                    }
                    if (!Convert.ToBoolean(per[i].Money))
                    {
                        Console.WriteLine("Money cannot be negative");
                    }
                    y = 1;
                    break;
                    
                }
            }
            var pod = new List<Product>();
            if (y != 1)
            {
                
                string[] R1_1 = Console.ReadLine().Split(';').ToArray();

                for (int i = 0; i < R1.Length; i++)
                {
                    string[] R2_1 = R1_1[i].Split('=').ToArray();
                    pod.Add(new Product(R2_1[0], int.Parse(R2_1[1])));
                    if (pod[i].Name == null && !Convert.ToBoolean(pod[i].Cost))
                    {
                        if (pod[i].Name == null)
                        {
                            Console.WriteLine("Name cannot be empty");
                        }
                        if (!Convert.ToBoolean(pod[i].Cost))
                        {
                            Console.WriteLine("Money cannot be negative");
                        }
                        y = 1;
                        break;

                    }
                }
            }
            
            if (y != 1)
            {
                List<string[]> cp = new List<string[]>();
                string Str;
                while ((Str = Console.ReadLine()) != "END")
                {
                    var Spus = Str.Split(' ');
                   
                    cp.Add(Spus);


                }
                int l = 0;

                for (int i = 0; i < per.Count; i++)
                {
                    string[] s = new string[cp.Count];
                    for (int j = 0; j < cp.Count; j++)
                    {
                        if (cp[j][0] == per[i].Name)
                        {
                            if (l == 0)
                            {
                                s[l] = per[i].Name;
                            }

                            l++;
                            for (int k = 0; k < pod.Count; k++)
                            {
                                if (pod[k].Name == cp[j][1])
                                {
                                    if (per[i].BuyProduct(pod[k]))
                                    {
                                        s[l] = cp[j][1];
                                        Console.WriteLine(s[0] + " bought " + s[l]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(s[0] + " can't afford " + cp[j][1]);
                                        l--;
                                       
                                    }
                                }



                            }
                          
                            
                            
                        }
                    }
                   
                    if (l == 0)
                    {
                        per[i].AddMember(null);
                    }
                    else
                    {
                        per[i].AddMember(s);
                        l = 0;
                    }

                }

                for (int i = 0; i < per.Count; i++)
                {
                    if (per[i].bag == null)
                    {
                        Console.WriteLine(per[i].Name + " Nothing bought");


                    }
                    for (int j = 0; j < per[i].bag.Count; j++)
                    {

                        for (int k = 0; k < per[i].bag[j].Length; k++)
                        {
                            if (k == 0)
                            {
                                Console.Write(per[i].bag[j][k]);
                                Console.Write(" - ");
                            }
                            else if (k < (per[i].bag[j].Length) - 2)
                            {
                                Console.Write(per[i].bag[j][k]);
                                Console.Write(",");
                            }
                            else
                            {
                                Console.Write(per[i].bag[j][k]);

                            }


                        }
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}

