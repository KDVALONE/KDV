using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringFolderSevice.Models
{

    //TODO: может отказаться вообще от этой штуки, в пользу на модель их WCF службы, а то конфликтуют
    public class Cheque
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Summ { get; set; }
        public decimal Discount { get; set; }
        public string[] Articles { get; set; }
    }
}
