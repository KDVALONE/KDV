

using System.Collections.Generic;

namespace DataLayer.Entityes
{
    /// Создали слой L3 - DataLayer, слой в даном случае это библиотека работы с БД
    /// В папке Entityes сущности для работы с БД
  
    /// <summary>
    ///Directory содержит список Materials
    /// </summary>
    public class Directory : Page
    {
        public List<Material> Materials { get; set; }
    }
}