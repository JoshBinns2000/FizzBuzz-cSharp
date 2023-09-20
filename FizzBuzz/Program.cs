// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Reflection.Metadata;

Rules rules = new FizzBuzzRulesBuilder()
    .AddRule(3, outputArray =>
    {
        outputArray.Add("Fizz");
        return outputArray;
    })
    .AddRule(5, outputArray =>
    {
        outputArray.Add("Buzz");
        return outputArray;
    })
    .AddRule(7, outputArray =>
    {
        outputArray.Add("Bang");
        return outputArray;
    })
    .AddRule(11, outputArray =>
    {
        outputArray.Clear();
        outputArray.Add("Bong");
        return outputArray;
    })
    .AddRule(13, outputArray =>
    {
        var newArray = new ArrayList();

        if (outputArray.Count == 0)
        {
            newArray.Add("Fezz");
            return newArray;
        }

        bool hasAddedFezz = false;
        foreach (string word in outputArray)
        {
            if (hasAddedFezz)
            {
                newArray.Add(word);
                continue;
            }
            
            if (word.StartsWith("B"))
            {
                newArray.Add("Fezz");
                newArray.Add(word);
                hasAddedFezz = true;
            }
        }
    
        return newArray;
    })
    .AddRule(17, outputArray =>
    {
        outputArray.Reverse();
        return outputArray;
    })
    .Create();

for (int i = 1; i < 101; i++)
{
    var outputArray = new ArrayList();

    foreach (Rule rule in rules)
    {
        rule.ApplyRule(i, outputArray);
    }

    if (outputArray.Count == 0)
    {
        Console.WriteLine(i);
        continue;
    }

    foreach (var output in outputArray)
    {
        Console.Write(output);
    }
    Console.WriteLine();
}

public class Rule
{
    private Func<ArrayList, ArrayList> _RuleMethod;
    private int _value;
    public Rule(int value, Func<ArrayList, ArrayList> RuleMethod)
    {
        _value = value;
        _RuleMethod = RuleMethod;
    }

    public void ApplyRule(int valueToCheck, ArrayList outputArray)
    {
        if (valueToCheck % _value == 0)
        {
            outputArray = _RuleMethod(outputArray);
        }
    }
}

// Enumerator code from:
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-7.0

public class Rules : IEnumerable
{
    private Rule[] _rules;
    public Rules(Rule[] rules)
    {
        _rules = new Rule[rules.Length];
        for (int i = 0; i < rules.Length; i++)
        {
            _rules[i] = rules[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public RulesEnum GetEnumerator()
    {
        return new RulesEnum(_rules);
    }
}

public class RulesEnum : IEnumerator
{
    public Rule[] _rules;

    private int position = -1;

    public RulesEnum(Rule[] rules)
    {
        _rules = rules;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _rules.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Rule Current
    {
        get
        {
            try
            {
                return _rules[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

public class FizzBuzzRulesBuilder
{
    private Rule[] _rules;
    private int _size = 0;

    public FizzBuzzRulesBuilder AddRule(int value, Func<ArrayList, ArrayList> method)
    {
        var rule = new Rule(value, method);
        AddRuleToEnd(rule);
        return this;
    }

    private void AddRuleToEnd(Rule newRule)
    {
        Rule[] _newRules = new Rule[_size + 1];
        for (int i = 0; i < _size; i++)
        {
            _newRules[i] = _rules[i];
        }
        _newRules[_size] = newRule;
        _rules = _newRules;
        _size++;
    }

    public Rules Create()
    {
        return new Rules(_rules);
    }
}