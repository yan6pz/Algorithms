using ArffSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knn
{
    class Program
    {


        static List<string[]> trainData = new List<string[]>();
        static List<string[]> testData = new List<string[]>();

        public static void Main(string[] args)
        {
            try
            {
                /*bool exists = File.Exists("Data/iris.arff");
                using (ArffReader reader = new ArffReader(@"Data/iris.arff"))
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
                }*/

                string line;
                int counter = 0;
                using (var stream = File.OpenRead("Data/iris.arff"))
                {
                    using (var reader = new StreamReader(stream))
                    {

                        while ((line = reader.ReadLine()) != null)
                        {
                            //put every ten tuple in thetest data
                            if (counter % 10 == 0)
                                testData.Add(line.Split(','));
                            else
                                trainData.Add(line.Split(','));

                            counter++;
                        }
                    }
                }
                //11 for more precise
                Console.WriteLine("How big is k:");
                var k = int.Parse(Console.ReadLine());
                var knn = new Knn(trainData, k);
                foreach (var item in testData)
                {
                    knn.identifyClass(item);
                }
              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}


