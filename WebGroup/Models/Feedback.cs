using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Author { get; set; }
        public string Post { get; set; }

        public virtual AuthorFeedback AuthorNavigation { get; set; }
    }
}
