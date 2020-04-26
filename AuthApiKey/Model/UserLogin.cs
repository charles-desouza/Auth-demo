using System;
using System.Collections.Generic;

namespace AuthApiKey.Model
{
    public class UserLogin
    {
        public int Id { get; set; }

        public string ApiKey { get; set; }
        public string Owner { get; set; }
        public bool Disabled { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUsed { get; set; }

        public IList<UserRole> UserRoles { get; set; }


    }
}