using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    internal class ShapeManager
    {
        public List<Shape> Shapes { get; private set; }

        public ShapeManager()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape pShape)
        {
            Shapes.Add(pShape);
        }

        public void RemoveShape(Shape pShape)
        {
            Shapes.Remove(pShape);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Shape pShape in Shapes)
            {
                sb.Append(pShape.ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }


    }
}
