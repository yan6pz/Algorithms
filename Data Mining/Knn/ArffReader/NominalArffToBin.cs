namespace ArffSharp
{
    using System;
    using System.IO;
    using System.Linq;

    public class NominalArffToBin
    {
        public static void Convert(string inputArffFile, string outputFile)
        {
            int lineCount = 0;
            using (ArffReader reader = new ArffReader(inputArffFile))
            {
                using (var writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
                {
                    var maxAttributeValueCount = reader.Attributes.Max(a => a.NominalValues.Count);
                    Console.WriteLine("Max attribute value count: " + maxAttributeValueCount);
                    if (maxAttributeValueCount > byte.MaxValue)
                    {
                        throw new ArgumentOutOfRangeException("maxAttributeValueCount", "One attribute has more than " + byte.MaxValue + " possible values.");
                    }

                    writer.Write(reader.Attributes.Count);
                    ArffRecord record;
                    while ((record = reader.ReadNextRecord()) != null)
                    {
                        var values = record.Values;
                        for (int i = 0; i < values.Length; i++)
                        {
                            writer.Write((byte)values[i].NominalValueIndex);
                        }
                        ++lineCount;
                        if (lineCount % 1000 == 0 && lineCount > 0) Console.Write(lineCount + " ");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total records: " + lineCount);
        }
    }
}
