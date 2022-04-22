using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGroup.Models;

namespace WebGroup.Models
{
    public class Commentor
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public List<ChildCommentor> Children { get; set; }
        public string Author { get; set; }
        public int Id { get; set; }
    }

    public class ChildCommentor
    {
        public Comment Comment { get; set; }
        public string Author { get; set; }
    }
}
