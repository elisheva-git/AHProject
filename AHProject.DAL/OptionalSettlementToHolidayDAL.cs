using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AHProject.DAL
{
    public class OptionalSettlementToHolidayDAL: IOptionalSettlementToHolidayDAL
    {
        AHDBContext _context;
        public OptionalSettlementToHolidayDAL(AHDBContext context)
        {
            this._context = context;
        }
        public void addSettlements(int idSchedulingHoliday)
        {
            foreach (var settlement in _context.Settlements)
            {
                OptionalSettlementToHoliday optionalSettlement = new OptionalSettlementToHoliday();
                optionalSettlement.IdSettlement = settlement.IdSettlement;
                optionalSettlement.IdSchedulingHoliday = idSchedulingHoliday;
                _context.OptionalSettlementToHolidays.Add(optionalSettlement);
            };
            _context.SaveChanges();
        }
        public void removeSettlements(int idSchedulingHoliday)
        {
            try
            {
                foreach (var settlemnt in _context.OptionalSettlementToHolidays.Where(s => s.IdSchedulingHoliday == idSchedulingHoliday))
                {
                    _context.OptionalSettlementToHolidays.Remove(settlemnt);
                };
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<OptionalSettlementToHoliday> getOptionalSettlementByHoliday(int idSchedulingHoliday)
        {
            try
            {
                return _context.OptionalSettlementToHolidays.Where(opv => opv.IdSchedulingHoliday == idSchedulingHoliday).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ChangeOptional(OptionalSettlementToHoliday optionalSettlementToHoliday, int newExperience)
        {
            try
            {
                OptionalSettlementToHoliday optional = _context.OptionalSettlementToHolidays.FirstOrDefault(o => o.IdSettlement == optionalSettlementToHoliday.IdSettlement && o.IdSchedulingHoliday == optionalSettlementToHoliday.IdSchedulingHoliday);
                optional.IdExperience = newExperience;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
