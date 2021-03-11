using System;
using System.Collections.Generic;

#nullable disable

namespace API.Data.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; }
    }
}
