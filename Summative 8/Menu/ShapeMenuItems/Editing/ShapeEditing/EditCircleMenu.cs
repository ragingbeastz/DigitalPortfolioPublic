using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditCircleMenu : EditShapeMenu
    {
        private Circle _circle;

        public EditCircleMenu(Circle circle) : base(circle)
        {
            _circle = circle;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditCircleRadiusMenuItem(_circle));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }

}
