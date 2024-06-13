using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing.ShapeEditing
{
    internal class EditSquareMenu : EditShapeMenu
    {
        private Square _square;

        public EditSquareMenu(Square square) : base(square)
        {
            _square = square;
        }

        public override void CreateMenu()
        {
            base.CreateMenu();
            _menuItems.Add(new EditSquareWidthMenuItem(_square));
            _menuItems.Add(new ExitMenuItem(this));
        }
    }

}
