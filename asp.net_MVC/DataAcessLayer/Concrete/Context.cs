using System;
using System.Collections.Generic;
using System.Data.Entity;
using EntityLayer.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Catagories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
