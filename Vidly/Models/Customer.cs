using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } // need to know why this needs to be included here?, 
        //My guess - to access this in controller and view. A column for the same will not be created in db tbl.
        public byte MembershipTypeId { get; set; }
        public DateTime? DOB { get; set; }
    }
}