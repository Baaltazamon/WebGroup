using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
        public int Type { get; set; }

        public virtual Member AuthorNavigation { get; set; }
        public virtual TypeProject TypeNavigation { get; set; }
    }
}
