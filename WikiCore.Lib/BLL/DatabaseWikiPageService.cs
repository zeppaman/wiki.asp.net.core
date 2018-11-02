using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WikiCore.Lib.BLL.BO;
using WikiCore.Lib.DAL;
using WikiCore.Lib.DAL.Model;
using WikiCore.Lib.DTO;

namespace WikiCore.Lib.BLL
{
    public class DatabaseWikiPageService : IWikiPageService
    {
        private DatabaseContext db;
        private IMapper mapper;

        public DatabaseWikiPageService(DatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public WikiPageDTO GetPage(string slug)
        {
            var entity=db.WikiPages.Where(x => x.Slug == slug).OrderByDescending(z => z.Version).SingleOrDefault();
            return mapper.Map<WikiPageDTO>(entity);
        }

        public WikiPageDTO GetPageRevision(string slug, int version)
        {
            var entity = db.WikiPages.Where(x => x.Slug == slug && x.Version==version).SingleOrDefault();
            return mapper.Map<WikiPageDTO>(entity);
        }

        public WikiPageDTO Save(WikiPageBO item)
        {
            var itemToSave = mapper.Map<WikiPageEntity>(item);
            var count = db.WikiPages.Where(x => x.Slug == itemToSave.Slug).Count();
            itemToSave.Version = count + 1;
            if (count == 0)
            {
                db.WikiPages.Add(itemToSave);
            }
            else
            {
                var ent=db.WikiPages.Attach(itemToSave);
                ent.State = EntityState.Modified;
            }
            db.SaveChanges();
            return mapper.Map<WikiPageDTO>(itemToSave);
        }
    }
}
