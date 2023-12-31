﻿using Core.Configuration.Logic;

namespace Core.Configuration.Models
{
    public class BrowserConfiguration : IConfiguration
    {
        public string SectionName => "Browser";

        public string TypeBrowser { get; set; }
        public string StartUrl { get; set; }
        public bool Headless { get; set; }
        public int TimeOut { get; set; }
    }
}