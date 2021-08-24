using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text;

namespace OnlineBanking.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankingContext context;
        public AccountService(BankingContext context)
        {
            this.context = context;
        }
        // -------------------- Account --------------------//
        public async Task<bool> AddAccount(UserAccount NewUserAccount)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // -------- Add User --------//
                    User newUser = new User
                    {
                        FullName = NewUserAccount.FullName,
                        Address = NewUserAccount.Address,
                        Gender = NewUserAccount.Gender,
                        DoB = NewUserAccount.DoB,
                        IdentityId = NewUserAccount.IdentityId,
                        Email = NewUserAccount.Email,
                        Phone = NewUserAccount.Phone,
                        Avatar = NewUserAccount.Avatar
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    // -------- Add Account --------//
                    Account NewAccount = new Account
                    {
                        AccountId = NewUserAccount.AccountId,
                        UserId = newUser.UserId,
                        Password = NewUserAccount.Password,
                        OpenDate = DateTime.Now.ToShortDateString(),
                        Role = false,
                        Active = NewUserAccount.Active
                    };
                    context.Accounts.Add(NewAccount);
                    context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
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
                account.Active = EditAccount.Active;
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
        public async Task<Account> GetAccountByEmail(string Email)
        {
            UserAccount userAccount = context.UserAccounts.SingleOrDefault(ua => ua.Email.Equals(Email));
            Account account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(userAccount.AccountId));
            return account;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await context.Accounts.ToListAsync();
        }

        public async Task<bool> CheckLoginAdmin(string AccountId, string password)
        {
            var result = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(AccountId) && a.Password.Equals(password));
            if (result != null)
            {
                if (result.Role)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> CheckLoginCustomer(string AccountId, string password)
        {
            var result = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(AccountId));
            if (result != null)
            {
                if (result.Active)
                {
                    if (result.Password.Equals(password))
                    {
                        result.AccessFailedCount = 0;
                        context.SaveChanges();
                        return "true";
                    }
                    else
                    {
                        if (result.AccessFailedCount < 3)
                        {
                            result.AccessFailedCount++;
                            context.SaveChanges();
                            return "Invalid password. Please try again...";
                        }
                        else
                        {
                            if (result.AccessFailedCount >= 3 && result.AccessFailedCount <=5)
                            {
                                result.AccessFailedCount++;
                                context.SaveChanges();
                                return "Wrong password. Warning: If you enter the wrong password too many times, your account will be locked. Please use the Forgot Password function if you need it.";
                            }
                            else
                            {
                                result.Active = false;
                                context.SaveChanges();
                                return "Your account has been locked because you entered the wrong password multiple times. Please contact with the staff at the bank to unlock account.";
                            }
                        }
                    }
                }
                else
                {
                    return "Your account has been locked because you entered the wrong password multiple times. Please contact with the staff at the bank to unlock account.";
                }
            }
            return "Invalid Credentials";
        }

        public async Task<bool> CheckEmail(string email)
        {
            var result = context.Users.SingleOrDefault(u => u.Email.Equals(email));
            if (result != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CheckIdentityId(string identityId)
        {
            var result = context.Users.SingleOrDefault(u => u.IdentityId.Equals(identityId));
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckAccountId(string accountId)
        {
            var result = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(accountId));
            if (result != null)
            {
                return true;
            }
            return false;
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
            var feedbacks = context.Feedbacks.OrderBy(f => f.Created_at).ToList();
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
                feedback.Status = true;
                feedback.Reply = EditFeedback.Reply;
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
        public async Task<bool> EditUserAccount(UserAccount userAccount)
        {
            // -------- Edit User --------//
            User editUser = context.Users.SingleOrDefault(u => u.UserId.Equals(userAccount.UserId));
            if(editUser != null)
            {
                editUser.IdentityId = userAccount.IdentityId;
                editUser.Email = userAccount.Email;
                context.SaveChanges();
            };

            // -------- Edit Account --------//
            Account editAccount = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(userAccount.AccountId));
            if(editAccount != null)
            {
                editAccount.Password = userAccount.Password;
                context.SaveChanges();
            };
            return true;
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

        public async Task<UserAccount> GetUserAccount(string AccountId)
        {
            var userAccount = await context.UserAccounts.SingleOrDefaultAsync(u=>u.AccountId.Equals(AccountId));
            return userAccount;
        }
    }
}
