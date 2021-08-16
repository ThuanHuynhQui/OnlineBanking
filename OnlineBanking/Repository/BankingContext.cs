using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;

namespace OnlineBanking.Repository
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Cheques> Cheques { get; set; }
        public DbSet<ChequeTypes> ChequeTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCard> ServiceCards { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
