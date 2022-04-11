using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            RequestProcesseds = new HashSet<RequestProcessed>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }

        public virtual ICollection<RequestProcessed> RequestProcesseds { get; set; }
    }
}
