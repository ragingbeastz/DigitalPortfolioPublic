using ShapesApp.Menu.ShapeMenuItems.Calculating;
using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Calculating
{
    internal class CalculationsMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public CalculationsMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Perform Calculations on all Shapes (Bonus)";
        }

        public void TotalArea()
        {
            float total = 0;
            foreach (Shape shape in _manager.Shapes)
            {
                total = total + shape.Area();
            }
            Console.WriteLine("The total area of all shapes is " + total);
        }
        public void TotalAreaByColour()
        {
            int input = ConsoleHelpers.GetIntegerInRange(1, 3, "Select 1 for Red, 2 for Green, 3 for Blue");

            float total = 0;

            foreach (Shape shape in _manager.Shapes)
            {
                if (shape.ShapeColour == Shape.Colour.Red && input == 1)
                {
                    total = total + shape.Area();
                }

                else if (shape.ShapeColour == Shape.Colour.Green && input == 2)
                {
                    total = total + shape.Area();
                }

                else if (shape.ShapeColour == Shape.Colour.Blue && input == 3)
                {
                    total = total + shape.Area();
                }
            }
            
            if (input == 1)
            {
                Console.WriteLine("The total area of all Red shapes is " + total);
            }

            else if (input == 2)
            {
                Console.WriteLine("The total area of all Green shapes is " + total);
            }

            else if (input == 3)
            {
                Console.WriteLine("The total area of all Blue shapes is " + total);
            }

        }



        public void TotalPerimeter()
        {
            float total = 0;
            foreach (Shape shape in _manager.Shapes)
            {
                total = total + shape.Perimeter();
            }
            Console.WriteLine("The total perimeter of all shapes is " + total);
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            TotalArea();
            TotalPerimeter();
            TotalAreaByColour();
            Console.WriteLine();
            _menuItems.Add(new ExitMenuItem(this));
        }


    }
}
