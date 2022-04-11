using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class TypeProject
    {
        public TypeProject()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
