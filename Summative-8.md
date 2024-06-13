# Summative 8

## Challenge Description

Using Encapsulation and Inheritance to make a Shape editing Console Application
## Code Listing

.\Menu\ShapeMenuItems\Adding\AddCircleMenuItem.cs
```csharp
﻿using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddCircleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddCircleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add circle menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "What is the radius");
            Circle circle = new Circle(radius, colour);
            _manager.AddShape(circle);
        }
    }

}

```

.\Menu\ShapeMenuItems\Adding\AddRectangleMenuItem.cs
```csharp
﻿using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddRectangleMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddRectangleMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add rectangle menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int width = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "What is the width");
            int height = ConsoleHelpers.GetIntegerInRange(Rectangle.MIN_SIDE, Rectangle.MAX_SIDE, "What is the height");
            Rectangle rectangle = new Rectangle(width, height, colour);
            _manager.AddShape(rectangle);

        }
    }
}

```

.\Menu\ShapeMenuItems\Adding\AddSquareMenuItem.cs
```csharp
﻿using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeItems.Adding
{
    internal class AddSquareMenuItem : MenuItem
    {
        private ShapeManager _manager;

        public AddSquareMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Add square menu";
        }

        public override void Select()
        {
            ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
            selectColourMenu.Select();
            Colour colour = selectColourMenu.Colour;
            int width = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "What is the size");
            Square square = new Square(width, colour);
            _manager.AddShape(square);

        }
    }
}

```

.\Menu\ShapeMenuItems\Calculating\Calculations.cs
```csharp
﻿using ShapesApp.Menu.ShapeItems;
using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShapesApp.Shapes.Shape;

namespace ShapesApp.Menu.ShapeMenuItems.Calculating.CalculatingMenuItems
{
    internal class TotalShapeAreaMenuItem
    {
        private ShapeManager _manager;

        public TotalShapeAreaMenuItem(ShapeManager manager)
        {
            _manager = manager;
        }

        public string Text()
        {
            float total = 0;
            foreach(Shape shape in _manager.Shapes)
            {
                total = total + shape.Area();
            }
            return "The total area of all shapes is " + total;
        }
    }
}


```

.\Menu\ShapeMenuItems\Calculating\CalculationsMenu.cs
```csharp
﻿using ShapesApp.Menu.ShapeMenuItems.Calculating;
using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Calculating
{
    internal class CalculationsMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public CalculationsMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Perform Calculations on all Shapes (Bonus)";
        }

        public void TotalArea()
        {
            float total = 0;
            foreach (Shape shape in _manager.Shapes)
            {
                total = total + shape.Area();
            }
            Console.WriteLine("The total area of all shapes is " + total);
        }
        public void TotalAreaByColour()
        {
            int input = ConsoleHelpers.GetIntegerInRange(1, 3, "Select 1 for Red, 2 for Green, 3 for Blue");

            float total = 0;

            foreach (Shape shape in _manager.Shapes)
            {
                if (shape.ShapeColour == Shape.Colour.Red && input == 1)
                {
                    total = total + shape.Area();
                }

                else if (shape.ShapeColour == Shape.Colour.Green && input == 2)
                {
                    total = total + shape.Area();
                }

                else if (shape.ShapeColour == Shape.Colour.Blue && input == 3)
                {
                    total = total + shape.Area();
                }
            }
            
            if (input == 1)
            {
                Console.WriteLine("The total area of all Red shapes is " + total);
            }

            else if (input == 2)
            {
                Console.WriteLine("The total area of all Green shapes is " + total);
            }

            else if (input == 3)
            {
                Console.WriteLine("The total area of all Blue shapes is " + total);
            }

        }



        public void TotalPerimeter()
        {
            float total = 0;
            foreach (Shape shape in _manager.Shapes)
            {
                total = total + shape.Perimeter();
            }
            Console.WriteLine("The total perimeter of all shapes is " + total);
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            TotalArea();
            TotalPerimeter();
            TotalAreaByColour();
            Console.WriteLine();
            _menuItems.Add(new ExitMenuItem(this));
        }


    }
}

```

.\Menu\ShapeMenuItems\Editing\EditExistingShapeMenu.cs
```csharp
﻿using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems.Editing
{
    internal class EditExistingShapeMenu : ConsoleMenu
    {
        private ShapeManager _manager;

        public EditExistingShapeMenu(ShapeManager manager)
        {
            _manager = manager;
        }

        public override string MenuText()
        {
            return "Edit an existing shape menu";
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            foreach (Shape shape in _manager.Shapes)
            {
                switch (shape)
                {
                    case Circle:
                         _menuItems.Add(new ShapeEditing.EditCircleMenu(shape as Circle));
                        break;

                    case Square:
                        _menuItems.Add(new ShapeEditing.EditSquareMenu(shape as Square));
                        break;

                    case Rectangle:
                        _menuItems.Add(new ShapeEditing.EditRectangleMenu(shape as Rectangle));
                        break;
                }
            }
            _menuItems.Add(new ExitMenuItem(this));
        }


    }
}

```

.\Menu\ShapeMenuItems\Editing\EditShapeMenu.cs
```csharp
﻿using ShapesApp.Shapes;
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

```

.\Menu\ShapeMenuItems\Removing\RemoveShape.cs
```csharp
﻿using ShapesApp.Shapes;
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

```

.\Menu\ShapeMenuItems\Removing\RemoveShapeMenu.cs
```csharp
﻿using ShapesApp.Shapes;
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

```

