using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiCore.Lib.DAL;
using Xunit;

namespace WikiCore.Test
{
    public class DatabaseTest
    {
        [Fact]
        public void MigrateSQLlite()
        {
            var connection = "Data Source=.\\blog.db";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite(connection);


            using (var db = new DatabaseContext(optionsBuilder.Options))
            {
                db.Database.Migrate();
            }
        }


        [Fact]
        public void MigrateSQL()
        {
            var connection = "Data Source=(localdb)\\Projects; Initial Catalog=wikicore";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connection);


            using (var db = new DatabaseContext(optionsBuilder.Options))
            {
                db.Database.Migrate();
            }
        }


        [Fact]
        public void MigrateInMemory()
        {
            var connection = "Data Source=(localdb)\\Projects; Initial Catalog=wikicore";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseInMemoryDatabase(connection);


            using (var db = new DatabaseContext(optionsBuilder.Options))
            {
                db.Database.Migrate();
            }
        }


        [Fact]
        public void CrudInMemory()
        {
            var connection = "Data Source=.\\blog.db";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite(connection);


            using (var db = new DatabaseContext(optionsBuilder.Options))
            {
                db.Database.Migrate();

                db.Blogs.Add(new Lib.DAL.Model.WikiPageEntity()
                {
                    Title = "title",
                    Body = "#h1",
                    Slug = "slug"

                });

                db.SaveChanges();

                var count=db.Blogs.Where(x => x.Slug == "slug").Count();

                Assert.Equal(1, count);
            }
        }
    }
}
