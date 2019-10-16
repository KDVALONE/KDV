using System.Collections.Generic;
using DataLayer.Entityes;

namespace BuissnesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
     
        IEnumerable<Material> GetAllMaterials(bool includeMaterials = false);
        Material GetMaterialsById(int directroryId, bool includeMaterials = false);
        void SaveMaterials(Material achieve);
        void DeleteMaterials(Material achieve);




    }
}