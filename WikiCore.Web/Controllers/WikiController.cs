using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiCore.Lib.BLL;
using WikiCore.Lib.BLL.BO;
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
                WikiPage = page,
                EditUrl=Request.Scheme+"://"+(Request.Host+Request.Path+"/edit").Replace("//","/")
            };

            return View(model);
        }


        public IActionResult Edit(string slug)
        {
            WikiPageDTO page = service.GetPage(slug);
            WikiPageEditModel model = null;


            if (page == null)
            {
                model = new WikiPageEditModel()
                {
                    Title = slug,
                    Markdown = "## " + slug
                };
            }
            else
            {
                model = new WikiPageEditModel()
                {
                    Title = page.Title,
                    Markdown = page.BodyMarkDown
                };

            }
            return View(model);
        }

        public IActionResult Save(WikiPageEditModel item)
        {
            WikiPageBO bo = new WikiPageBO()
            {
                Title = item.Title,
                BodyMarkDown = item.Markdown
            };

            WikiPageDTO page = service.Save(bo);

            return Redirect("/wiki/" + page.Slug);
        }
    }
}
