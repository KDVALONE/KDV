namespace DataLayer.Entityes
{
    /// Создали слой L3 - DataLayer, слой в даном случае это библиотека работы с БД
    /// В папке Entityes сущности для работы с БД

    /// <summary>
    /// Верхнеуровневый уровень сущности, от него наследуются Directory и Materials
    /// </summary>
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Html { get; set; }
    }
}