using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@starpizza.com";
        private string _mailFrom = "noreply@starpizza.com";

        public void SenMail(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
