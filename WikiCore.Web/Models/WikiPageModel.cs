using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiCore.Lib.DTO;

namespace WikiCore.Models
{
    public class WikiPageModel
    {
      public   WikiPageDTO WikiPage { get; set; }
      public string EditUrl { get; set; }
    }
}
