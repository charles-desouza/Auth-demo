using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}