using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Models
{
    public class UserDocumentViewModel : UserDocumentModel
    {
        public int DocumentID { get; set; }
        public string DocumentPath { get; set; }
        public DateTime DocumentUploadedDateTime { get; set; }
    }
}
