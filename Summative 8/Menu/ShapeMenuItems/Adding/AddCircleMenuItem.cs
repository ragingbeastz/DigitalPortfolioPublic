using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddCircleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddCircleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add circle menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "What is the radius");
            Circle circle = new Circle(radius, colour);
            _manager.AddShape(circle);
        }
    }

}
