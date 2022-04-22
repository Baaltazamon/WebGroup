using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public sealed partial class Comment
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

        public AuthorFeedback AuthorNavigation { get; set; }
        public Comment OwnerCommentNavigation { get; set; }
        public Blog PublicationNavigation { get; set; }
        public ICollection<Comment> InverseOwnerCommentNavigation { get; set; }
    }
}