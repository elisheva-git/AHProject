using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class SettlementDAL: ISettlementDAL
    {
        AHDBContext _context;
        public SettlementDAL(AHDBContext context)
        {
            this._context = context;
        }

        public List<Settlement> GetSettlements()
        {
            return _context.Settlements.ToList();
        }
        public bool DeleteSettlement(int idSettlement)
        {
            Settlement SettlementToDelete = _context.Settlements.FirstOrDefault(s => s.IdSettlement == idSettlement);
            try
            {
                _context.Remove(SettlementToDelete);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool AddSettlement(Settlement settlement)
        {
            try
            {
                //איך לבדוק האם הישוב קיים כבר
                //Settlement settlementExist = null;
            
                //if (settlementExist != null)
                //{
                //    return false;
                //}
              
                _context.Settlements.Add(settlement);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Settlement GetSettlementById(int id)
        {
            Settlement settlement = _context.Settlements.FirstOrDefault(s => id == s.IdSettlement);
            return settlement;
        }

    }
}
