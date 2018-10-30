using System;
using System.Collections.Generic;
using System.Text;

namespace WikiCore.Lib.DTO
{
    public  class WikiPageDTO
    {
        public string Title { get; set; }
        public string BodyMarkDown { get; set; }
        public string BodyHtml { get; set; }
        public int Version { get; set; }
        public string Slug { get; set; }
    }
}
