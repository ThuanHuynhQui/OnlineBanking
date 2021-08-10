using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Repository;
using Microsoft.EntityFrameworkCore;

namespace OnlineBanking.Services
{
    public class AccountService : IAccountService
    {
        private BankingContext context;
        public AccountService(BankingContext context)
        {
            this.context = context;
        }
        // -------------------- Account --------------------//
        public async Task<bool> AddAccount(Account NewAccount)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(NewAccount.AccountId));
            if(account == null)
            {
                context.Accounts.Add(NewAccount);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteAccount(string AccountId)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(AccountId));
            if (account != null)
            {
                context.Accounts.Remove(account);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EditAccount(Account EditAccount)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(EditAccount.AccountId));
            if (account != null)
            {
                account.Password = EditAccount.Password;
                account.Role = EditAccount.Role;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Account> GetAccount(string AccountId)
        {
            Account account = await context.Accounts.SingleOrDefaultAsync(a => a.AccountId.Equals(AccountId));
            return account;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await context.Accounts.ToListAsync();
        }

        // ----------------- Feedback -------------------- //
        public Task<bool> AddFeedback(Feedback NewFeedback)
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
        public Task<bool> EditFeedback(Feedback EditFeedback)
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
