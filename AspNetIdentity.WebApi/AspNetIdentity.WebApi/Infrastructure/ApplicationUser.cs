using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AspNetIdentity.WebApi.Infrastructure
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [NotMapped]
        public Int32? DbLinkId { get; set; }

        public static ApplicationUser CreateDbUserLink(ApplicationUser user)
        {
            using (Library.Data.DAL d_Dal = new Library.Data.DAL())
            {
                var Id = new System.Data.SqlClient.SqlParameter("Id", System.Data.SqlTypes.SqlInt32.Null) { Direction = System.Data.ParameterDirection.InputOutput };

                d_Dal.ExecuteNonQuery("Create_User", new System.Data.SqlClient.SqlParameter[] {
                    Id, 
                    new System.Data.SqlClient.SqlParameter("AspNetUserId", user.Id),
                    new System.Data.SqlClient.SqlParameter("Username", user.UserName)
                }, System.Data.CommandType.StoredProcedure);

                Int32 Out;

                bool parse = Int32.TryParse(Id.Value.ToString(), out Out);

                if (parse)
                    user.DbLinkId = Out;

                return user;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}