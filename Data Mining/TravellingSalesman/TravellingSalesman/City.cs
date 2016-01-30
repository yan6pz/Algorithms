using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{

    public class City
    {

        public int X { get; set; }
        public int Y { get; set; }
        private static Random random= new Random();


        public City()
        {
            X = random.Next(0,1000);
            Y = random.Next(0,1000);
        }

        public City(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }



        public double DistanceTo(City city)
        {
            int xDistance = Math.Abs(this.X - city.X);
            int yDistance = Math.Abs(this.Y - city.Y);
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return distance;
        }

        public override string ToString()
        {
            return "(" + this.X + "," + this.Y + ")";
        }



    }

}
