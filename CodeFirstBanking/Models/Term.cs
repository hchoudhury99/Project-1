using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstBanking.Models
{
    public class Term
    {
        public int TermId { get; set; }

        [Range(0, 100000)]
        public int AccountBalance { get; set; }

        public int MaturityInYears = 5;

    }
}
