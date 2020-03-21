﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDbEchoLib.Logger;

namespace WcfDbEchoLib
{
    class FakeChequeRepository : IChequeRepository
    {
        private List<Cheque> _cheques;
        public FakeChequeRepository()
        {
            MyLogger.Log.Info($"Initialzie Fake repositroy");
            _cheques = InitializeChequesCollection();
        }
        //TODO: Переименовать lastChequeCount chequeCount, 
        // а метод GetLastCheques() в GetChequePack()
        //не забыть,
        //после всего этого пересобрать WatcherService c новой ссылкой на этот роект
        //метод возвращает коллекцию из N уникальных случайных чеков 
        public List<Cheque> GetLastCheques(int lastChequeCount)
        {

            MyLogger.Log.Info($"Getting cheques Pack");
            if (lastChequeCount <= 0) { MyLogger.Log.Error($"Getting cheques pack count  <= 0");  return null; };

            List<Cheque> cequesPack = new List<Cheque>(); 
            Random rnd = new Random();
            int count = 0;
                      
            count = _cheques.Count <= lastChequeCount ? _cheques.Count : lastChequeCount;           

            int[] currentNumbers = Enumerable.Range(0, count-1).OrderBy(i => rnd.Next()).ToArray();

            foreach (var e in currentNumbers)
            {
                cequesPack.Add(_cheques[e]) ;
            }

            return cequesPack;

        }

        public void SaveCheque(Cheque cheque)
        {

            MyLogger.Log.Info($"Saving cheque");
            try { _cheques.Add(cheque); } catch (Exception ex)
            {
                MyLogger.Log.Error($"Getting cant save cheque to Fake Repository {ex}");
            }
            
        }

        private List<Cheque> InitializeChequesCollection()
        {
            MyLogger.Log.Info($"Initialize cheques collection in FakeReposotory ");

            List<Cheque> cheques = new List<Cheque>() {
            new Cheque {Id = Guid.NewGuid(), Number = "100" ,Summ = 2.5M ,Discount = 12M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"}},
            new Cheque {Id = Guid.NewGuid(), Number = "101" ,Summ = 14.5M ,Discount = 2M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"}},
            new Cheque {Id = Guid.NewGuid(), Number = "102" ,Summ = 2M ,Discount = 1.2M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"}},
            new Cheque {Id = Guid.NewGuid(), Number = "103" ,Summ = 12.5M ,Discount = 24.1M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"}},
            new Cheque {Id = Guid.NewGuid(), Number = "104" ,Summ = 4.35M ,Discount = 12.0M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"}},
            new Cheque {Id = Guid.NewGuid(), Number = "105" ,Summ = 1.13M ,Discount = 0.12M , Articles  = new string[3]{ "Article_1","Article_2","Article_3"} }
            };
            return cheques;
        }
    }
}
