using System;
using System.Collections.Generic;

#nullable disable

namespace API.Data.Models
{
    public partial class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
