using AspNetIdentity.WebApi.Infrastructure;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;

namespace AspNetIdentity.WebApi.Validators
{
    public class MyCustomUserValidator : UserValidator<ApplicationUser>
    {

        List<string> _allowedEmailDomains = new List<string> { "jsmbars.co.uk", "hotmail.com", "gmail.com", "icloud"};

        public MyCustomUserValidator(ApplicationUserManager appUserManager)
            : base(appUserManager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            var reg = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            Match match = Regex.Match(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            
            if (!match.Success)
            {
                var errors = result.Errors.ToList();

                errors.Add("Not a valid email address.");

                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}