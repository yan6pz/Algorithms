using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knn
{
    //Clasification machine learning algorithm
    class Knn
    {
        public List<string[]> TrainData { get; set; }
        public int K { get; set; }
        public Knn(List<string[]> trainData,int k)
        {
            TrainData = trainData;
            K = k;
        }
        public  void identifyClass(string[] testRow)
        {


            var table = new List<Item>();   
            foreach (var trainRow in TrainData)
            {
                table.Add(new Item(getDistance(testRow, trainRow), trainRow[4]));
            }


            table.Sort();

            var classNumber = new Dictionary<string, int>();
            FindMostOftenClass(table, classNumber);

            string chosenClass = string.Empty;
            int currentMaxCount = 0;

            FindMostCommon(classNumber, ref chosenClass, ref currentMaxCount);

            Console.WriteLine("The Class of {0} is:{1}", string.Join(", ", testRow), chosenClass);
        }

        private static void FindMostCommon(Dictionary<string, int> classNumber, ref string chosenClass, ref int currentMaxCount)
        {
            foreach (var theClass in classNumber.Keys)
            {
                if (classNumber[theClass] > currentMaxCount)
                {
                    currentMaxCount = classNumber[theClass];
                    chosenClass = theClass;
                }
            }
        }

        private void FindMostOftenClass(List<Item> table, Dictionary<string, int> classNumber)
        {
            for (var row = 0; row < K; row++)
            {

                if (!classNumber.ContainsKey(table[row].theClass))
                {
                    classNumber.Add(table[row].theClass, 1);   
                }
                else
                {
                    classNumber[table[row].theClass] = classNumber[table[row].theClass] + 1;  
                }
            }
        }

        private static double getDistance(string[] testInstance, string[] trainInstance)
        {
            double sum = 0;
            for (int i = 0; i < testInstance.Length-1; i++)
            {
                sum += Math.Pow(double.Parse(testInstance[i]) - double.Parse(trainInstance[i]), 2);
            }
            return sum;
        }
    }

}

