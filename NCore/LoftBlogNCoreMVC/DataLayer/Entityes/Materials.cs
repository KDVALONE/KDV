namespace DataLayer.Entityes
{
    /// Создали слой L3 - DataLayer, слой в даном случае это библиотека работы с БД
    /// В папке Entityes сущности для работы с БД

    /// <summary>
    ///Materials содержит cсылку на id из БД и навигационное свойство
    /// </summary>
    public class Material:Page
    {
        public int DirectoryId { get; set; } // foreign key
        public Directory Directory { get; set; } // Navigation property reference 
    }
}