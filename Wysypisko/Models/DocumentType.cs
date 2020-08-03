using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wysypisko.Models
{
    public class DocumentType
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string DocumentTypeDescription { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

    }
}