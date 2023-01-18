using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wcf_Service.Interfaces;

namespace Wcf_Service
{//for_review
    public class SettingsService : ISettingsService
    {
        public string FileName { get; set; }
    }
}