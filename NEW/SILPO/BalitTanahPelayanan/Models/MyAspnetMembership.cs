using System;
using System.Collections.Generic;

namespace BalitTanahPelayanan.Models
{
    public partial class MyAspnetMembership
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public byte? PasswordFormat { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public byte? IsApproved { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public byte? IsLockedOut { get; set; }
        public DateTime? LastLockedOutDate { get; set; }
        public int? FailedPasswordAttemptCount { get; set; }
        public DateTime? FailedPasswordAttemptWindowStart { get; set; }
        public int? FailedPasswordAnswerAttemptCount { get; set; }
        public DateTime? FailedPasswordAnswerAttemptWindowStart { get; set; }
    }
}
