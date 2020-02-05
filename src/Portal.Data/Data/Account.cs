using System;
using Microsoft.AspNetCore.Identity;
using Portal.Data.Interfaces;

namespace Portal.Data.Data
{
    public class Account : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsBlocked { get; set; }
        public string Iplog { get; set; }
        public string Email { get; set; }
        public string EmailActivationKey { get; set; }
        public bool HasEmailConfirmed { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int LoginCount { get; set; }
    }
}
