using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Removing
{
    internal class RemoveShapeMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public RemoveShapeMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Remove Shape";
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();

            foreach (Shape shape in _manager.Shapes)
            {
                _menuItems.Add(new Removing.RemoveShape(shape, _manager));

            }
            _menuItems.Add(new ExitMenuItem(this));
        }

    }
}
