using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class Comment
    {
        public Comment()
        {
            InverseOwnerCommentNavigation = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Publication { get; set; }
        public int? OwnerComment { get; set; }

        public virtual Member Author1 { get; set; }
        public virtual AuthorFeedback AuthorNavigation { get; set; }
        public virtual Comment OwnerCommentNavigation { get; set; }
        public virtual News Publication1 { get; set; }
        public virtual Blog PublicationNavigation { get; set; }
        public virtual ICollection<Comment> InverseOwnerCommentNavigation { get; set; }
    }
}
