using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Library;
namespace AspNetIdentity.WebApi.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var emailAsync = new EmailAsync();
            await emailAsync.SendEmail(new List<string>() { message.Destination }, message.Subject, message.Body, "registration@jsmbars.co.uk");
        }
    }
}