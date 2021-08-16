using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class SchedulingHolidayBL: ISchedulingHolidayBL
    {
        ISchedulingHolidayDAL _ISchedulingHolidayDAL;
        IMapper _mapper;
        public SchedulingHolidayBL(ISchedulingHolidayDAL _ISchedulingHolidayDAL, IMapper mapper)
        {
            this._ISchedulingHolidayDAL = _ISchedulingHolidayDAL;
            this._mapper = mapper;
        }

        public bool AddSchedulingHoliday(SchedulingHolidayDTO schedulingHoliday)
        {
            try
            {
                SchedulingHoliday newSchedulingHoliday = _mapper.Map<SchedulingHolidayDTO, SchedulingHoliday>(schedulingHoliday);
                return _ISchedulingHolidayDAL.AddSchedulingHoliday(newSchedulingHoliday);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<SchedulingHolidayDTO> GetSchedulingHolidays()
        {
            List<SchedulingHoliday> schedulingHolidays = _ISchedulingHolidayDAL.GetSchedulingHolidays();
            return _mapper.Map<List<SchedulingHoliday>, List<SchedulingHolidayDTO>>(schedulingHolidays);
        }
        public bool DeleteSchedulingHoliday(int idSchedulingHoliday)
        {
            try
            {
                return _ISchedulingHolidayDAL.DeleteSchedulingHoliday(idSchedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SchedulingHolidayDTO GetSchedulingHolidayById(int idSchedulingHoliday)
        {
            try
            {
                SchedulingHoliday schedulingHoliday = _ISchedulingHolidayDAL.GetSchedulingHolidayById(idSchedulingHoliday);
                return _mapper.Map<SchedulingHoliday, SchedulingHolidayDTO>(schedulingHoliday);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
