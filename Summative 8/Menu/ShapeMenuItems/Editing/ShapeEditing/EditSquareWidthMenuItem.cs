using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditSquareWidthMenuItem : MenuItem
    {
        private Square _square;

        public EditSquareWidthMenuItem(Square square)
        {
            _square = square;
        }

        public override string MenuText()
        {
            return "Edit width";
        }

        public override void Select()
        {
            _square.Width = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "Enter new width");
        }
    }
}
