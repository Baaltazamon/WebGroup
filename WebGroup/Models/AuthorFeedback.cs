using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class AuthorFeedback
    {
        public AuthorFeedback()
        {
            Comments = new HashSet<Comment>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
