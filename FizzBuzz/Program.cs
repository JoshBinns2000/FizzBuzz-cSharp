// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Runtime.CompilerServices;

Dictionary<int, string> rules = new Dictionary<int, string>();

int[] priorityRules =
{
    11, // Bong
    3 * 5 * 7, // FizzBuzzBang
    3 * 7, // FizzBang
    5 * 7, // BuzzBang
    3 * 5, // FizzBuzz
    7, // Bang
    5, // Buzz
    3, // Fizz
};

rules.Add(3 * 5 * 7, "FizzBuzzBang");
rules.Add(3 * 7, "FizzBang");
rules.Add(5 * 7, "BuzzBang");
rules.Add(3 * 5, "FizzBuzz");
rules.Add(11, "Bong");
rules.Add(7, "Bang");
rules.Add(5, "Buzz");
rules.Add(3, "Fizz");

for (int i = 1; i < 101; i++)
{
    bool emptyOutput = true;

    foreach (int ruleValue in priorityRules)
    {
        if (i % ruleValue == 0)
        {
            string output = rules[ruleValue]; // no need to protect against bad inputs obviously
            Console.Write(output);
            emptyOutput = false;
            break;
        }
    }
    
    if (emptyOutput) Console.Write(i);
    
    Console.WriteLine();
}

