using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public static class CityPlaceDescGenerator
    {
        //TODO: Переделать в бд, с помощью LINQ, это избавит от кучи статик методов.Пока костыль.
        #region Properties and constructor
        private static Random random = new Random();

        public static string[] TownMedCenterName { get; private set; }
        public static string[] BigCityMedCenterName { get; private set; }
        public static string[] VillageMedCenterName { get; private set; }

        public static string[] TownInnName { get; private set; }
        public static string[] BigCityInnName { get; private set; }
        public static string[] VillageInnName { get; private set; }

        public static string[] TownShopName { get; private set; }
        public static string[] BigCityShopName { get; private set; }
        public static string[] VillageShopName { get; private set; }


        public static string[] TownMedCenterDesc { get; private set; }
        public static string[] BigCityMedCenterDesc { get; private set; }
        public static string[] VillageMedCenterDesc { get; private set; }

        public static string[] TownInnDesc { get; private set; }
        public static string[] BigCityInnDesc { get; private set; }
        public static string[] VillageInnDesc { get; private set; }

        public static string[] TownShopDesc { get; private set; }
        public static string[] BigCityShopDesc { get; private set; }
        public static string[] VillageShopDesc { get; private set; }

        static CityPlaceDescGenerator()
        {

            TownMedCenterName = new string[] { "Госпиталь 26", "Винерологический диспансер", "Красный крест", "Лекарства и лекари", "Санчасть" };
            BigCityMedCenterName = new string[] { "Лечебный дом", "Медицинский погребок", "Вторая помощь", "Ай Болит", "Координальное лечение" };
            VillageMedCenterName = new string[] { "Настойки и припарки", "Знахорская", "Спасем за деньги", "Поддорожник", "Поветуха" };

            TownInnName = new string[] { "Постоялый двор", "Черные земли", "Гарцующий пони", "Покойся с миром", "Завтрак на обочине" };
            BigCityInnName = new string[] { "Граненый стакан", "Тихий приют", "Сладкая ночь", "Почти чистая простыня", "Доходный дом" };
            VillageInnName = new string[] { "Ночевальня", "Переночуй или умри", "У старого костра", "Сон и еда", "От заката до рассвета" };

            TownShopName = new string[] { "Певрый магазин", "Черный рынок", "Товары для путников", "Скупка", "Товары" };
            BigCityShopName = new string[] { "Черная вода", "Тихие поляны", "Первый арсенал", "Климовск", "Охранск" };
            VillageShopName = new string[] { "Верхние рощи", "Спасение", "Кресты", "Нигдеево", "Изотопово" };

            TownMedCenterDesc = new string[] {$", медицинский пункт, расположенный в стоящем отдельно стоящем старом вогоне метро. Интересно откуда он здесь?",
                                    $", здание оказание медицинской помощи, судя по рисунку храмой перевязанной собаки возле входной двери. ",
                                     $", местный медицинский пункт. Когда вы смотрите на копоть над окнами здания, вам кажется странным, что у всех окон и дверей есть засовы с наружи" };
            TownInnDesc = new string[] {$",судя по названию ночлежка, явно не для местных, которых здесь не очень то любят",
                                    $", ночлежка где можно отдохнуть и отоспаться, если есть деньги, расположена на сваях над выгребной ямой. И кто такое придумал?",
                                     $", гостиница, расположенна на окраине поселения. Здание похоже раньше было ратушей." };
            TownShopDesc = new string[] { $", торговая лавка, окруженная кучей разного рода сброда.",
                                        $", местный магазин. Циферблат старых уличных часов служит украшением при входе. Стрелки отсутствуют.",
                                        $", магазин всякого барахла, расположенный в не очень уютном тупиче. Подходя к нему у вас появляется ощущение, что за вами кто-то следит."};

            BigCityMedCenterDesc = new string[] {$", хоть на надписи явно написанно, что тут крупный медицинский центр, но чутье вам подсказывает, что не только",
                                    $",крупный медицинский центр. Вы выдете людей в белых халатах, которые постоянно бегают по проложенным навесным мостам между корпусами. ",
                                     $", огражденный колючей проволкой огромный мед центр. При воходе вы видите старый дорожный знак, на котором кто-то написал напдпись 'Цикады' " };
            BigCityInnDesc = new string[] {$", ярко покрашенное здание гостиницы. Крики и громкие звуки драки раздаются из нутри. Вам точно сюда.",
                                    $", эта гостиница напоминает замок. Даже ров с опускающимися воротами есть. В воде, вокруг рва, плавает что-то крупное.",
                                     $", крупная городская ночлежка. Звуки музыки, исходящие из нутри, еле заглушают громкую брань и смех." };
            BigCityShopDesc = new string[] { $", торговая лавка, знаки старых валют висят на доске перед входом.",
                                        $", старый бункер переоборудованный под торговые нужды. Рядом при входе стоит гонг к которому приставлен молот. Интересно зачем.",
                                        $", большой магазин на старой площади. Вокруг воляются жженные покрышки."};

            VillageMedCenterDesc = new string[] {$",местный мед пункт, в подвале покосившегося здания.",
                                    $", палатка с нарисованным красным крестом. Похоже здесь могут сделать перевязку. ",
                                     $", старый сарай, сбитый из листов шифера и досок. Похоже здесь оказывают мед помощь." };
            VillageInnDesc = new string[] {$", вы видите старый коллекторный люк. Рядом с ним на доске нарисованна кровать и стрелка указвающая, что нужно спуститья.",
                                    $", местная ночлежка. Кто то жарит мясо на костре возле входа. Похоже выглядит безопасно.",
                                     $", ночлежка, если можно назвать старый коровник в котором нет дверей ночлежкой. За ночевку все равно придется платить при входе." };
            VillageShopDesc = new string[] { $", на скорую руку сбитая торговая палатка. Продается всякий хлам",
                                        $", торговая лавка. Торговец расположился в выротой собственноручно землянке.",
                                        $", похоже торговец торгует прям из окна дома в котором живет, так как соорудил возле него что-то вроде прилавка."};




        }
        #endregion

        public static Dictionary<string, string> GetCityPlaceDesc(CityPlaceTypes cityPlaceType, CityTypes cityType )
        {
            string CityPlaceNameComplete = "";
            string CityPlaceDescComplete = "";

        Dictionary<string, string> CityPlaceDescDict = new Dictionary<string, string>();
            switch (cityPlaceType)
            {
                case CityPlaceTypes.medCenter:
                    GetMedCenterDesc(cityType, ref CityPlaceNameComplete, CityPlaceDescComplete);
                    break;

                case CityPlaceTypes.inn:

                    GetInnDesc(cityType, ref CityPlaceNameComplete, CityPlaceDescComplete);
                    break;

                case CityPlaceTypes.shop:

                    GetShopDesc(cityType, ref CityPlaceNameComplete, CityPlaceDescComplete);
                    break;
            }

            CityPlaceDescDict.Add(CityPlaceNameComplete, CityPlaceDescComplete);


        
            return CityPlaceDescDict;
        }

        private static void GetMedCenterDesc(CityTypes cityType, ref string cityPlaceNameComplete, string cityPlaceDescComplete)
        {
            switch (cityType)
            { 
            case CityTypes.bigCity:
                    cityPlaceNameComplete = BigCityMedCenterName[(random.Next(0, BigCityMedCenterName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (BigCityMedCenterDesc[(random.Next(0, BigCityMedCenterDesc.Length))]);
                    break;
            case CityTypes.town:
                    cityPlaceNameComplete = TownMedCenterName[(random.Next(0, TownMedCenterName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (TownMedCenterDesc[(random.Next(0, TownMedCenterDesc.Length))]);
                    break;
            case CityTypes.village:
                    cityPlaceNameComplete = VillageMedCenterName[(random.Next(0, VillageMedCenterName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (VillageMedCenterDesc[(random.Next(0, VillageMedCenterDesc.Length))]);
                    break;
            }
        }
        private static void GetShopDesc(CityTypes cityType, ref string cityPlaceNameComplete, string cityPlaceDescComplete)
        {
            switch (cityType)
            {
                case CityTypes.bigCity:
                    cityPlaceNameComplete = BigCityShopName[(random.Next(0, BigCityShopName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (BigCityShopDesc[(random.Next(0, BigCityShopDesc.Length))]);
                    break;
                case CityTypes.town:
                    cityPlaceNameComplete = TownShopName[(random.Next(0, TownShopName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (TownShopDesc[(random.Next(0, TownShopDesc.Length))]);
                    break;
                case CityTypes.village:
                    cityPlaceNameComplete = VillageShopName[(random.Next(0, VillageShopName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (VillageShopDesc[(random.Next(0, VillageShopDesc.Length))]);
                    break;
            }
        }
        private static void GetInnDesc(CityTypes cityType, ref string cityPlaceNameComplete, string cityPlaceDescComplete)
        {
            switch (cityType)
            {
                case CityTypes.bigCity:
                    cityPlaceNameComplete = BigCityInnName[(random.Next(0, BigCityInnName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (BigCityInnDesc[(random.Next(0, BigCityInnDesc.Length))]);
                    break;
                case CityTypes.town:
                    cityPlaceNameComplete = TownInnName[(random.Next(0, TownInnName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (TownInnDesc[(random.Next(0, TownInnDesc.Length))]);
                    break;
                case CityTypes.village:
                    cityPlaceNameComplete = VillageInnName[(random.Next(0, VillageInnName.Length))];
                    cityPlaceDescComplete = cityPlaceNameComplete + (VillageInnDesc[(random.Next(0, VillageInnDesc.Length))]);
                    break;
            }
        }


    }
}
