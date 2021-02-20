/*
 * Bunker Hill Coommunity College Spring 2021
 * Chapter 6 - Generics
 */

using System;

namespace chapter_06 {
    class GenericDemo<T> { // T will hold the type
        public T value { get; private set; }

        public GenericDemo(T value) {
            this.value = value;
        }

        public override string ToString() => $"{typeof(T)} : {this.value}";
    }
    class Program {
        static void Main(string[] args) {
        var obj1 = new GenericDemo<int>(33);
        var obj2 = new GenericDemo<string>("Hello, world!");
        Console.WriteLine(obj1);
        Console.WriteLine(obj2);
        }
    }
}
