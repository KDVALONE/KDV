using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public class Item // предмет, находитсья в инвентаре.
    {
        public float IdItem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } // описание

        public Item(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public virtual object ItemProperties() // совойство предмета, например восполнять здоровье.
        {
            return 0 ;
        }

    }
}
