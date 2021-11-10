using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class HolidayVolunteerDAL: IHolidayVolunteerDAL
    {
        AHDBContext _context;
        public HolidayVolunteerDAL(AHDBContext context)
        {
            this._context = context;
        }

        public bool AddHolidayVolunteer(HolidayVolunteer volunteerHoliday)
        {
            try
            {
                HolidayVolunteer volunteerExist = null;
                volunteerExist = _context.HolidayVolunteers.FirstOrDefault(v => v.IdVolunteer==volunteerHoliday.IdVolunteer&&v.IdSchedulingHoliday==volunteerHoliday.IdSchedulingHoliday);
                if (volunteerExist != null)
                {
                    return false;
                }
                _context.HolidayVolunteers.Add(volunteerHoliday);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday)
        {
            try
            {
                HolidayVolunteer holidayVolunteer = _context.HolidayVolunteers.FirstOrDefault(hv => hv.IdSchedulingHoliday == idSchedulingHoliday && hv.IdVolunteer == idVolunteer);
                _context.HolidayVolunteers.Remove(holidayVolunteer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<HolidayVolunteer> GetVolunteersBySchedulingHoliday(int schedulingHoliday,bool isBusy=false)
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers= _context.HolidayVolunteers.Where(s => s.IdSchedulingHoliday == schedulingHoliday).ToList();
                if (isBusy)
                {
                    return holidayVolunteers.Where(hv => hv.IdSettlement != null).ToList();
                }
                return holidayVolunteers;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<HolidayVolunteer> GetVolunteersFromHistory(int settlementId,int schedulingId)
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers=  _context.HolidayVolunteers.Where(hv => hv.IdSchedulingHoliday == schedulingId).ToList();
                List<HolidayVolunteer> volunteersBySettlement= _context.HolidayVolunteers.Where(s => s.IdSettlement == settlementId && s.IdSchedulingHoliday!=schedulingId).ToList(); ;
                return holidayVolunteers.Where(hv => volunteersBySettlement.FirstOrDefault(v => v.IdVolunteer == hv.IdVolunteer) != default).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void saveVolunteerToSettlement(HolidayVolunteer holidayVolunteer,int settlement)
        {
            try
            {
               HolidayVolunteer holidayVolunteer1=  _context.HolidayVolunteers.First(hv=>hv.IdSchedulingHoliday==holidayVolunteer.IdSchedulingHoliday&&hv.IdVolunteer==holidayVolunteer.IdVolunteer);
                holidayVolunteer1.IdSettlement = settlement;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<HolidayVolunteer> GetBusyVolunteers(int schedulingId, int settlement)
        {
            try
            {
                return _context.HolidayVolunteers.Where(hv => hv.IdSchedulingHoliday == schedulingId && hv.IdSettlement != null && hv.IdSettlement != settlement).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HolidayVolunteer> GetVolunteersToSettlements(int schedulingId, int settlement)
        {
            try
            {
                return _context.HolidayVolunteers.Where(hv => hv.IdSchedulingHoliday == schedulingId &&  hv.IdSettlement == settlement).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HolidayVolunteer> GetHolidayVolunteers()
        {
            try
            {
                return _context.HolidayVolunteers.Where(hv=>hv.IdSettlement!=null).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
