using AHProject.DAL;
using AHProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AHProject.BL
{
    public class SendingEmailBL:ISendingEmailBL
    {
        MailMessage mail;
        SmtpClient smtp;
        ISchedulingHolidayDAL _ISchedulingHolidayDAL;
        public SendingEmailBL(ISchedulingHolidayDAL ISchedulingHolidayDAL)
        {
            _ISchedulingHolidayDAL = ISchedulingHolidayDAL;
            smtp = new SmtpClient();
            //הגדרת השרת של גוגל
            smtp.Host = "smtp.gmail.com";
            //הגדרת פרטי הכניסה לחשבון גימייל
            smtp.Credentials = new System.Net.NetworkCredential(
            "ah.holidayactivities@gmail.com", "ah123456789");
            //אפשור SSL (חובה(
            smtp.EnableSsl = true;
        }
        public void sendToVolunteers(int schedulingHoliday)
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers = _ISchedulingHolidayDAL.GetVolunteers(schedulingHoliday);
                holidayVolunteers.ForEach(hv =>
                    {
                        mail = new MailMessage();
                        mail.To.Add(hv.IdVolunteerNavigation.Gmail);
                        //the sendder address
                        mail.From = new MailAddress("ah.holidayactivities@gmail.com");
                        // subject message
                        mail.Subject = "שיבוץ לחג";
                        //content of the message
                        string body = hv.IdVolunteerNavigation.FirstName+" "+hv.IdVolunteerNavigation.LastName
                        +" -  שלום וברכה"+""+
                        "הנך משובץ לישוב "+hv.IdS.IdSettlementNavigation.NameSettlement+" לחג "+
                        hv.IdSchedulingHolidayNavigation.IdHolidayNavigation.DescriptionHoliday+" תודה רבה וחג שמח  "+" - "+
                        "להערות בקשות ופרטים נוספים ניתן להשיב למייל זה ";
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        try
                        {
                            //שליחת ההודעה
                            smtp.Send(mail);
                        }
                        catch (Exception ex)
                        {
                            //תפיסה וטיפול בשגיאות
                            //txtMessage.Text = ex.ToString();
                        }
                    });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void sendToContactPersonOfSettlements(int schedulingHoliday)
        {
            try
            {
                List<SettlementHoliday> settlementHolidays = _ISchedulingHolidayDAL.GetSettlements(schedulingHoliday);
                settlementHolidays.ForEach(s =>
                {
                    mail = new MailMessage();
                    //
                    mail.To.Add(s.IdSettlementNavigation.IdContactPerNavigation.Gmail);
                    //כתובת מייל לשלוח ממנה
                    mail.From = new MailAddress("ah.holidayactivities@gmail.com");
                    // נושא ההודעה
                    mail.Subject = "שיבוץ לחג";
                    //תוכן ההודעה ב- HTML
                    string body = s.IdSettlementNavigation.IdContactPerNavigation.FirstName + " " + s.IdSettlementNavigation.IdContactPerNavigation.LastName + " שלום וברכה" + " - " +
                       "הפעילים " + s.HolidayVolunteers + " שובצו אצלכם בישוב לחג " + s.IdSchedulingHolidayNavigation.IdHolidayNavigation.DescriptionHoliday
                       + "תודה רבה וחג שמח"+" - "+" להערות ופרטים נוספים ניתן להשיב למייל זה";
                    mail.Body = "hi";
                    //הגדרת תוכן ההודעה ל - HTML 
                    mail.IsBodyHtml = true;
                    try
                    {
                        //שליחת ההודעה
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        //תפיסה וטיפול בשגיאות
                        //txtMessage.Text = ex.ToString();
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

