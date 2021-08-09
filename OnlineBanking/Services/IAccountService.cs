﻿using System;
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
        Task<bool> AddAccount(Account NewAccount);
        Task<bool> EditAccount(Account EditAccount);
        Task<bool> DeleteAccount(string AccountId);

        //User
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<bool> AddUser(User NewUser);
        Task<bool> EditUser(User EditUser);

        //Feedback
        Task<IEnumerable<Feedback>> GetFeedbacks(string AccountId);
        Task<Feedback> GetFeedback(int FeedbackId);
        Task<bool> AddFeedback(Account NewAccount);
        Task<bool> EditFeedback(Account EditAccount);
    }
}
