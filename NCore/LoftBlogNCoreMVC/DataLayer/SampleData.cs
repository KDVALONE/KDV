using DataLayer.Entityes;
using DataLayer.Migrations;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace DataLayer
{
    public static  class SampleData
    {

        // Если в таблице прим. Directory нет данных, то мы довабляем директории с занч. по умолчанию
        /// <summary>
        /// Статический метод который инициализирует БД, по умолчанию
        /// </summary>>
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                context.Directory.Add(new Entityes.Directory() {Title = "First Directory", Html = "<b>Directory Content</b>"});
                context.Directory.Add(new Entityes.Directory() { Title = "Second Directory", Html = "<b>Directory Content</b>" });
                context.SaveChanges();

                context.Materials.Add(new Entityes.Material() {Title = "First Material", Html = "<i>Material Content</i>",DirectoryId = context.Directory.First().Id});
                context.Materials.Add(new Entityes.Material() { Title = "Second Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
                context.Materials.Add(new Entityes.Material() { Title = "Third Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.Last().Id });
                context.SaveChanges();
            }

        }
    }
}