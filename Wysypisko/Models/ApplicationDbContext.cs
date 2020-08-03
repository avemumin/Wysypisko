using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wysypisko.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DbConn")
        {

        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
    }
}