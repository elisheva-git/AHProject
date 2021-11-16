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
            // Smtp יצירת אוביקט 
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
                        //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
                        mail.To.Add(hv.IdVolunteerNavigation.Gmail);
                        //כתובת מייל לשלוח ממנה
                        mail.From = new MailAddress("e0533169098@gmail.com");
                        // נושא ההודעה
                        mail.Subject = "שיבוץ לחג";
                        //תוכן ההודעה ב- HTML
                        string body = "<h1>Hello</h1>";
                        mail.Body = body;
                        //mail.Body = "שלום וברכה ";
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

        public void sendToContactPersonOfSettlements(int schedulingHoliday)
        {
            try
            {
                List<SettlementHoliday> settlementHolidays = _ISchedulingHolidayDAL.GetSettlements(schedulingHoliday);
                settlementHolidays.ForEach(s =>
                {
                    mail = new MailMessage();
                    //למי לשלוח (יש אפשרות להוסיף כמה נמענים) 
                    mail.To.Add(s.IdSettlementNavigation.IdContactPerNavigation.Gmail);
                    //כתובת מייל לשלוח ממנה
                    mail.From = new MailAddress("e0533169098@gmail.com");
                    // נושא ההודעה
                    mail.Subject = "שיבוץ לחג";
                    //תוכן ההודעה ב- HTML
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

