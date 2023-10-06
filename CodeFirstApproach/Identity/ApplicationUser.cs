using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeFirstApproach.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Sex { get; set; }
    }
}