﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WikiCore.Lib.BLL;
using WikiCore.Models;

namespace WikiCore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IWikiPageService service;
        public HomeController(IWikiPageService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var result=service.GetAllPages(null, 0, int.MaxValue);
            return View(result);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
