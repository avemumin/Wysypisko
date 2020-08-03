using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wysypisko.Models;
using System.Data.Entity;
using Wysypisko.ViewModel;

namespace Wysypisko.Controllers
{
    public class DocumentsController : Controller
    {

        private ApplicationDbContext _context;

        public DocumentsController()
        {
            _context = new ApplicationDbContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        // GET: Documents
        public ActionResult Index()
        {
            var views = _context.Documents.Include(x => x.DocumentType).ToList();
            return View(views);
        }

        public ActionResult NewOne()
        {
            var docTypes = _context.DocumentTypes.ToList();
            var documentFromViewModel = new DocumentFromViewModel
            {
                DocTypes = docTypes
            };
            return View("DocumentsForm", documentFromViewModel);
        }
        [HttpPost]
        public ActionResult Save(Document document)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DocumentFromViewModel//(document)
                {
                    DocTypes = _context.DocumentTypes.ToList()
                };

                return View("DocumentsForm", viewModel);
            }
            if (document.Id == 0)
            {
                _context.Documents.Add(document);
            }
            else
            {
                var docInDb = _context.Documents.Single(d => d.Id == document.Id);
                docInDb.DocumentName = document.DocumentName;
                docInDb.DateSaved = document.DateSaved;
                docInDb.DocumentTypeId = document.DocumentTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Documents");

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var selectedDocument = _context.Documents.SingleOrDefault(x => x.Id == id);
            if (selectedDocument == null)
                return HttpNotFound();
            _context.Documents.Remove(selectedDocument);
            _context.SaveChanges();
            return RedirectToAction("Index", "Documents");
        }
         
        public ActionResult Edit(int id)
        {
            var document = _context.Documents
                .Include(x=>x.DocumentType)
                .SingleOrDefault(x => x.Id == id);

            if (document == null)
                return HttpNotFound();

            var viewModel = new DocumentFromViewModel(document)
            {
                DocTypes = _context.DocumentTypes.ToList(),
                Document = document
            };
            return View("DocumentsForm", viewModel);
        }
    }
}