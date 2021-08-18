using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;

namespace OnlineBanking.Services
{
    public interface IAccountService
    {
        //Account
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(string AccountId);
        Task<bool> AddAccount(UserAccount NewUserAccount);
        Task<bool> EditAccount(Account EditAccount);
        Task<bool> DeleteAccount(string AccountId);
        Task<bool> CheckLogin(string AccountId, string password);

        //User
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<bool> AddUser(User NewUser);
        Task<bool> EditUser(User EditUser);
        Task<UserAccount> GetUserAccount(string AccountId);

        //Feedback
        Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId);
        Task<Feedback> GetFeedback(int FeedbackId);
        Task<bool> AddFeedback(Feedback NewFeedback);
        Task<bool> EditFeedback(Feedback EditFeedback);
    }
}
