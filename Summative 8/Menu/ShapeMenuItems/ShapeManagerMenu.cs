using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems
{
    class ShapeManagerMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public ShapeManagerMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new Adding.AddCircleMenuItem(_manager));
            _menuItems.Add(new Adding.AddSquareMenuItem(_manager));
            _menuItems.Add(new Adding.AddRectangleMenuItem(_manager));
            if (_manager.Shapes.Count > 0)
            {
                _menuItems.Add(new Editing.EditExistingShapeMenu(_manager));
                _menuItems.Add(new Removing.RemoveShapeMenu(_manager));
                _menuItems.Add(new Calculating.CalculationsMenu(_manager));
            }
            _menuItems.Add(new ExitMenuItem(this));
        }

        public override string MenuText()
        {
            return "Shape Manager Menu" + Environment.NewLine + _manager.ToString();
        }

    }

}
