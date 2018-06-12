using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CybForumFactor
{
        class Program
        {
            static void Main(string[] args)
            {
                var factoies = new List<IBaseQuestFactory<BaseQuest>>();
                factoies.AddRange(Enumerable.Repeat(new MissionFactory(), 2));
                factoies.AddRange(Enumerable.Repeat(new IventFactory(), RandomHelper.Random(2, 5)));
                factoies.AddRange(Enumerable.Repeat(new QuestFactory(), RandomHelper.Random(5, 10)));
                foreach (var quest in factoies.Select(f => f.Create()))
                    quest.Print();

                Console.ReadKey();
            }
        }

        //базовая модель квеста
        public abstract class BaseQuest
        {
            public string Name;

            public string Description;

            public virtual void Print() => Console.WriteLine($"[{Name}]\nописание: {Description}");
        }

        //реализация описания квеста
        public class Mission : BaseQuest
        {
            public Mission NextMission;
            public bool Allow;

            public override void Print()
            {
                if (Allow)
                    base.Print();
                else
                    Console.WriteLine("миссия станет доступной только после завершения приведущей");
            }
        }

        public class Ivent : BaseQuest
        {
            public DateTime DateEndIvent;

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Дата окончания ивента: {DateEndIvent}");
            }
        }

        public class Quest : BaseQuest
        {

        }

        //контракт фабрик
        public interface IBaseQuestFactory<out T>
            where T : BaseQuest
        {
            T Create();
        }

        public abstract class BaseQuestFactory<T> : IBaseQuestFactory<T>
            where T : BaseQuest
        {
            public abstract T Create();
        }

        //реализация фабрик
        public class MissionFactory : BaseQuestFactory<Mission>
        {
            int index = 0;
            Mission prev;

            public override Mission Create()
            {
                // можно оптимизировать через атрибуты + рефлексия для динамического поиска реализующих наследников
                var mission = index++ == 0
                    ? new FirstMission()
                    : new SecondMission() as Mission;

                if (prev != null)
                    prev.NextMission = mission;

                return prev = mission;
            }

            private class FirstMission : Mission
            {
                public FirstMission()
                {
                    var artifact = new[]
                    {
                    "Чудо щит и палка убивалка",
                    "Чаша поднебесной и кувшин морей",
                    "Некоушки"
                }.GetRandom();

                    Name = "поиск реликвии";
                    Description = $"Для победы над противником вам понадобятся {artifact}. Разыщите их!";
                    Allow = true;
                }
            }

            private class SecondMission : Mission
            {
                public SecondMission()
                {
                    var evil = new[]
                    {
                    "Дракона",
                    "Чародея",
                    "Злую Неко"
                }.GetRandom();

                    Name = "сражение со злом";
                    Description = $"С помощью реликвии найдите и уничтожте {evil}. Да пребудет с вами сила!";
                    Allow = true;
                }
            }
        }

        public class IventFactory : BaseQuestFactory<Ivent>
        {
            List<string> iventNames = new List<string> {
            "Новый год",
            "День защиты детей",
            "Хелоуин",
            "Масленица"
        };

            List<string> tasks = new List<string> {
            "найти пасхалки",
            "20 раз выйти на арену",
            "обменятся очками дружбы в чате",
            "разгадать загадку на форуме",
            "получить подарок от НПС в столице"
        };

            public override Ivent Create()
            {
                var name = iventNames.GetRandom();
                var task = tasks.GetRandom();
                iventNames.Remove(name);
                tasks.Remove(task);
                return new Ivent
                {
                    Name = name,
                    Description = task,
                    DateEndIvent = DateTime.Now.AddDays(RandomHelper.Random(2, 4))
                };
            }
        }

        public class QuestFactory : BaseQuestFactory<Quest>
        {
            string[] locations = new[]
            {
            "в чащу",
            "на озеро",
            "на болото",
            "на кладбище",
            "в пещеру",
            "в шахту",
            "в подземелье"
        };

            string[] enemies = new[]
            {
            "волков",
            "приведений",
            "гулей",
            "василисков",
            "минотавров",
        };

            public override Quest Create()
            {
                var enemy = enemies.GetRandom();

                return new Quest
                {
                    Name = $"Охота на {enemy}",
                    Description = $" Пойдите {locations.GetRandom()} и убейте {RandomHelper.Random(5, 10)} {enemy}"
                };
            }
        }

        //вспомогательный класс для получения случайных значений
        public static class RandomHelper
        {
            static Random random = new Random();

            public static string GetRandom(this IEnumerable<string> source) => source.OrderBy(x => Guid.NewGuid()).First();

            public static int Random(int minValue, int maxValue) => random.Next(minValue, maxValue);
        }
    }
