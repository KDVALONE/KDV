using DataLayer.Entityes;
using System.Collections.Generic;

namespace BuissnesLayer.Interfaces
{
    public interface IDirectorysRepository
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false);
        Directory GetDirectoryById(int directroryId, bool includeMaterials = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}