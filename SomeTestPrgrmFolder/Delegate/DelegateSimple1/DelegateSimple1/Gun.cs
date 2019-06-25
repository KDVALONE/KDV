
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DelegateSimple1
{
    class Gun
    {
        public string GunName { get; set; } 
        public int GunAmmoMax { get; set; }
        public int GunAmmoCurrent { get; set; }
        /*  public int GunAmmoCurrent
          {
              get { return GunAmmoCurrent; }
              set {
                  if (value < 0)
                  { GunAmmoCurrent = 0; }
                  else if (value > GunAmmoMax)
                  { GunAmmoCurrent = GunAmmoMax; }
                  else
                  { GunAmmoCurrent = value; }
                  }
          }*/
        public Gun(string gunName, int gunAmmoCurrent)
                    : this(gunName, 10, gunAmmoCurrent )
        {

        }
        public Gun(string gunName, int gunAmmoMax, int gunAmmoCurrent)
        {
            GunName = gunName;
            GunAmmoMax =  gunAmmoMax;
            GunAmmoCurrent = gunAmmoCurrent;
        }

        public delegate void GunLoaderHandler(string msgForCaller);

        private GunLoaderHandler listOfHandlers;

        public void RegisterMethodForDelegate(GunLoaderHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        public void Shooting()
        {
            bool flag = true;
            while (flag)
            {
               
                if (GunAmmoCurrent == 0)
                {
                     listOfHandlers("You havent ammo enymore");
                     flag = false;
                }
            else
                 {
                     GunAmmoCurrent -= 1;
                     Thread.Sleep(500);

                     if (GunAmmoCurrent == 3)
                     {
                       listOfHandlers($"Your {GunName} ammo is low {GunAmmoCurrent} of {GunAmmoMax}");
                     }
                
                  }
            }
        }


    }
}