using Domain.Entity;


namespace Infrastructure.Model.Response.ResponseAccount
{
    public class ResponseAllAccount
    {
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
        public virtual ICollection<Domain.Entity.Task> TaskCreators { get; set; }
        public virtual ICollection<Domain.Entity.Task> TaskEmployees { get; set; }
    }
}
