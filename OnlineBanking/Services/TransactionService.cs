using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;
using OnlineBanking.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace OnlineBanking.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankingContext context;
        public TransactionService(BankingContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Transaction> GetTransaction(int transactionId)
        {
            var transaction = context.Transactions.SingleOrDefault(t => t.TransactionId.Equals(transactionId));
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(string cardId)
        {
            var transactions = context.Transactions.ToList();
            if (!string.IsNullOrEmpty(cardId))
            {
                transactions = transactions.Where(t => t.ReceiverCardId.Equals(cardId) || t.SenderCardId.Equals(cardId)).OrderByDescending(t=>t.Time).ToList();
            }
            return transactions;
        }

        public async Task<bool> TransferMoney(Transaction transaction)
        {
            using (IDbContextTransaction trans = context.Database.BeginTransaction())
            {
                try
                {
                    Card sender = context.Cards.SingleOrDefault(c => c.CardId.Equals(transaction.SenderCardId));
                    Card receiver = context.Cards.SingleOrDefault(c => c.CardId.Equals(transaction.ReceiverCardId));
                    // ------ Update Sender -------//
                    sender.Balance = sender.Balance - transaction.Amount;
                    context.SaveChanges();

                    // ------ Update Receiver ------ //
                    receiver.Balance = receiver.Balance + transaction.Amount;
                    context.SaveChanges();
                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        
    }
}
