using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WikiCore.Lib.DAL.Model
{
    public class WikiPageEntity
    {
       
        public int Version { get; set; }
        [Key]
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
