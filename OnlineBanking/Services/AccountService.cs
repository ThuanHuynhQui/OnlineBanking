using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Services
{
    public class AccountService : IAccountService
    {
        // -------------------- Account --------------------//
        public Task<bool> AddAccount(Account NewAccount)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAccount(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditAccount(Account EditAccount)
        {
            throw new NotImplementedException();
        }
        public Task<Account> GetAccount(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        // ----------------- Feedback -------------------- //
        public Task<bool> AddFeedback(Account NewAccount)
        {
            throw new NotImplementedException();
        }
        public Task<Feedback> GetFeedback(int FeedbackId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditFeedback(Account EditAccount)
        {
            throw new NotImplementedException();
        }

        // --------------------- User -------------------- //
        public Task<bool> EditUser(User EditUser)
        {
            throw new NotImplementedException();
        }
        public Task<bool> AddUser(User NewUser)
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
