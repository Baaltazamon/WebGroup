using System;
using System.Collections.Generic;

#nullable disable

namespace WebGroup.Models
{
    public partial class RequestProcessed
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }

        public virtual ContactPerson Contact { get; set; }
        public virtual Member User { get; set; }
    }
}
