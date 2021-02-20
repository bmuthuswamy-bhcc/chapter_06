/*
 * Bunker Hill Coommunity College Spring 2021
 * Chapter 6 - Generics
 */

using System;
using System.Collections.Generic;

namespace chapter_06 {
    /* Illustration of type parameter constraints
     * We are restricting T to be either integer or double (numeric)
     * Unfortunately, there is no explicit constraint to define a numeric type
     * but the constraint below represent the best combination.
     * For details, refer to p. 194 in your textbook
     */
    public class GenericDemo<T>
            where T : struct, 
                      IComparable, IComparable<T>, 
                      IConvertible,
                      IEquatable<T>,
                      IFormattable {
        public T value { get; private set; }

        public GenericDemo(T value) {
            this.value = value;
        }

        public override string ToString() => $"{typeof(T)} : {this.value}";
    }

    // Now illustrate contravariant concept in Generics
    public interface IShape {
        public double Area { get;  }
    }

    public class Square : IShape { // need to explicitly define type here
        public double length { get; set; }

       public Square (double length) {
            this.length = length;
        }

        public double Area => this.length * this.length;
    }

    public class Circle : IShape {
        public double radius { get; set; }

        public Circle(double radius) {
            this.radius = radius;
        }

        public double Area => Math.PI * this.radius * this.radius;
    }

    /*
     * Shape comparer will compare the areas of two shapes s1 and s2, will return:
     * -1 if area(s1) < area(s2)
     * 0 if area(s1) == area(s2)
     * > 0 if area(s1) > area(s2)
     */
    public class ShapeComparer : IComparer<IShape> { 
        public int Compare(IShape s1, IShape s2) {
            if (s1 is null) {
                return s2 is null ? 0 : -1;
            }
            if (s2 is null) {
                return 1;
            }
            return s1.Area.CompareTo(s2.Area);
        }
    }

    // Square: compare the length of sides
    public class SquareComparer : IComparer<Square> {
        public int Compare(Square s1, Square s2) {
            if (s1 is null) {
                return s2 is null ? 0 : -1;
            }
            if (s2 is null) {
                return 1;
            }
            return s1.length.CompareTo(s2.length);
        }
    }

    // Circle : compare length of radii
    public class CircleComparer : IComparer<Circle> {
        public int Compare(Circle c1, Circle c2) {
            if (c1 is null) {
                return c2 is null ? 0 : -1;
            }
            if (c2 is null) {
                return 1;
            }
            return c1.radius.CompareTo(c2.radius);
        }
    }
    class Program {
        static void Main(string[] args) {
            var obj1 = new GenericDemo<int>(33);
            /* Declaration below will give a compile-time error with the type
             * parameter restriction to numerics
             */
            // var obj2 = new GenericDemo<string>("Hello, world!");
            Console.WriteLine(obj1);
            //Console.WriteLine(obj2);

            Square objSquare = new Square(10);
            Circle objCircle = new Circle(1);

            ShapeComparer objShapeComparer = new ShapeComparer();

            Console.WriteLine($"The area of the square is {objSquare.Area} unit^2");
            Console.WriteLine($"The area of circle is {objCircle.Area} unit^2");

            if (objShapeComparer.Compare(objSquare,objCircle) > 0 ) {
                Console.WriteLine($"{objSquare} has larger area than {objCircle}");
            } else if (objShapeComparer.Compare(objSquare, objCircle) == 0) {
                Console.WriteLine($"{objSquare} and {objCircle} have equal area");
            } else {
                Console.WriteLine($"{objSquare} has smaller area than {objCircle}");
            }
            
        }
    }
}
