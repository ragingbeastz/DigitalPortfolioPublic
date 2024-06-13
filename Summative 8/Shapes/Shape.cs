using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    internal abstract class Shape
    {
        public enum Colour { Red, Green, Blue }
        public Colour ShapeColour { set; get; }
        public abstract float Area();
        public abstract float Perimeter();


    }

}
