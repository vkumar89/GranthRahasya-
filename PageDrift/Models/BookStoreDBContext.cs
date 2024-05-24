using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;
 

namespace PageDrift.Models
{
    public class BookStoreDBContext:DbContext
    {
        public BookStoreDBContext() :base("ConStr") 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookStoreDBContext>());
        }
       public DbSet<Books> books { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}