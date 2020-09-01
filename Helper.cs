using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Roblox_Asset_Manager_by_Kyle
{
    public static class Helper
    {
        //cuz im lazy
        public static Regex RegexFilterNumbers = new Regex(@"\d+");

        public static string GetRelativePath()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"";
        }
    }
}
