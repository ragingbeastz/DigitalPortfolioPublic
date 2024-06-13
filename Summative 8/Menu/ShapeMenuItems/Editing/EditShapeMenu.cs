using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing
{
    internal class EditShapeMenu : ConsoleMenu
    {
        protected Shape _shape;

        public EditShapeMenu(Shape shape)
        {
            _shape = shape;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new ColourShapeMenuItem(_shape));
        }

        public override string MenuText()
        {
            return _shape.ToString();
        }

        public override string ToString()
        {
            return $"Edit {base.ToString()}";
        }
    }

}
