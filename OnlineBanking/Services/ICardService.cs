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

        //Cheque
        Task<IEnumerable<Cheque>> GetCheques(string CardId);
        Task<Cheque> GetCheque(int ChequeId);
        Task<bool> AddCheque(Cheque NewCheque);
        Task<bool> EditCheque(Cheque EditCheque);
        Task<bool> DeleteCheque(int ChequeId);

        //Cheque Type
        Task<IEnumerable<ChequeType>> GetChequeTypes();
        Task<ChequeType> GetCheque();
        Task<bool> AddChequeType(ChequeType NewChequeType);
        Task<bool> EditChequeType(ChequeType EditChequeType);
        Task<bool> DeleteChequeType(int ChequeTypeId);


        //ServiceCard
        Task<IEnumerable<ServiceCard>> GetServiceCards(string CardId);
        Task<bool> AddServiceCard(ServiceCard NewServiceCard);
        Task<bool> DeleteServiceCard(int ServiceCardId);

        //Service
        Task<IEnumerable<Service>> GetServices();
        Task<Service> GetService(int id);
        Task<bool> AddService(Service NewService);
        Task<bool> EditService(Service EditService);
        Task<bool> DeleteService(int ServiceId);
    }
}
