using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Services
{
    public class CardService : ICardService
    {
        private Repository.BankingContext context;
        public CardService(Repository.BankingContext context)
        {
            this.context = context;
        }
        // ----------------- Card ----------------- //
        public async Task<bool> AddCard(Card NewCard)
        {
            var checkID = context.Cards.SingleOrDefault(o => o.CardId.Equals(NewCard.CardId));
            if (checkID == null)
            {
                NewCard.OpenDate = DateTime.Now.ToString();
                context.Cards.Add(NewCard);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteCard(string CardId)
        {
            var findID = context.Cards.SingleOrDefault(o=>o.CardId.Equals(CardId));
            if (findID != null)
            {
                context.Cards.Remove(findID);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EditCard(Card EditCard)
        {
            var findToEdit = context.Cards.SingleOrDefault(o => o.CardId.Equals(EditCard.CardId));
            if (findToEdit != null)
            {
                findToEdit.Pin = EditCard.Pin;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Card> GetCard(string CardId)
        {
            var findOne = context.Cards.SingleOrDefault(c=>c.CardId.Equals(CardId));
            return findOne;
        }

        public async Task<IEnumerable<Card>> GetCards(string AccountId)
        {
            var list = context.Cards.ToList();
            if (string.IsNullOrEmpty(AccountId) == false)
            {
                list = list.Where(o => o.AccountId.Equals(AccountId)).ToList();
            }
            return list;
        }

        // ----------------- Card Type ----------------- //
        public async Task<bool> AddCardType(CardType NewCardType)
        {
            var checkID = context.CardTypes.SingleOrDefault(o => o.TypeId.Equals(NewCardType.TypeId));
            if (checkID == null)
            {
                context.CardTypes.Add(NewCardType);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteCardType(int TypeId)
        {
            var findID = context.CardTypes.Find(TypeId);
            if (findID != null)
            {
                context.CardTypes.Remove(findID);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EditCardType(CardType EditCardType)
        {
            var findToEdit = context.CardTypes.SingleOrDefault(o => o.TypeId.Equals(EditCardType.TypeId));
            if (findToEdit != null)
            {
                findToEdit.TypeName = EditCardType.TypeName;
                findToEdit.Fee = EditCardType.Fee;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<CardType> GetCardType(int TypeId)
        {
            var findOne = context.CardTypes.Find(TypeId);
            return findOne;
        }
        public async Task<IEnumerable<CardType>> GetCardTypes()
        {
            return context.CardTypes.ToList();
        }

        
        
    }
}
