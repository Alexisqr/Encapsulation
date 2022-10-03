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
        public Box(double length, double width, double height)
        {

            this.length = length;
            this.width = width;
            this.height = height;



        }
        private bool TF(double n)
        {
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        public double Area()
        {
            return (2 * (length * width + width * height + length * height));

        }
        public double Area_b()
        {
            return (2 * (length + width)) * height;

        }
        public double Volume()
        {
            return (length * width * height);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var box = new List<Box>();

            double length = Convert.ToDouble(Console.ReadLine());
            double width = Convert.ToDouble(Console.ReadLine());
            double height = Convert.ToDouble(Console.ReadLine());
            box.Add(new Box(length, width, height));
            double S = box[0].Area();
            Console.WriteLine("Surface Area – " + S);
            double S2 = box[0].Area_b();
            Console.WriteLine("Lateral Surface Area – " + S2);
            double V = box[0].Volume();
            Console.WriteLine("Surface Area – " + V);

        }
    }
}
