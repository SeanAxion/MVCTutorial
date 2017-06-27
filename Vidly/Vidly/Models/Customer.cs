using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Please enter a customers name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType {  get; set; }

        [Required(ErrorMessage = "Please assign a membership type.")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        
        //redundant code
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id=1, Name="John Smith"},
                new Customer {Id=2, Name= "Mary Williams" }
            };
        }

    }

    
}