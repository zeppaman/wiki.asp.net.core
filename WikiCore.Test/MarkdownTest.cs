using HeyRed.MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Text;
using WikiCore.Lib.Utilities;
using Xunit;

namespace WikiCore.Test
{
    public class MarkdownTest
    {
        [Fact]
        public void ConvertMarkDown()
        {
            var options = new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = true,
                LinkEmails = true,
                QuoteSingleLine = true,
                StrictBoldItalic = true
            };

            Markdown mark = new Markdown(options);
            var testo = mark.Transform("#testo");
            Assert.Equal("<h1>testo</h1>", testo);
        }

        [Fact]
        public void ConvertMarkDownHelper()
        {
            Assert.Equal("<h1>testo</h1>", MarkdownHelper.ConvertToHtml("#testo"));
        }
    }
}
