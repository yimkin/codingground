using System.IO;
using System;

class Program
{
   static void Main()
    {
        Console.WriteLine(fact(9));
    }
    private static int fact(int n)
    {
        if ( n < 0 ) {throw new System.ArgumentException("Parameter cannot be less than zero", "n");}
        if ( n == 0 ) {return 1;}
        return n * fact(n - 1);
    } 
}