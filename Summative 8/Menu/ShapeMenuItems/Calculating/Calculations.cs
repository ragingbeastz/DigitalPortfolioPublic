using ShapesApp.Menu.ShapeItems;
using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeMenuItems.Calculating.CalculatingMenuItems
{
    internal class TotalShapeAreaMenuItem
    {
        private ShapeManager _manager;

        public TotalShapeAreaMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public string Text()
        {
            float total = 0;
            foreach(Shape shape in _manager.Shapes)
            {
                total = total + shape.Area();
            }
            return "The total area of all shapes is " + total;
        }
    }
}

