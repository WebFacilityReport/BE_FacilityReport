using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Account
    {
        public Account()
        {
            Feedbacks = new HashSet<Feedback>();
            Posts = new HashSet<Post>();
            TaskCreators = new HashSet<Task>();
            TaskEmployees = new HashSet<Task>();
        }

        public Guid AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Task> TaskCreators { get; set; }
        public virtual ICollection<Task> TaskEmployees { get; set; }
    }
}
