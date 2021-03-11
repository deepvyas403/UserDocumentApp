using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Core.Models
{
    public class UserDocumentModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DocumentName { get; set; }
    }
    public class UserDocumentRequest : UserDocumentModel
    {
        public string DocumentPath { get; set; }
    }
}
