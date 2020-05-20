using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        // we only need the iterate over functionality and IEnumerable does this job whereas List<> will give add, 
        //remove, access object by index, etc whic is unnecessary.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        // some times we only need a few properties of customer class at that time we only use them not the entire class 
        //to keep the code simple, what if we need one prop from customer and one from membershipType and one from movie 
        // so using the one that is required keeps the code clean and keeps the memory in check by not using unnecessary 
        //class members.
        public Customer Customer { get; set; }
    }
}