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
        Task<Cheques> GetCheques(string CardId);
        Task<Cheques> GetCheque(int ChequeId);
        Task<bool> AddCheque(Cheques NewCheque);
        Task<bool> EditCheque(Cheques EditCheque);
        Task<bool> DeleteCheque(int ChequeId);

        /* --------------------- Cheque Type ---------------------- */
        Task<IEnumerable<ChequeTypes>> GetChequeTypes();
        Task<ChequeTypes> GetChequeType(int ChequeTypeId);
        Task<bool> AddChequeType(ChequeTypes NewChequeType);
        Task<bool> EditChequeType(ChequeTypes EditChequeType);
        Task<bool> DeleteChequeType(int ChequeTypeId);
    }
}
