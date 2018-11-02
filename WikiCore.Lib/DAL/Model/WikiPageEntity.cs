using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WikiCore.Lib.DAL.Model
{
    public class WikiPageEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public int Version { get; set; }
        public string Slug { get; set; }

        public string Body { get; set; }
        public string Title { get; set; }
    }
}
