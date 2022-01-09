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
            return _context.Settlements.Where(s=>s.IsActive==true).ToList();
        }
        public bool DeleteSettlement(int idSettlement)
        {
            Settlement settlementToDelete = _context.Settlements.FirstOrDefault(s => s.IdSettlement == idSettlement);
            try
            {
                if (settlementToDelete.IsActive == true)
                {

                    settlementToDelete.OptionalSettlementToHolidays.Where(s => s.IdSchedulingHolidayNavigation.IsOpen == true).ToList().ForEach(set =>
                    {
                        _context.OptionalSettlementToHolidays.Remove(set);
                        _context.SaveChanges();
                    });
                    settlementToDelete.SettlementHolidays.Where(s=> s.IdSchedulingHolidayNavigation.IsOpen == true).ToList().ForEach(s =>
                    {
                        _context.SettlementHolidays.Remove(s);
                        _context.SaveChanges();
                    });
                }
                settlementToDelete.IsActive = !settlementToDelete.IsActive;

                _context.Update(settlementToDelete);
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
                Settlement settlementExist = _context.Settlements.FirstOrDefault(s=>s.NameSettlement==settlement.NameSettlement);

                if (settlementExist != null)
                {
                    return false;
                }

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
        public bool UpdateSettlement(Settlement settlement)
        {
            try
            {
                _context.Settlements.Update(settlement);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool IsPlaced(int settlement)
        {
            try
            {
                Settlement settlement1 = _context.Settlements.First(s => s.IdSettlement == settlement);
                OptionalSettlementToHoliday two= settlement1.OptionalSettlementToHolidays.FirstOrDefault(s => s.IdSchedulingHolidayNavigation.IsOpen == true);
                if(two != default)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
