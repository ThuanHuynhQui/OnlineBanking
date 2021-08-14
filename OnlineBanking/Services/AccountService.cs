using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Services
{
    public class AccountService : IAccountService
    {
        private Repository.BankingContext context;
        public AccountService(Repository.BankingContext context)
        {
            this.context = context;
        }
        public Task<Account> GetAccount(string AccountId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return context.Accounts.ToList();
        }

        public Task<Feedback> GetFeedback(int FeedbackId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
