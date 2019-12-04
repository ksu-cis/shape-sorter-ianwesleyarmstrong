using System;
using System.Linq;
using System.Collections.Generic;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("----------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.5),
                new Square(10),
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.Area);
            }
            Console.WriteLine("----------------");


            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);

            Console.WriteLine("shapes with area > 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine(shape.Area);
            }
            Console.WriteLine("----------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();

            Console.WriteLine("shapes with circles");
            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }
            Console.WriteLine("----------------");


            Console.WriteLine("shapes with circles");
            foreach (Circle shape in circles.Where(circle => circle.Radius < 3.1))
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and area {shape.Area}");
            }
            Console.WriteLine("----------------");


            Console.WriteLine("Grouping by Area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach(var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Ods");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}"
                        );

                }
            }


            Console.WriteLine("Grouping by Type");
            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}"
                        );

                }
            }



        }
    }
}
