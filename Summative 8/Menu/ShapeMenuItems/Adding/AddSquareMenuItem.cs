using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddSquareMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddSquareMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add square menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int width = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "What is the size");
            Square square = new Square(width, colour);
            _manager.AddShape(square);

        }
    }
}
