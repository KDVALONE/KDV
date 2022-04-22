using System;
using System.Collections.Generic;
using System.Text;
using BuissnesLayer.Interfaces;
using DataLayer.Entityes;

namespace BuissnesLayer.Implementations
{
    class EFMaterialsReposytory : IMaterialsRepository
    {
       

        public IEnumerable<Material> GetAllMaterials(bool includeMaterials = false)
        {
            throw new NotImplementedException();
        }

        public Material GetMaterialsById(int directroryId, bool includeMaterials = false)
        {
            throw new NotImplementedException();
        }

        public void SaveMaterials(Material achieve)
        {
            throw new NotImplementedException();
        }
        public void DeleteMaterials(Material achieve)
        {
            throw new NotImplementedException();
        }
    }
}
