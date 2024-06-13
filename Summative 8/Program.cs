using ShapesApp.Menu.ShapeItems;
using ShapesApp.Shapes;

Console.WriteLine("Hello, OO Console Menu!");


ShapeManager shapeManager = new ShapeManager();

ShapeManagerMenu menu = new ShapeManagerMenu(shapeManager);

menu.Select();
