using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{// temperory class for the datatables as it can not find the length of undefined i.e. null (returned for Membership type)
    public class PartialCustomer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        public PartialCustomer()
        {
            Id = 0; // 0, "Default" , false, 0, DateTime.Now
            Name = "Default";
            IsSubscribedToNewsletter = false;
            MembershipTypeId = 0;
            DOB = DateTime.Now;
        }
    }
}