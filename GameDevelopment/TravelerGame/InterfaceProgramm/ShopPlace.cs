using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public sealed class ShopPlace : CityPlace
    {

        public ShopPlace()
        {
            CityPlaceType = CityPlaceTypes.shop;

        }
    }
}