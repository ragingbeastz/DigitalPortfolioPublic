using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    internal class Rectangle : Shape
    {
        public const int MIN_SIDE = 0;
        public const int MAX_SIDE = 50;
        private float _Width;
        private float _Height;

        public Rectangle(float width, float height, Colour colour)
        {
            _Width = width;
            _Height = height;
            ShapeColour = colour;
        }

        public float Width
        {
            get { return _Width; }
            set { if (value >= MIN_SIDE && value <= MAX_SIDE) { _Width = value; } }
        }

        public float Height
        {
            get { return _Height; }
            set { if (value >= MIN_SIDE && value <= MAX_SIDE) { _Height = value; } }
        }

        public override float Area()
        {
            return _Width * _Height;
        }

        public override float Perimeter()
        {
            return 2 * (_Width + _Height);
        }

        public override string ToString()
        {
            return $"{ShapeColour} Rectangle with width {Width} and height {Height}.";
        }
    }

}
