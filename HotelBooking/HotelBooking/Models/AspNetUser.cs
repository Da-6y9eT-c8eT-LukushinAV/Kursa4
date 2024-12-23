﻿using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Models
{
    public class AspNetUser : IdentityUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public ICollection<AspNetUserClaim> UserClaims { get; set; }
        public ICollection<AspNetUserLogin> UserLogins { get; set; }
        public ICollection<AspNetUserRole> UserRoles { get; set; }
        public ICollection<AspNetUserToken> UserTokens { get; set; }
    }

}
