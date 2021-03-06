using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OnlineBanking.Models;
using OnlineBanking.Repository;

namespace OnlineBanking.Services
{
    public class ChequeService : IChequeService
    {
        private BankingContext context;
        public ChequeService(BankingContext context)
        {
            this.context = context;
        }

        /* ---------------------------- Cheque ------------------------- */
        public async Task<bool> AddCheque(Cheques NewCheque)
        {
            Cheques cheque = context.Cheques.SingleOrDefault
                (p => p.CardId.Equals(NewCheque.CardId));
            if (cheque ==null)
            {
                context.Cheques.Add(NewCheque);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteCheque(int ChequeId)
        {
            var cheque = context.Cheques.SingleOrDefault
                (c=>c.ChequeId.Equals(ChequeId));
            if (cheque!=null)
            {
                context.Cheques.Remove(cheque);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditCheque(Cheques EditCheque)
        {
            Cheques cheque = context.Cheques.SingleOrDefault
                (p=>p.ChequeId.Equals(EditCheque.ChequeId));
            if (cheque!=null)
            {
                cheque.ChequeId = EditCheque.ChequeId;
                cheque.ChequeTypeId = EditCheque.ChequeTypeId;
                cheque.CardId = EditCheque.CardId;
                if (context.SaveChanges()>0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Cheques> GetCheque(int ChequeId)
        {
            Cheques cheque = context.Cheques.SingleOrDefault
                (p=>p.ChequeId.Equals(ChequeId));
            if (cheque!=null)
            {
                return cheque;
            }
            else
            {
                return null;
            }
        }

        public async Task<Cheques> GetCheques(string CardId)
        {
            Cheques cheque = context.Cheques.SingleOrDefault
                (p=>p.CardId.Equals(CardId));
            if (cheque!=null)
            {
                return cheque;
            }
            else
            {
                return null;
            }
        }

        /* ---------------------------- Cheque type ------------------------- */
        public async Task<bool> AddChequeType(ChequeTypes NewChequeType)
        {
            ChequeTypes cheque = context.ChequeTypes.SingleOrDefault
                (p => p.ChequeName.Equals(NewChequeType.ChequeName));
            if (cheque == null)
            {
                context.ChequeTypes.Add(NewChequeType);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteChequeType(int ChequeTypeId)
        {
            var cheque = context.ChequeTypes.SingleOrDefault
                (p => p.ChequeTypeId.Equals(ChequeTypeId));
            if (cheque != null)
            {
                context.ChequeTypes.Remove(cheque);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditChequeType(ChequeTypes EditChequeType)
        {
            ChequeTypes cheque = context.ChequeTypes.SingleOrDefault
                (p => p.ChequeTypeId.Equals(EditChequeType.ChequeTypeId));
            if (cheque != null)
            {

                cheque.ChequeName = EditChequeType.ChequeName;
                cheque.ChequeTypeId = EditChequeType.ChequeTypeId;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ChequeTypes> GetChequeType(int ChequeTypeId)
        {
            ChequeTypes cheque = context.ChequeTypes.SingleOrDefault
                (p => p.ChequeTypeId.Equals(ChequeTypeId));
            if (cheque != null)
            {
                return cheque;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ChequeTypes>> GetChequeTypes()
        {
            return context.ChequeTypes.ToList();
        }
    }
}
