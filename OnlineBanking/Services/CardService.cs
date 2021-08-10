using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Services
{
    public class CardService : ICardService
    {
        // ----------------- Card ----------------- //
        public Task<bool> AddCard(Card NewCard)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteCard(string CardId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditCard(Card EditCard)
        {
            throw new NotImplementedException();
        }
        public Task<Card> GetCard(string CardId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetCards(string AccountId)
        {
            throw new NotImplementedException();
        }

        // ----------------- Card Type ----------------- //
        public Task<bool> AddCardType(CardType NewCardType)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteCardType(int TypeId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditCardType(CardType EditCardType)
        {
            throw new NotImplementedException();
        }
        public Task<CardType> GetCardType(int TypeId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<CardType>> GetCardTypes()
        {
            throw new NotImplementedException();
        }

        // ----------------- Cheque ----------------- //
        public Task<bool> AddCheque(Cheque NewCheque)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteCheque(int ChequeId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditCheque(Cheque EditCheque)
        {
            throw new NotImplementedException();
        }
        public Task<Cheque> GetCheque(int ChequeId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Cheque>> GetCheques(string CardId)
        {
            throw new NotImplementedException();
        }

        // ----------------- ChequeType ----------------- //
        public Task<bool> AddChequeType(ChequeType NewChequeType)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteChequeType(int ChequeTypeId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditChequeType(ChequeType EditChequeType)
        {
            throw new NotImplementedException();
        }
        
        public Task<ChequeType> GetChequeType(int ChequeTypeId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ChequeType>> GetChequeTypes()
        {
            throw new NotImplementedException();
        }

        // ----------------- Service ----------------- //
        public Task<bool> AddService(Service NewService)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteService(int ServiceId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditService(Service EditService)
        {
            throw new NotImplementedException();
        }
        
        public Task<Service> GetService(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Service>> GetServices()
        {
            throw new NotImplementedException();
        }

        // ----------------- ServiceCard ----------------- //
        public Task<bool> AddServiceCard(ServiceCard NewServiceCard)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteServiceCard(int ServiceCardId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ServiceCard>> GetServiceCards(string CardId)
        {
            throw new NotImplementedException();
        }

        
    }
}
