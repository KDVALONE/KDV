using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    static class CityDescriptionGenerator
    {
        /// <summary>
        /// TODO: каласс для генерации имени города, передаелать на БД
        /// </summary>
        private static Random random = new Random();
        public static string CityNameComplete{ get; private set; }
        public static string CityDescComplete { get; private set; }

        public static string[] TownName { get; private set; }
        public static string[] BigCityName { get; private set; }
        public static string[] VillageName { get; private set; }

        public static string[] TownDesc { get; private set; }
        public static string[] BigCityDesc {  get; private set; }
        public static string[] VillageDesc { get; private set; }
       

        static CityDescriptionGenerator()
        {
            
            BigCityName = new string[] { "N","Новая Самара", "Рунославль","Велий Волок","519" };
            TownName = new string[] { "Черная вода","Тихие поляны","Первый арсенал", "Климовск","Охранск" };
            VillageName = new string[] { "Верхние рощи", "Спасение", "Кресты","Нигдеево","Изотопово" };

            TownDesc = new string[] {$",это маленький городок где есть нормальная выпивка, в меру продажные девушки, почти нет прокаженных. Хорошое место, не смотря на тотальный канибализм",
                                    $", небольшой город возле старого фосфорного склада, очень красивое место. Жителей не много, но те что есть, вполне мирные, а вечерами город очень красиво светиться.",
                                     $", об этом небольшом городе мало информации, ходят слухи что тут существует какой то культ, а некоторые жители даже выходят на бесплатные работы по субботам. Зато вечером бесплатная похлебка. Странное место." };
            BigCityDesc = new string[] { $", город который простирается на выжженной до тла местности, созданные из хлама заградительные барьеры удерживают готовых позариться на банд с окрестных земель. Благодаря мощным фортификационным сооружением город быстро разросся и теперь является крупным пристанищем всякого врода сброда, вроде вас. ",
                                      $", это огромный, загрязненный выхлопом сотен угольных печей город.Он создает гнетущее впечатление. Когдато на его месте были угольные разработки. Пригодные для проживания остатки шахт, оставшиеся в разрушенных складах горы угля, обеспечивающие комфортное жилье гражданам, сделали город желанным местом обитания для многих. ",
                                       $", так называется место куда никто не хочет попасть, здесь собрались культисты, канибалы, падальщики, изгнанные из других мест и больные проказой. Город как одна огромная пульсирующая язва раскидывается вдоль останков старого аэропорта." };
            VillageDesc = new string[] { $", маленькая деревенька, пристанище потомков бывших работорговцев, которых во время бунта перебили рабы, оставив в живых лишь детей и принявших их как своих ",
                                        $". Поехавшие крыши, перекошенные дома, двинутые люди. Обыкновенное поселение.",
                                        $" это ваш любимый котеджный поселок! Такая надпись сохранилась на арке в открытом поле, в центре которого в вырытых землянках ютятся немногочисленные жители."};
        }
        public static Dictionary<string, string> GetCityDescription(CityTypes cityType)
        {
            Dictionary<string, string> CityDescriptionDict = new Dictionary<string, string>();
            switch (cityType)
            {
                case CityTypes.bigCity:
                    CityNameComplete = BigCityName[random.Next(0, BigCityName.Length)];
                    CityDescComplete = CityNameComplete + (BigCityDesc[random.Next(0, BigCityName.Length)]);
                        break;
                    
                case CityTypes.town:
                    CityNameComplete = TownName[random.Next(0, BigCityName.Length)];
                    CityDescComplete = CityNameComplete + (TownDesc[random.Next(0, BigCityName.Length)]);

                    break;

                case CityTypes.village:
                    CityNameComplete = VillageName[random.Next(0, BigCityName.Length)];
                    CityDescComplete = CityNameComplete + (VillageDesc[random.Next(0, BigCityName.Length)]);

                    break;
            }

            CityDescriptionDict.Add(CityNameComplete, CityDescComplete);



            return CityDescriptionDict;
        }

    }
}
