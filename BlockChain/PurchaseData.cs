using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class PurchaseData
    {
        string _from;
        int _amount;
        DateTime _date_time;
        string _to = "E-Bid Auction Hull, UK";

        public string From { get => _from; set => _from = value; }
        public string To { get => _to; set => _to = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public DateTime DateTime { get => _date_time; set => _date_time = value; }
    }
}
