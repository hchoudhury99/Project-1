using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstBanking.Models
{
    public class Checking
    {
        public int CheckingId { get; set; }

        public double Interest = 10.45;

        [Range (0,100000)]
        public int AccountBalance { get; set; }

        public int businessId;
    }

}
