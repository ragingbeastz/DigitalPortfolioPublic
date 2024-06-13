using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditRectangleHeightMenuItem : MenuItem
    {
        private Rectangle _rectangle;

        public EditRectangleHeightMenuItem(Rectangle rectangle)
        { 
            _rectangle = rectangle;
        }

        public override string MenuText()
        {
            return "Edit height";
        }

        public override void Select()
        {
            _rectangle.Height = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "Enter new width");
        }
    }
}
