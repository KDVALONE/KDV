using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    static class QuestDescriptionGenerator
    {

        public static string[] destenationPlace1 { get; private set; }
        public static string[] destenationPlace2 { get; private set; }

        public static string[] huntQuestDescription1 { get; private set; }
        public static string[] huntQuestDescription2 { get; private set; }
        public static string[] huntQuestName1 { get; private set; }
        public static string[] huntQuestName2 { get; private set; }
        public static string[] huntQuestName3 { get; private set; }

        public static string[] exploringQuestDescription1 { get; private set; }
        public static string[] exploringQuestDescription2 { get; private set; }
        public static string[] exploringQuestName1 { get; private set; }
        public static string[] exploringQuestName2 { get; private set; }
        public static string[] exploringQuestName3 { get; private set; }

        private static Random rnd = new Random();
        static QuestDescriptionGenerator()
        {
            //HACK: тут используется хранение текстовых переменных в массиве. переработать в БД 
            destenationPlace1 = new string[] { "приречном ", "сгнившем ", "старом ", "заброшенном " };
            destenationPlace2 = new string[] { " заводе", "стойбище.", " складе", " храме" };

            huntQuestName1 = new string [] { "Уничтожение ","Охота на ","Помощь с ликвидацией ","Прикопать " };
            huntQuestName2 = new string[] { "серьезных ", "жалких ", "канибалов-", "" };
            huntQuestName3 = new string[] { "бандитов", "отморозков", "марадеров", "рейдеров" };
            huntQuestDescription1 = new string[] { ", Ха! Здарова, киллер хренов, вот тут кандидаты нахамили, кореша говорят твои, вот и разбирайся с ними сам, сидят они в ", ", заходи, дело срочное, нужно людям помочь. Засели гады в ", ", ты же у нас не против пострелять. Я тебя на подмогу пущу, дважды посылал уже туда ребят, чета не возвращаются, возможно уже и не придут. Идти нужно в ", ", вот есть задачка на интелект, далеко идти не нужно, тут рядом в " };
            huntQuestDescription2 = new string[] { ", почирикай там, сведетелей если будут тоже отпой. Ну и ко мне.", ", всех прикопай там, серьезные дяди просят, если что, за тебя потом твои дела сами скажут. Ну ты не просри дело, короче.", ", я надеюсь ты везучий, смотри там побыстрее все обставь. И не святись долго, а то еще прибегут кореша их, а тебе оно надо?Так что по быстрому давай. ", ", пулей туда, и всек к стенке ставь, они столько дел натворили, ты еще сам блин приплатил бы еслиб знал. Потом за пивом расскажу, давай не тормози." };

            exploringQuestName1 = new string[] { "Найти ", "Достать ", "Попробовать отыскать ", "Раздобыть " };
            exploringQuestName2 = new string[] { "ценный ", "ржавый ", "", "старый " };
            exploringQuestName3 = new string[] { "хлам", "хабар", "лут", "скраб" };
            exploringQuestDescription1 = new string[] { ", короче нужно ко что достать, не парься не много тащить нужно. Сходишь в ",", раздобуть мне вот чего, я тебе место сейчас чиркану местечко одно, там кое что лежит. Значит вот тут в ",", блин, а я думал за мной пришли! Короче, срочно нужно достать для меня вещичку одну, видишь дерганный из за нее, бежать нужно в  ",", заходи. Как сам? Ну да хрен сним, значит добудь мне по старой памяти фигню одну, ладно? Она в  " };
            exploringQuestDescription2 = new string[] { ", вот, а как добудешь сразу назад, увидешь ты ее там, кроме нее ничего там нету." , ", забираешь, что есть и назад, все просто.",", вообще тут приключение на 10 минут, зашел и вышел. Ну и взял, что к полу не прибито, конечно, не промахнешься вобщем",", значит, ну а там такая хреновина, ну ты поймешь, там ничего больше нет, как обычно, по одиночке всегда такие штуки харанят. Ну найдешь и домой." };
            

        }

        public static Dictionary<string, string> GetQuestDescription(QuestTypes questType)
        {

            string huntQuestNameComplite = (huntQuestName1[rnd.Next(0, huntQuestName1.Length)]) +
                                           (huntQuestName2[rnd.Next(0, huntQuestName2.Length)]) +
                                           (huntQuestName3[rnd.Next(0, huntQuestName3.Length)]);

            string huntQuestDescriptionComplite = (huntQuestDescription1[rnd.Next(0, huntQuestDescription1.Length)]) +
                                                  (huntQuestDescription2[rnd.Next(0, huntQuestDescription2.Length)]);

            string exploringQuestNameComplite = (exploringQuestName1[rnd.Next(0, exploringQuestName1.Length)]) +
                                                (exploringQuestName2[rnd.Next(0, exploringQuestName2.Length)]) + 
                                                (exploringQuestName3[rnd.Next(0, exploringQuestName3.Length)]);

            string exploringQuestDescriptionComplite = (exploringQuestDescription1[rnd.Next(0, exploringQuestDescription1.Length)]) + 
                                                       (exploringQuestDescription2[rnd.Next(0, exploringQuestDescription2.Length)]);

            Dictionary<string, string> QuestDescription = new Dictionary<string, string>();

            switch (questType)
            {
               case QuestTypes.Hunt:
               QuestDescription.Add(huntQuestNameComplite, huntQuestDescriptionComplite);
               break;
          
               case QuestTypes.Exploring:
               QuestDescription.Add(exploringQuestNameComplite, exploringQuestDescriptionComplite);
               break;
            }
            return QuestDescription;
        }// Генерирует описание квеста в зависимости от типа.
    }
}
