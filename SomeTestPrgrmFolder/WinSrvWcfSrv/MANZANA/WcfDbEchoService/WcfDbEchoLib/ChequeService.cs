using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using WcfDbEchoLib.Logger;

namespace WcfDbEchoLib
{
    public class ChequeService : IChequeServiceContract
    {
        private IChequeRepository _reposytory;
        public ChequeService()
        {
            //MyLogger.Log.Info($"Use ChequeRepository ");
            //_reposytory  = new ChequeRepository();
            MyLogger.Log.Info($"Use FakeChequeRepository ");
            _reposytory = new FakeChequeRepository();
        }      

        public List<Cheque> GetLastCheques(int lastChequeCount)
        {
            try
            {
                MyLogger.Log.Info($"Getting cheques pack");
                return _reposytory.GetLastCheques(lastChequeCount);  
            }
            catch (Exception ex) { MyLogger.Log.Error($"Cant getting Cheques from repository {ex}"); return null; }
        }

        public void SaveCheque(Cheque cheque)
        {
            try
            {
                MyLogger.Log.Info($"Saving cheques");
                _reposytory.SaveCheque(cheque);
            }
            catch (Exception ex) { MyLogger.Log.Error($"Cant saved Cheques to repository {ex}"); }
        }


    }
}
