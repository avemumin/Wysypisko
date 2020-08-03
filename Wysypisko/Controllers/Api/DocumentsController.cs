using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wysypisko.Models;

namespace Wysypisko.Controllers.Api
{
    public class DocumentsController : ApiController
    {
        private ApplicationDbContext _context;

        public DocumentsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Document> GetDocuments()
        {
            return _context.Documents.ToList();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var selectedDocument = _context.Documents.SingleOrDefault(x => x.Id == id);
            if (selectedDocument == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Documents.Remove(selectedDocument);
            _context.SaveChanges();
           
        }
    }
}
