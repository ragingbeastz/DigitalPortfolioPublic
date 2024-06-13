using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditCircleRadiusMenuItem : MenuItem
    {
        private Circle _circle;

        public EditCircleRadiusMenuItem(Circle circle)
        {
            _circle = circle;
        }

        public override string MenuText()
        {
            return "Edit radius";
        }

        public override void Select()
        {
            _circle.Radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "Enter new radius");
        }
    }
}
