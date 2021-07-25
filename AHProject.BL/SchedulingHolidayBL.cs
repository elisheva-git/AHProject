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
    }
}
