using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditRectangleMenu : EditShapeMenu
    {
        private Rectangle _rectangle;

        public EditRectangleMenu(Rectangle rectangle) : base(rectangle)
        {
            _rectangle = rectangle;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditRectangleHeightMenuItem(_rectangle));
            _menuItems.Add(new EditRectangleWidthMenuItem(_rectangle));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }

}
