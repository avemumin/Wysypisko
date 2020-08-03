using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wysypisko.Models;

namespace Wysypisko.ViewModel
{
    public class DocumentFromViewModel
    {
        public IEnumerable<DocumentType> DocTypes { get; set; }
        public Document Document { get; set; }
        public int? Id { get; set; }
        [Required(ErrorMessage = "Pole nazwa dokumentu jest wymagane")]
        [StringLength(100)]
        public string DocumentName { get; set; }
        [Required]
        public DateTime DateSaved { get; set; }
        [Required(ErrorMessage = "musisz wybrać typ dokumentu")]
        public int? DocumentTypeId { get; set; }

        public DocumentType DocumentTypes { get; set; }
        public DocumentFromViewModel()
        {
            Id = 0;
            DateSaved = DateTime.Now;
        }

        public DocumentFromViewModel(Document document)
        {
            Id = document.Id;
            DocumentName = document.DocumentName;
            DateSaved = document.DateSaved;
            DocumentTypeId = document.DocumentTypeId;
        }
    }
}