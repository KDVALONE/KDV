using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = new City();
            city.Name = "Ekaterinburg";
            city.Location = new GeoLocation();
            city.Location.Latitude = 56.50;
            city.Location.Longitude = 60.35;
            Console.WriteLine("I love {0} located at ({1}, {2})",
                city.Name,
                city.Location.Longitude.ToString(CultureInfo.InvariantCulture),
                city.Location.Latitude.ToString(CultureInfo.InvariantCulture));
        }
    }
   class City   { public string Name;     public GeoLocation Location;  }
    class GeoLocation    {   public double Latitude = 0;     public double Longitude = 0;   }
}
