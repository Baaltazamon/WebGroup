using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class StatusStudent
    {
        public StatusStudent()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
