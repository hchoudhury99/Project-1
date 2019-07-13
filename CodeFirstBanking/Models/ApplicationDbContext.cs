using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CodeFirstBanking.Models;

namespace CodeFirstBanking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CodeFirstBanking.Models.Business> Business { get; set; }
        public DbSet<CodeFirstBanking.Models.Checking> Checking { get; set; }
        public DbSet<CodeFirstBanking.Models.Loan> Loan { get; set; }
        public DbSet<CodeFirstBanking.Models.Term> Term { get; set; }
        public DbSet<CodeFirstBanking.Models.BusinessTrans> BusinessTrans { get; set; }
        public DbSet<CodeFirstBanking.Models.CheckingTrans> CheckingTrans { get; set; }
        public DbSet<CodeFirstBanking.Models.LoanTrans> LoanTrans { get; set; }
        public DbSet<CodeFirstBanking.Models.TermTrans> TermTrans { get; set; }
    }
}
