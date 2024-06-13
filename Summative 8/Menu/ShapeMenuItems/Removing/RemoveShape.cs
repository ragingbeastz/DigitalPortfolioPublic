using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Removing
{
    internal class RemoveShape : MenuItem
    {
        private Shape _shape;
        private ShapeManager _manager;

        public RemoveShape(Shape shape, ShapeManager manager)
        {
            _shape = shape;
            _manager = manager;
        }

        public override string MenuText()
        {
            return _shape.ToString();
        }

        public override void Select()
        {
            _manager.RemoveShape(_shape);
        }
    }
}
