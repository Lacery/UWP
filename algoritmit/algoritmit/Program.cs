
/*
Fibonacci sequence

First two numbers of a list of numbers are [0,1]
Make a function that defines any number k in the sequence.
*/


using System;

namespace algoritmit
{
    class Program
    {
        public static int Fibonacci(int n)
        {
            int a = 0; //Listan ekat numerot [0,1]
            int b = 1;
            for (int i = 0; i < n; i++) //Loopataan kunnes päästään haluttuun numeroon
            {
                int temp = a;  //Vaihdetaan a=b, ja b=b+a
                a = b;
                b = temp + b;
            }
            return a; //Palauttaa a:n kun on päästy n:nteen numeroon listalla
        }

        static void Main()
        {
            Console.WriteLine("Monesko luku? ");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Fibonacci(number-1)); //number-1 cause the values start from 0
            
        }
    }
}
