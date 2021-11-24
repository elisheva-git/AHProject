using AHProject.DAL;
using AHProject.DAL.Models;
using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public class PrayerTextBL: IPrayerTextBL
    {
        IPrayerTextDAL _IPrayerTextDAL;
        IMapper _mapper;
        public PrayerTextBL(IPrayerTextDAL iPrayerTextDAL, IMapper mapper)
        {
            this._IPrayerTextDAL = iPrayerTextDAL;
            this._mapper = mapper;
        }
        public List<PrayerTextDTO> GetPrayerTexts()
        {
            try
            {
                List<PrayerText> prayerTexts = _IPrayerTextDAL.GetPrayerTexts();
                return _mapper.Map<List<PrayerText>, List<PrayerTextDTO>>(prayerTexts);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddPrayerText(PrayerTextDTO prayer)
        {
            try
            {
                PrayerText prayerText = _mapper.Map<PrayerTextDTO, PrayerText>(prayer);
                _IPrayerTextDAL.AddPrayerText(prayerText);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
