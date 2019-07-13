using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstBanking.Models
{
    public class LoanTrans
    {
        public int LoanTransId { get; set; }
        public int LoanId { get; set; }
        public DateTime Time { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
    }
}
