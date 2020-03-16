﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedLib
{
    interface IChequeReposytory
    {
        void SaveCheque(Cheque cheque);
        List<Cheque> GetLastCheques(int lastChequeCount);
    }
}