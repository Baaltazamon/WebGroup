using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class News
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Author { get; set; }
        public DateTime DatePublication { get; set; }

        public virtual Member AuthorNavigation { get; set; }
    }
}
