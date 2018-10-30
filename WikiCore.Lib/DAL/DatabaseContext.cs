using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WikiCore.Lib.DAL.Model;

namespace WikiCore.Lib.DAL
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<WikiPageEntity> Blogs { get; set; }
    }

}