.\Menu\ShapeMenuItems\ColourShapeMenuItem.cs
```csharp
﻿using ShapesApp.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu.ShapeItems
{
    class ColourShapeMenuItem : MenuItem
    {
        public Shape.Colour Colour { get; private set; }

        private Shape _shape;

        public ColourShapeMenuItem(Shape shape)
        {
            _shape = shape;
        }

        public ColourShapeMenuItem() : this(null)
        {
        }

        public override void Select()
        {
            int selectedIndex = ConsoleHelpers.GetIntegerInRange(1, Enum.GetValues(typeof(Shape.Colour)).Length, ToString()) - 1;
            Colour = (Shape.Colour)selectedIndex;
            if (_shape != null)
            {
                _shape.ShapeColour = Colour;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
            int i = 1;
            foreach (Shape.Colour colour in Enum.GetValues(typeof(Shape.Colour)))
            {
                sb.AppendLine($"{i}. {colour}");
                i++;
            }
            return sb.ToString();
        }

        public override string MenuText()
        {
            return "Select colour";
        }
    }

}

```

.\Menu\ShapeMenuItems\ShapeManagerMenu.cs
```csharp
﻿using ShapesApp.Shapes;
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

```

.\Menu\ConsoleHelpers.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu
{
    internal class ConsoleHelpers
    {
        public static int GetIntegerInRange(int pMin, int pMax, string pMessage)
        {
            if (pMin > pMax)
            {
                throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");
            }

            int result;

            do
            {
                Console.WriteLine(pMessage);
                Console.WriteLine($"Please enter a number between {pMin} and {pMax} inclusive.");

                string userInput = Console.ReadLine();

                try
                {
                    result = int.Parse(userInput);
                }
                catch
                {
                    Console.WriteLine($"{userInput} is not a number");
                    continue;
                }

                if (result >= pMin && result <= pMax)
                {
                    return result;
                }
                Console.WriteLine($"{result} is not between {pMin} and {pMax} inclusive.");
            } while (true);
        }
    }

}


```

.\Menu\ConsoleMenu.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu
{
    internal abstract class ConsoleMenu : MenuItem
    {
        protected List<MenuItem> _menuItems = new List<MenuItem>();

        public bool IsActive { get; set; }

        public abstract void CreateMenu();

        public override void Select()
        {
            IsActive = true;
            do
            {
                Console.Clear();
                CreateMenu();
                string output = $"{MenuText()}{Environment.NewLine}";
                int selection = ConsoleHelpers.GetIntegerInRange(1, _menuItems.Count, this.ToString()) - 1;
                _menuItems[selection].Select();
                
            } while (IsActive);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MenuText());
            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {_menuItems[i].MenuText()}");
            }
            return sb.ToString();
        }
    }

}



```

.\Menu\ExitMenuItem.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu
{
    class ExitMenuItem : MenuItem
    {
        private ConsoleMenu _menu;

        public ExitMenuItem(ConsoleMenu parentItem)
        {
            _menu = parentItem;
        }

        public override string MenuText()
        {
            return "Exit";
        }

        public override void Select()
        {
            _menu.IsActive = false;
        }
    }

}

```

.\Menu\MenuItem.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Menu
{
    internal abstract class MenuItem
    {
        public abstract void Select();
        public abstract string MenuText();
    }
}

```

.\Shapes\Circle.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    internal class Circle : Shape
    {
        public const int MIN_RADIUS = 0;
        public const int MAX_RADIUS = 50;

        private float _Radius;

        public float Radius
        {
            get { return _Radius; }
            set { if (value >= MIN_RADIUS && value <= MAX_RADIUS) { _Radius = value; } }
        }

        public Circle(float radius, Colour colour)
        {
            Radius = radius;
            ShapeColour = colour;
        }

        public override float Area()
        {
            return MathF.PI * _Radius * _Radius;

        }

        public override float Perimeter()
        {
            return 2 * MathF.PI * _Radius;

        }
        public override string ToString()
        {
            return $"{ShapeColour} circle with radius {Radius}.";
        }



    }
}

```

.\Shapes\Rectangle.cs
```csharp
﻿using System;
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

```

.\Shapes\Shape.cs
```csharp
﻿using System;
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

```

.\Shapes\Square.cs
```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp.Shapes
{
    internal class Square : Shape
    {
        public const int MIN_SIDE = 0;
        public const int MAX_SIDE = 50;

        private float _Width;

        public float Height { get { return _Width; } }

        public Square(float width, Colour colour)
        {
            Width = width;
            ShapeColour = colour;
        }

        public float Width
        {
            get { return _Width; }
            set { if (value >= MIN_SIDE && value <= MAX_SIDE) { _Width = value; } }
        }
        public override float Area()
        {
            return _Width * _Width;
        }

        public override float Perimeter()
        {
            return 4 * _Width;
        }

        public override string ToString()
        {
            return $"{ShapeColour} Square with width {Width}.";
        }
    }

}

```

.\Shapes\ShapeManager.cs
```csharp
﻿using System;
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

```

.\Program.cs
```csharp
﻿using ShapesApp.Menu.ShapeItems;
using ShapesApp.Shapes;

Console.WriteLine("Hello, OO Console Menu!");


ShapeManager shapeManager = new ShapeManager();

ShapeManagerMenu menu = new ShapeManagerMenu(shapeManager);

menu.Select();

```

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
