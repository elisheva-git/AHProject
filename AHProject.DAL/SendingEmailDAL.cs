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

        }
        
    }
}

