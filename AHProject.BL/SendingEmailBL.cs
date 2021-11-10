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
        IHolidayVolunteerDAL _IHolidayVolunteerDAL;
        public SendingEmailBL(IHolidayVolunteerDAL iHolidayVolunteerDAL)
        {
            _IHolidayVolunteerDAL = iHolidayVolunteerDAL;
            // Smtp יצירת אוביקט 
            smtp = new SmtpClient();
            //הגדרת השרת של גוגל
            smtp.Host = "smtp.gmail.com";
            //הגדרת פרטי הכניסה לחשבון גימייל
            smtp.Credentials = new System.Net.NetworkCredential(
            "e0533169098@gmail.com", "0533124268");
            //אפשור SSL (חובה(
            smtp.EnableSsl = true;
        }
        public void sendToVolunteers(int schedulingHoliday)
        {
            try
            {
                List<HolidayVolunteer> holidayVolunteers = _IHolidayVolunteerDAL.GetVolunteersBySchedulingHoliday(schedulingHoliday, true);
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

