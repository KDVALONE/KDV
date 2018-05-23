using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    static class QuestDescriptionGenerator
    {

        public static string[] DestenationPlace1 { get; private set; }
        public static string[] DestenationPlace2 { get; private set; }

        public static string[] HuntQuestDescription1 { get; private set; }
        public static string[] HuntQuestDescription2 { get; private set; }
        public static string[] HuntQuestName1 { get; private set; }
        public static string[] HuntQuestName2 { get; private set; }
        public static string[] HuntQuestName3 { get; private set; }

        public static string[] ExploringQuestDescription1 { get; private set; }
        public static string[] ExploringQuestDescription2 { get; private set; }
        public static string[] ExploringQuestName1 { get; private set; }
        public static string[] ExploringQuestName2 { get; private set; }
        public static string[] ExploringQuestName3 { get; private set; }

        private static Random rnd = new Random();
        static QuestDescriptionGenerator()
        {
            //HACK: тут используется хранение текстовых переменных в массиве. переработать в БД 
            DestenationPlace1 = new string[] { "приречном ", "сгнившем ", "старом ", "зарошенном " };
            DestenationPlace2 = new string[] { " заводе", "стойбище.", " складе", " храме" };

            HuntQuestName1 = new string [] { "Уничтожение ","Охота на ","Помощь с ликвидацией ","Прикопать " };
            HuntQuestName2 = new string[] { "серьезных ", "жалких ", "канибалов-", "" };
            HuntQuestName3 = new string[] { "бандитов", "отморозков", "марадеров", "рейдеров" };
            HuntQuestDescription1 = new string[] { ", Ха! Здарова, киллер хренов, вот тут кандидаты нахамили, кореша говорят твои, вот и разбирайся с ними сам, сидят они в ", ", заходи, дело срочное, нужно людям помочь. Засели гады в ", ", ты же у нас не против пострелять. Я тебя на подмогу пущу, дважды посылал уже туда ребят, чета не возвращаются, возможно уже и не придут. Идти нужно в ", ", вот есть задачка на интелект, далеко идти не нужно, тут рядом в " };
            HuntQuestDescription2 = new string[] { ", почирикай там, сведетелей если будут тоже отпой. Ну и ко мне.", ", всех прикопай там, серьезные дяди просят, если что, за тебя потом твои дела сами скажут. Ну ты не просри дело, короче.", ", я надеюсь ты везучий, смотри там побыстрее все обставь. И не святись долго, а то еще прибегут кореша их, а тебе оно надо?Так что по быстрому давай. ", ", пулей туда, и всек к стенке ставь, они столько дел натворили, ты еще сам блин приплатил бы еслиб знал. Потом за пивом расскажу, давай не тормози." };

            ExploringQuestName1 = new string[] { "Найти ", "Достать ", "Попробовать отыскать ", "Раздобыть " };
            ExploringQuestName2 = new string[] { "ценный ", "ржавый ", "", "старый " };
            ExploringQuestName3 = new string[] { "хлам", "хабар", "лут", "скраб" };
            ExploringQuestDescription1 = new string[] { ", короче нужно ко что достать, не парься не много тащить нужно. Сходишь в ",", раздобуть мне вот чего, я тебе место сейчас чиркану одно, там кое что лежит. Значит вот тут у нас ",", блин, а я думал за мной пришли! Короче, срочно нужно достать для меня вещичку одну, видишь дерганный из за нее, бежать нужно в  ",", заходи. Как сам? Ну да хрен сним, значит добудь мне по старой памяти фигню одну, ладно? Она в  " };
            ExploringQuestDescription2 = new string[] { ", вот, а как добудешь сразу назад, увидешь ты ее там, кроме нее ничего там нету." , ", забираешь, что есть и назад, все просто.",", вообще тут приключение на 10 минут, зашел и вышел. Ну и взял, что к полу не прибито, конечно, не промахнешься вобщем",", значит, ну а там такая хреновина, ну ты поймешь, там ничего больше нет, как обычно, по одиночке всегда такие штуки харанят. Ну найдешь и домой." };
            

        }

        public static Dictionary<string, string> GetQuestDescription(QuestType qestType)
        {

            string huntQuestNameComplite = (HuntQuestName1[rnd.Next(0, HuntQuestName1.Length)]) +
                                           (HuntQuestName2[rnd.Next(0, HuntQuestName2.Length)]) + (HuntQuestName3[rnd.Next(0, HuntQuestName3.Length)]);

            string huntQuestDescriptionComplite = (HuntQuestDescription1[rnd.Next(0, HuntQuestDescription1.Length)]) + (HuntQuestDescription2[rnd.Next(0, HuntQuestDescription2.Length)]);

            string exploringQuestNameComplite = (ExploringQuestName1[rnd.Next(0, ExploringQuestName1.Length)]) +
                                                (ExploringQuestName2[rnd.Next(0, ExploringQuestName2.Length)]) + (ExploringQuestName3[rnd.Next(0, ExploringQuestName3.Length)]);
            string exploringQuestDescriptionComplite = (ExploringQuestDescription1[rnd.Next(0, ExploringQuestDescription1.Length)]) + (ExploringQuestDescription2[rnd.Next(0, ExploringQuestDescription2.Length)]);
            switch quest

            Dictionary<string, string> QuestDescription = new Dictionary<string, string>();
            QuestDescription.Add();


            return QuestDescription;

        }

    }
}
