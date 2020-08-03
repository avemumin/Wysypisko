using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wysypisko.Models
{
    // co to beddzie
    public class Document
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Pole nazwa dokumentu jest wymagane")]
        public string DocumentName { get; set; }
        public DateTime DateSaved { get; set; }
        public DocumentType DocumentType { get; set; }
        [Required(ErrorMessage = "musisz wybrać typ dokumentu")]
        public int DocumentTypeId { get; set; }
    }
} 