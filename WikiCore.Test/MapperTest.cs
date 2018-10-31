using AutoMapper;
using Microsoft.AspNetCore;
using System;
using WikiCore.Lib.BLL.Mapping;
using WikiCore.Lib.DAL.Model;
using WikiCore.Lib.DTO;
using Xunit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper.Configuration;
using WikiCore.Lib.BLL.BO;

namespace WikiCore.Test
{
    public class MapperTest
    {
       

        public MapperTest()
        {
            var mappings = new MapperConfigurationExpression();
            mappings.AddProfile<MappingProfile>();
            Mapper.Initialize(mappings); 
        }
        [Fact]
        public void EntityToDTO()
        {
            WikiPageEntity source = new WikiPageEntity()
            {
                Body = "# prova h1",
                Title = "title",
                Slug = "titleslug",
                Version =1
            };

            var result = Mapper.Map<WikiPageDTO>(source);
            Assert.Equal("title", result.Title);
            Assert.Equal(1, result.Version);
            Assert.Equal("<h1>prova h1</h1>", result.BodyHtml);


        }



        [Fact]
        public void BOToDEntity()
        {
            WikiPageBO source = new WikiPageBO()
            {
                BodyMarkDown = "# prova h1",
                Title = "title prova"
            };

            var result = Mapper.Map<WikiPageEntity>(source);
            Assert.Equal(source.Title, result.Title);
            Assert.Equal("title-prova", result.Slug);


        }
    }

}
