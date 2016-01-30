using System.Collections.Generic;
using System.Linq;

namespace TravellingSalesman
{
    public class RouteManager
    {
        private static List<City> destinationCities = new List<City>();

        public static int NumberOfCities {
            get { return destinationCities.Count; }
            set { }
        }

        public static void AddCity(City city)
        {
            destinationCities.Add(city);
        }


        public static City GetCity(int index)
        {
            return destinationCities.ElementAt(index);
        }
    }
}
