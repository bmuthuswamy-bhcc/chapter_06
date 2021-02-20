/*
 * Bunker Hill Coommunity College Spring 2021
 * Chapter 6 - Generics
 */

using System;

namespace chapter_06 {
    public class GenericDemo<T> { // T will hold the type
        public T value { get; private set; }

        public GenericDemo(T value) {
            this.value = value;
        }

        public override string ToString() => $"{typeof(T)} : {this.value}";
    }

    // Now illustrate inheritance
    public abstract class Shape<T> {
        public abstract T Area { get;  }
    }

    public class Square : Shape<int> { // need to explicitly define type here
        public int length { get; set; }

       public Square (int length) {
            this.length = length;
        }

        public override int Area => this.length * this.length;
    }

    public class Circle : Shape<double> {
        public double radius { get; set; }

        public Circle(double radius) {
            this.radius = radius;
        }

        public override double Area => Math.PI * this.radius * this.radius;
    }

    class Program {
        static void Main(string[] args) {
            var obj1 = new GenericDemo<int>(33);
            var obj2 = new GenericDemo<string>("Hello, world!");
            Console.WriteLine(obj1);
            Console.WriteLine(obj2);

            Square objSquare = new Square(10);
            Circle objCircle = new Circle(1);

            Console.WriteLine($"The area of the square is {objSquare.Area} unit^2");
            Console.WriteLine($"The area of circle is {objCircle.Area} unit^2");

        }
    }
}
