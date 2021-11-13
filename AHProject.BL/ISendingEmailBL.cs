using System;
using System.Collections.Generic;
using System.Text;

namespace AHProject.BL
{
    public interface ISendingEmailBL
    {
        public void sendToContactPersonOfSettlements(int schedulingHoliday);
        public void sendToVolunteers(int schedulingHoliday);
    }
}
