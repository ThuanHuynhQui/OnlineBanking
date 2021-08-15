using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;

namespace OnlineBanking.Services
{
    public interface ITransactionService
    {
        Task<bool> TransferMoney(Transaction transaction);
        Task<bool> AddTransaction(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactions(string cardId);
        Task<Transaction> GetTransaction(int transactionId);
    }
}
