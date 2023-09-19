// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

for (int i = 1; i < 101; i++)
{
    bool isFizz = i % 3 == 0;
    bool isBuzz = i % 5 == 0;
    
    int result = Convert.ToInt32(isFizz) + Convert.ToInt32(isBuzz);
    
    if (result == 2) Console.WriteLine("FizzBuzz");
    else if (isFizz) Console.WriteLine("Fizz");
    else if (isBuzz) Console.WriteLine("Buzz");
    else Console.WriteLine(i);
}