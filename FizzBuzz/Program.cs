// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

Dictionary<int, string> rules = new Dictionary<int, string>();

rules.Add(3, "Fizz");
rules.Add(5, "Buzz");

for (int i = 1; i < 101; i++)
{
    bool emptyOutput = true;

    foreach (KeyValuePair<int, string> rule in rules)
    {
        if (i % rule.Key == 0)
        {
            Console.Write(rule.Value);
            emptyOutput = false;
        }
    }
    
    if (emptyOutput) Console.Write(i);
    
    Console.WriteLine();
}

