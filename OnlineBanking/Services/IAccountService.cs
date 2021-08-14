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
        
        //User
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);

        //Feedback
        Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId);
        Task<Feedback> GetFeedback(int FeedbackId);
    }
}
