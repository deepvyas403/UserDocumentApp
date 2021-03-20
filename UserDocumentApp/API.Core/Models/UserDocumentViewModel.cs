using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace API.Core.Models
{
    public class UserDocumentViewModel : UserDocumentModel
    {
        public int DocumentId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime DocumentUploadedDateTime { get; set; }
    }
}
