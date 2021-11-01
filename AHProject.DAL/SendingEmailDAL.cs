using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using AHProject.DAL.Models;
using System.Linq;

namespace AHProject.DAL
{
    public class SendingEmailDAL: ISendingEmailDAL
    {
        MailMessage mail;
        SmtpClient smtp;
        AHDBContext _context;
        public SendingEmailDAL(AHDBContext context)
        {
            this._context = context;
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
        public void send(int schedulingHoliday)
        {
            try
            {
                _context.HolidayVolunteers.Where(hv => hv.IdSchedulingHoliday == schedulingHoliday && hv.IdSettlement != null).ToList()
                    .ForEach(hv =>
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

