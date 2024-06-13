using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddRectangleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddRectangleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add rectangle menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int width = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "What is the width");
            int height = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "What is the height");
            Rectangle rectangle = new Rectangle(width, height, colour);
            _manager.AddShape(rectangle);

        }
    }
}
