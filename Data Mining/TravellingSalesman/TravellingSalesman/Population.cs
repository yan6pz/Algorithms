using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class Population
    {
        public Route[] Tours { get; set; }
        public int PopulationSize { get; set; }

        public Population(int populationSize, bool initialise)
        {
            PopulationSize = populationSize;
            Tours = new Route[populationSize];
            if (initialise)
            {
                for (int i = 0; i < populationSize; i++)
                {
                    var newTour = new Route();
                    newTour.GenerateIndividual();
                    SaveTour(i, newTour);
                }
            }
        }


        public void SaveTour(int index, Route tour)
        {
            Tours[index] = tour;
        }


        public Route GetTour(int index)
        {
            return Tours[index];
        }

        //get the route in current population with greatest fitness
        public Route GetFittest()
        {
           //return this.Tours.Min(x => x.GetFitness());
            var fittest = Tours[0];
            for (int i = 1; i < this.PopulationSize; i++)
            {
                //get tour with smallest fitness
                if (fittest.Fitness >= GetTour(i).Fitness)
                {
                    fittest = GetTour(i);
                }
            }
            return fittest;
        }
    }
}

