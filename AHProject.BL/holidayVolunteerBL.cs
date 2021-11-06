using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.BL
{
    public class HolidayVolunteerBL: IHolidayVolunteerBL
    {
        IHolidayVolunteerDAL _IHolidayVolunteerDAL;
        IProfessionalToVolunteerDAL _IprofessionalToVolunteer;
        IMapper _mapper;
        ISettlementHolidayDAL _ISettlementHolidayDAL;
        public HolidayVolunteerBL(IHolidayVolunteerDAL IHolidayVolunteerDAL, IMapper mapper, IProfessionalToVolunteerDAL iprofessionalToVolunteer, ISettlementHolidayDAL iSettlementHolidayDAL)
        {
            this._IHolidayVolunteerDAL = IHolidayVolunteerDAL;
            this._mapper = mapper;
            _IprofessionalToVolunteer = iprofessionalToVolunteer;
            this._ISettlementHolidayDAL = iSettlementHolidayDAL;
        }
        public bool AddHolidayVolunteer(HolidayVolunteerDTO volunteerHoliday)
        {
            try
            {
                HolidayVolunteer holidayVolunteer = _mapper.Map<HolidayVolunteerDTO, HolidayVolunteer>(volunteerHoliday);
               // List<Professional> professionals=_mapper.Map<List<ProfessionalDTO>,List< Professional >> (volunteerHoliday.Professionals);
              //  _IprofessionalToVolunteer.AddProfessionalsToVolunteer(professionals, volunteerHoliday.IdSchedulingHoliday, volunteerHoliday.IdVolunteer);
                return _IHolidayVolunteerDAL.AddHolidayVolunteer(holidayVolunteer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteHolidayVolunteer(int idVolunteer, int idSchedulingHoliday)
        {
            try
            {
                return _IHolidayVolunteerDAL.DeleteHolidayVolunteer(idVolunteer,idSchedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<HolidayVolunteerDTO> GetVolunteersBySchedulingHoliday(int schedulingHoliday)
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers = _IHolidayVolunteerDAL.GetVolunteersBySchedulingHoliday(schedulingHoliday);
                return _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(holidayVolunteers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HolidayVolunteerDTO> GetVolunteersBySettlement(int settlementId, int schedulingId)
        {
            try
            {
                List<HolidayVolunteer> volunteers = _IHolidayVolunteerDAL.GetVolunteersFromHistory(settlementId, schedulingId);
                return _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(volunteers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void saveVolunteerToSettlement(HolidayVolunteerDTO holidayVolunteer, int settlement)
        {
            try
            {
                HolidayVolunteer volunteer = _mapper.Map<HolidayVolunteerDTO, HolidayVolunteer>(holidayVolunteer);
                _IHolidayVolunteerDAL.saveVolunteerToSettlement(volunteer, settlement);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<List<HolidayVolunteerDTO>> GetVolunteersToScheduling(int settlementId, int schedulingId)
        {
            try
            {
                //volunteers that they were in the settlement in the history
                List<HolidayVolunteer> volunteersFromHistory = _IHolidayVolunteerDAL.GetVolunteersFromHistory(settlementId, schedulingId);
                //volunteers that they were not in the settlement in the history
                List<HolidayVolunteer> holidayVolunteers = _IHolidayVolunteerDAL.GetVolunteersBySchedulingHoliday(schedulingId);
                //volunteers that already choosen to this settlement to this scheduling
                List<HolidayVolunteer> volunteersAlreadyToThisSettlements = _IHolidayVolunteerDAL.GetVolunteersToSettlements(schedulingId,settlementId);
                //volunteers that already choosen to diffrent settlement to this scheduling
                List<HolidayVolunteer> busyVolunteers = _IHolidayVolunteerDAL.GetBusyVolunteers(schedulingId,settlementId);
                SettlementHoliday settlementHoliday = _ISettlementHolidayDAL.GetSettlementHoliday(schedulingId, settlementId);
                VolunteerCompare volunteerCompare = new VolunteerCompare(settlementHoliday);
                List<HolidayVolunteer> sortVolunteers = holidayVolunteers.Where(hv => !volunteersFromHistory.Contains(hv)).ToList();
                //sort the list by priority of criterions
                volunteersFromHistory.Sort(volunteerCompare);
                sortVolunteers.Sort(volunteerCompare);
                return new List<List<HolidayVolunteerDTO>> {
                 _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(volunteersFromHistory),
                 _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(sortVolunteers),
                 _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(volunteersAlreadyToThisSettlements),
                 _mapper.Map<List<HolidayVolunteer>, List<HolidayVolunteerDTO>>(busyVolunteers)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
