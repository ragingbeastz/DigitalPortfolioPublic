using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Summative_6
{
    internal class Circle
    {
        //Variables
        private int radius;
        private static int IDCount = 1;        //Keeps track of last ID
        public static List<Circle> circles = new List<Circle>();
        private string ID;

        //Constructors

        public Circle()
        {
            this.radius = 1;
            this.ID  = "C" + IDCount++;        //Assign Unique ID and increment last ID
        }

        public Circle(int radius)
        {
            if (radius < 0)
            {
                throw new Exception("Radius cannot be below zero");
            }

            else
            {
                this.radius = radius;
            }

            this.ID = "C" + IDCount++;

            circles.Add(this);

        }


        //Getters
        public int GetRadius()
        {
            return this.radius;
        }

        public string GetID()
        {
            return this.ID;
        }

        //Setter
        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        //Calculations
        public decimal CalculateArea()
        {
            decimal Area = ((decimal)Math.PI * (this.radius*this.radius));
            Area = Math.Round(Area,5);
            return Area;
        }

        public decimal CalculateCircumference()
        {
            decimal Circumference = 2 * (decimal)Math.PI * this.radius;
            Circumference = Math.Round(Circumference, 5);
            return Circumference;
        }


        

    }
}
