using AutoMapper;
using Slugify;
using System;
using System.Collections.Generic;
using System.Text;
using WikiCore.Lib.DAL.Model;
using WikiCore.Lib.DTO;
using WikiCore.Lib.Utilities;

namespace WikiCore.Lib.BLL.Mapping
{
    public class MappingProfile : Profile
    {
      

        public MappingProfile()
        {
            CreateMap<WikiPageEntity, WikiPageDTO>()
                .ForMember(dest => dest.BodyMarkDown, (expr) => expr.MapFrom<string>(x => x.Body))
                .ForMember(dest => dest.BodyHtml, (expr) => expr.MapFrom<string>(x => MarkdownHelper.ConvertToHtml(x.Body)));
               

        }
    }
}
