using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class Member
    {
        public Member()
        {
            Achievements = new HashSet<Achievement>();
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<Comment>();
            News = new HashSet<News>();
            Projects = new HashSet<Project>();
            RequestProcesseds = new HashSet<RequestProcessed>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Status { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual StatusStudent StatusNavigation { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<RequestProcessed> RequestProcesseds { get; set; }
    }
}
