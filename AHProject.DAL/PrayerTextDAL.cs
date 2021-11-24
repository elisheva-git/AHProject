using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHProject.DAL
{
    public class PrayerTextDAL: IPrayerTextDAL
    {
        AHDBContext _context;
        public PrayerTextDAL(AHDBContext context)
        {
            this._context = context;
        }
        public List<PrayerText> GetPrayerTexts()
        {
            try
            {
                return _context.PrayerTexts.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddPrayerText(PrayerText prayer)
        {
            try
            {
                _context.PrayerTexts.Add(prayer);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
