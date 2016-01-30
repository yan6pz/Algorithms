using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    public class Route//:IComparable
    {
        public List<City> tour = new List<City>();
        public double Fitness
        {
            get
            { return GetDistance(); }
            set { }
        }
        public int Distance { get; set; }

        public Route()
        {
            for (int i = 0; i < RouteManager.NumberOfCities; i++)
            {
                tour.Add(null);
            }
        }

        public void GenerateIndividual()
        {

            for (int cityIndex = 0; cityIndex < RouteManager.NumberOfCities; cityIndex++)
            {
                SetCity(cityIndex, RouteManager.GetCity(cityIndex));
            }
            tour.Shuffle();
        }


        public City GetCity(int tourPosition)
        {
            return tour.ElementAt(tourPosition);
        }


        public void SetCity(int cityIndex, City city)
        {
            tour[cityIndex] = city;
            this.Fitness = 0;
            this.Distance = 0;
        }

        //how bigger is  the distance how smaller is the fitness

        //estimates the distance of the current path of cities
        public int GetDistance()
        {
            if (this.Distance == 0)
            {
                int tourDistance = 0;

                for (int cityIndex = 0; cityIndex < tour.Count; cityIndex++)
                {

                    var fromCity = GetCity(cityIndex);
                    City destinationCity;
                    //make hamilton loop, the next to last is first
                    if (cityIndex + 1 < tour.Count)
                    {
                        destinationCity = GetCity(cityIndex + 1);
                    }
                    else
                    {
                        destinationCity = GetCity(0);
                    }

                    tourDistance += (int)fromCity.DistanceTo(destinationCity);
                }
                this.Distance = tourDistance;
            }
            return this.Distance;
        }


        public bool ContainsCity(City city)
        {
            return tour.Contains(city);
        }

        public override string ToString()
        {
            var geneString = "" + GetCity(0);
            for (int i = 1; i < tour.Count; i++)
            {
                geneString += "->" + GetCity(i);
            }
            return geneString;
        }

    }
}

