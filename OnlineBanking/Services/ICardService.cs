using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBanking.Models;

namespace OnlineBanking.Services
{
    public interface ICardService
    {
        // Card
        Task<IEnumerable<Card>> GetCards(string AccountId);
        Task<Card> GetCard(string CardId);
        Task<bool> AddCard(Card NewCard);
        Task<bool> EditCard(Card EditCard);
        Task<bool> DeleteCard(string CardId);

        //Card Type
        Task<IEnumerable<CardType>> GetCardTypes();
        Task<CardType> GetCardType(int TypeId);
        Task<bool> AddCardType(CardType NewCardType);
        Task<bool> EditCardType(CardType EditCardType);
        Task<bool> DeleteCardType(int TypeId);

        
    }
}
