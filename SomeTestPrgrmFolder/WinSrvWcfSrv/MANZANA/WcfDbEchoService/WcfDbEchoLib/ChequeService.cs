using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDbEchoLib
{
    //TODO:Общий список задач:
    /*
      Добавить Хост - ок
      Добавить App.Config - ок
      Добавить строки подключений в App.Config - вроде ок
      В Хост добавить инсталлер - ок
      Репозиторий, проверить, разобраться
      Логгирование, опционально через Log4Net

      Фейковая реализация интерфейса репозитория для общения с БД:
      1 метод принимает чек и сохраняет его в App_Data.
      2 метод возвращает N чеков с рандомным ID и номером от 1 до N (остальные поля по-умолчанию).

      Есть возможность указать в конфиге сервиса какую реализацию репозитория использовать.

    */


    public class ChequeService : IChequeServiceContract
    {
        private ChequeRepository _reposytory;
        public ChequeService()
        {
            _reposytory  = new ChequeRepository();
        }      

        public List<Cheque> GetLastCheques(int lastChequeCount)
        {
            return _reposytory.GetLastCheques(lastChequeCount);
        }

        public void SaveCheque(Cheque cheque)
        {
            _reposytory.SaveCheque(cheque);
        }


    }
}
