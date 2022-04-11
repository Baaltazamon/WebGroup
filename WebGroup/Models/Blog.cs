using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Author { get; set; }

        public virtual Member AuthorNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
