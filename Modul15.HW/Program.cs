using System;
using System.Collections.Generic;
using System.Reflection;

public class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        ListMethods(typeof(Console));
        ReflectProperties(new Car { Brand = "Toyota", Year = 2022 });
        InvokeSubstring("Hello, World!", 7, 5);
        ListConstructors(typeof(List<int>));
    }

    static void ListMethods(Type type)
    {
        Console.WriteLine($"Methods in {type.Name} class:");
        MethodInfo[] methods = type.GetMethods();

        foreach (var method in methods)
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("\n-----------------------------------\n");
    }

    static void ReflectProperties(object instance)
    {
        Console.WriteLine("Properties and values:");
        Type type = instance.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (var property in properties)
        {
            Console.WriteLine($"{property.Name} = {property.GetValue(instance)}");
        }

        Console.WriteLine("\n-----------------------------------\n");
    }

    static void InvokeSubstring(string str, int startIndex, int length)
    {
        Console.WriteLine("Invoking Substring method on a string:");
        MethodInfo substringMethod = typeof(string).GetMethod("Substring", new[] { typeof(int), typeof(int) });

        if (substringMethod != null)
        {
            object result = substringMethod.Invoke(str, new object[] { startIndex, length });
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Substring method not found in String class.");
        }

        Console.WriteLine("\n-----------------------------------\n");
    }

    static void ListConstructors(Type type)
    {
        Console.WriteLine($"Constructors of {type.Name} class:");
        ConstructorInfo[] constructors = type.GetConstructors();

        foreach (var constructor in constructors)
        {
            Console.WriteLine(constructor.ToString());
        }

        Console.WriteLine("\n-----------------------------------\n");
    }
}
