using AHProject.DAL.Models;
using System.Collections.Generic;

namespace AHProject.DAL
{
    public interface IPrayerTextDAL
    {
        public List<PrayerText> GetPrayerTexts();
        public void AddPrayerText(PrayerText prayer);
    }
}