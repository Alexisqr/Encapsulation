using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Box
    {
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get => length;
            set
            {
                if (value > 0)
                {
                    length = value;
                }
            }
        }
        public double Widch
        {
            get => width;
            set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }
        public double Height
        {
            get => height;
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }

        public double Area()
        {
            return (2 * (length*width+width*height+length*height));

        }
        public double Area_b()
        {
            return (2*(length+width))*height;

        }
        public double Volume()
        {
            return (length*width*height);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Box box = new Box();
            box.Length = Convert.ToDouble(Console.ReadLine());
            box.Widch = Convert.ToDouble(Console.ReadLine());
            box.Height = Convert.ToDouble(Console.ReadLine());
           if (Convert.ToBoolean(box.Length)&& Convert.ToBoolean(box.Widch)&& Convert.ToBoolean(box.Height))
            {
                double S = box.Area();
                Console.WriteLine("Surface Area – " + S);
                double S2 = box.Area_b();
                Console.WriteLine("Lateral Surface Area – " + S2);
                double V = box.Volume();
                Console.WriteLine("Surface Area – " + V);
            }
            else
            {
                if (!(Convert.ToBoolean(box.Length)))
                {
                    Console.WriteLine(" Length cannot be zero or negative.");
                }
                 if (!(Convert.ToBoolean(box.Widch)))
                {
                    Console.WriteLine(" Width cannot be zero or negative.");
                }
                 if (!(Convert.ToBoolean(box.Height)))
                {
                    Console.WriteLine(" Height cannot be zero or negative.");
                }


            }
            

        }
    }
}
