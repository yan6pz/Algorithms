using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class GeneticAlgorithm
    {
        private static double mutationRate = 0.015;
        private static int tournamentSize = 10;

        public static int NumberOfTours { get; set; }
        static Random  rnd = new Random();

        public static Population EvolutionOfPopulation(Population pop)
        {

            var newPopulation = new Population(pop.PopulationSize, false);
            //keep the best route
            newPopulation.SaveTour(0, pop.GetFittest());

            for (int i = 1; i < newPopulation.PopulationSize; i++)
            {

                var parent1 = TournamentSelection(pop);
                var parent2 = TournamentSelection(pop);
                var child = Crossover(parent1, parent2);
                newPopulation.SaveTour(i, child);
            }

            for (int i = 1; i < newPopulation.PopulationSize; i++)
            {
                Mutate(newPopulation.GetTour(i));
            }

            return newPopulation;
        }

        //Randomly get cities from first parent and insert them into the child
        //If there are no cities fill them with the cities from second parent
        private static Route Crossover(Route parent1, Route parent2)
        {

            var child = new Route();

            var startPos = rnd.Next(RouteManager.NumberOfCities);
            var endPos = rnd.Next(RouteManager.NumberOfCities);


            for (int i = 0; i < RouteManager.NumberOfCities; i++)
            {

                if (startPos < endPos && i > startPos && i < endPos)
                {
                    child.SetCity(i, parent1.GetCity(i));
                }
                else if (startPos > endPos)
                {
                    if (!(i < startPos && i > endPos))
                    {
                        child.SetCity(i, parent1.GetCity(i));
                    }
                }
            }


            for (int i = 0; i < parent2.tour.Count; i++)
            {

                if (!child.ContainsCity(parent2.GetCity(i)))
                {

                    for (int j = 0; j < RouteManager.NumberOfCities; j++)
                    {
                        //fill the empty genes with the genes of the second parent
                        if (child.GetCity(j) == null)
                        {
                            child.SetCity(j, parent2.GetCity(i));
                            break;
                        }
                    }
                }
            }

            return child;
        }

        //randomly swap genes(cities)
        private static void Mutate(Route tour)
        {

            for (int tourPos1 = 0; tourPos1 < tour.tour.Count; tourPos1++)
            {

                if (rnd.Next(RouteManager.NumberOfCities) < mutationRate)
                {

                    var tourPos2 = rnd.Next(RouteManager.NumberOfCities);
                    var  city1 = tour.GetCity(tourPos1);
                    var  city2 = tour.GetCity(tourPos2);
                    tour.SetCity(tourPos2, city1);
                    tour.SetCity(tourPos1, city2);
                }
            }
        }
        //get the best (fittest) from population for crossover
        private static Route TournamentSelection(Population pop)
        {

            var tournament = new Population(tournamentSize, false);

            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = rnd.Next(GeneticAlgorithm.NumberOfTours);
                tournament.SaveTour(i, pop.GetTour(randomId));
            }

            var fittest = tournament.GetFittest();
            return fittest;
        }
    }
}
