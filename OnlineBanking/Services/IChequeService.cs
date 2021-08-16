using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OnlineBanking.Models;
namespace OnlineBanking.Services
{
    public interface IChequeService
    {
        /* --------------------- Cheque ---------------------- */
        Task<Cheque> GetCheques(string CardId);
        Task<Cheque> GetCheque(int ChequeId);
        Task<bool> AddCheque(Cheque NewCheque);
        Task<bool> EditCheque(Cheque EditCheque);
        Task<bool> DeleteCheque(int ChequeId);

        /* --------------------- Cheque Type ---------------------- */
        Task<IEnumerable<ChequeType>> GetChequeTypes();
        Task<ChequeType> GetChequeType(int ChequeTypeId);
        Task<bool> AddChequeType(ChequeType NewChequeType);
        Task<bool> EditChequeType(ChequeType EditChequeType);
        Task<bool> DeleteChequeType(int ChequeTypeId);
    }
}
