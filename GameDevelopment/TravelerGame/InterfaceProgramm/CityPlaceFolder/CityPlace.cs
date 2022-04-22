using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{/// <summary>
/// Класс отвечает за прототип всех строений в городе.
/// 
/// </summary>
    public abstract class CityPlace
    {
        public CityPlaceTypes CityPlaceType { get; set; }
        public string CityPlaceName { get; set; }
        public string CityPlaceDescription { get; set; }
        public int Id { get { return this.Id; }
                        set { value = IdGenerator.GetId(); }  }
        public List<NPC> NpcOnLocation { get; set; } 
        public City CurrentCity { get; set; }

    }
      
    
}
