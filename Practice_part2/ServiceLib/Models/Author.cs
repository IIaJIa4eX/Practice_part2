using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLib.Models
{    //for review

    public class Author
    {
        public string Name { get; set; }
        public string Lang { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Lang})";
        }
    }
}