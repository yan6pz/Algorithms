ArffSharp
=========

A .NET reader for the Attribute Relationship File Format (ARFF) used by Weka.

Currently only supports nominal valued attributes.

Many thanks to Sebastien Lorion's fantastic CsvReader: http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader

Sample:
```c#
using System;
using ArffSharp;

public class Program
{
    public static void Main(string[] args)
    {
        using (ArffReader reader = new ArffReader(@"data\training.arff"))
        {
            ArffRecord record;
            while ((record = reader.ReadNextRecord()) != null)
            {
                for (int valueIndex = 0; valueIndex < record.Values.Length; valueIndex++)
                {
                    var val = record.Values[valueIndex];
                    var attr = reader.Attributes[valueIndex];
                    Console.WriteLine("{0}: {1}", attr.Name, val.NominalValueIndex >= 0 ? attr.NominalValues[val.NominalValueIndex] : "?");
                }
                Console.WriteLine();
            }
        }
    }
}
```