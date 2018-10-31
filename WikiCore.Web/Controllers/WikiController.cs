using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiCore.Lib.BLL;
using WikiCore.Lib.DAL;
using WikiCore.Lib.DTO;
using WikiCore.Models;

namespace WikiCore.Controllers
{
    public class WikiController : Controller
    {
        IWikiPageService service;
        public WikiController(IWikiPageService service)
        {
            this.service = service;
        }

        public IActionResult View(string slug, int? version=null)
        {
            WikiPageDTO page = null;
            if (version.HasValue)
            {
                page = service.GetPageRevision(slug, version.Value);
            }
            else
            {
                page = service.GetPage(slug);
            }

            if (page == null)
            {
                return Redirect(Request.Path + "/edit");
            }

            var model = new WikiPageModel()
            {
                WikiPage = page
            };

            return View(model);
        }


        public IActionResult Edit(string slug)
        {
            WikiPageDTO page = service.GetPage(slug);
            WikiPageModel model = null;
            

            if (page == null)
            {
                model = new WikiPageModel()
                {
                    WikiPage = new WikiPageDTO
                    {
                        Slug=slug,
                        Title=slug
                    }
                };
            }
            return View(model);
        }
    }
}
