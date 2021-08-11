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
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> DeleteAccount(string AccountId)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(AccountId));
            if (account != null)
            {
                context.Accounts.Remove(account);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> EditAccount(Account EditAccount)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(EditAccount.AccountId));
            if (account != null)
            {
                account.Password = EditAccount.Password;
                account.Role = EditAccount.Role;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<Account> GetAccount(string AccountId)
        {
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(AccountId));
            return account;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return context.Accounts.ToList();
        }

        // ----------------- Feedback -------------------- //
        public async Task<bool> AddFeedback(Feedback NewFeedback)
        {
            context.Feedbacks.Add(NewFeedback);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<Feedback> GetFeedback(int FeedbackId)
        {
            Feedback feedback = context.Feedbacks.SingleOrDefault(f => f.FeedbackId.Equals(FeedbackId));
            return feedback;
        }
        public async Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId)
        {
            var feedbacks = context.Feedbacks.ToList();
            if (string.IsNullOrEmpty(AccountId) == false)
            {
                feedbacks = feedbacks.Where(f => f.AccountId.Equals(AccountId)).ToList();
            }
            return feedbacks;
        }
        public async Task<bool> EditFeedback(Feedback EditFeedback)
        {
            Feedback feedback = context.Feedbacks.SingleOrDefault(f => f.FeedbackId.Equals(EditFeedback.FeedbackId));
            if(feedback != null)
            {
                feedback.Status = EditFeedback.Status;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // --------------------- User -------------------- //
        public async Task<bool> EditUser(User EditUser)
        {
            User user = context.Users.SingleOrDefault(u => u.UserId.Equals(EditUser.UserId));
            if (user != null)
            {
                user.Address = EditUser.Address;
                user.DoB = EditUser.DoB;
                user.Email = EditUser.Email;
                user.Phone = EditUser.Phone;
                user.Avatar = EditUser.Avatar;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> AddUser(User NewUser)
        {
            User user = context.Users.SingleOrDefault(u => u.IdentityId.Equals(NewUser.IdentityId));
            if(user == null)
            {
                context.Users.Add(NewUser);
                if(context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<User> GetUser(int UserId)
        {
            User user = context.Users.SingleOrDefault(u => u.UserId.Equals(UserId));
            return user;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
