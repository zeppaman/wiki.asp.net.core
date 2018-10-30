﻿using HeyRed.MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiCore.Lib.Utilities
{
    public static class MarkdownHelper
    {

        static MarkdownOptions options;
        static Markdown converter;
        static MarkdownHelper()
        {
            options = new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = true,
                LinkEmails = true,
                QuoteSingleLine = true,
                StrictBoldItalic = true
            };

            converter = new Markdown(options);
        }
        


        public static string ConvertToHtml(string input)
        {
            Markdown mark = new Markdown(options);
            return mark.Transform(input);

        }
    }
}
