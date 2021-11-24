using DTO;
using System.Collections.Generic;

namespace AHProject.BL
{
    public interface IPrayerTextBL
    {
        public List<PrayerTextDTO> GetPrayerTexts();
        public void AddPrayerText(PrayerTextDTO prayer);
    }
}