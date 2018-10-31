using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WikiCore.Lib.BLL;
using WikiCore.Lib.BLL.Mapping;
using WikiCore.Lib.DAL;
using Xunit;

namespace WikiCore.Test
{
    public class ServiceTest
    {

        public ServiceTest()
        {
            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<MappingProfile>();
            Mapper.Initialize(mappings);
        }

        [Fact]
        public void TestSave()
        {
            var connection = "Data Source=.\\blog.db";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite(connection);


            using (var db = new DatabaseContext(optionsBuilder.Options))
            {
                db.Database.Migrate();
                db.SaveChanges();

                DatabaseWikiPageService service = new DatabaseWikiPageService(db, Mapper.Instance);
                service.Save(new Lib.BLL.BO.WikiPageBO()
                {
                    BodyMarkDown="#h1",
                    Title="prova prova"
                });

                var item = service.GetPage("prova-prova");
                Assert.NotNull(item);
            }

        }
    }
}
