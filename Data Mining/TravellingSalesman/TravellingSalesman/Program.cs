using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticAlgorithm.NumberOfTours = 50;
            int numberOfCities, step2, step3, step4;
            Console.Write("Number of cities:");
            numberOfCities = int.Parse(Console.ReadLine());
            Console.Write("Step one:");
            step2 = int.Parse(Console.ReadLine());
            Console.Write("Step two:");
            step3 = int.Parse(Console.ReadLine());
            Console.Write("Step three:");
            step4 = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberOfCities; i++)
            {
                var city = new City();
                RouteManager.AddCity(city);
            }

            
            var population = new Population(GeneticAlgorithm.NumberOfTours, true);
            //get the distance before the evolution
            Console.WriteLine("First distance: " + population.GetFittest().Distance);

            population = GeneticAlgorithm.EvolutionOfPopulation(population);
            for (int i = 0; i < 100; i++)
            {
                population = GeneticAlgorithm.EvolutionOfPopulation(population);
                //10-th step and 3 more
                if (i == step2 || i == step3 || i == step4 || i == 10)
                {
                    Console.WriteLine("Distance at " + i + " th generation: " + population.GetFittest().Distance);
                }
            }
            //last step
            Console.WriteLine("Last distance: " + population.GetFittest().Distance);
            Console.WriteLine("Best distance:");
            Console.WriteLine(population.GetFittest());
        }
    }
}
