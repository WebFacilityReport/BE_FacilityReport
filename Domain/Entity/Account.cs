using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Account
    {
        public Account()
        {
            Feedbacks = new HashSet<Feedback>();
            JobCreators = new HashSet<Job>();
            JobEmployees = new HashSet<Job>();
            Notifications = new HashSet<Notification>();
        }

        public Guid AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Role { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Job> JobCreators { get; set; }
        public virtual ICollection<Job> JobEmployees { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
