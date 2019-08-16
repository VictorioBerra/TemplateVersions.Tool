using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateVersions.Tool
{
    public static class StringExtensions
    {
        public static string StripFullPathFromDirectory(this string directoryPath)
        {
            return directoryPath.Substring(directoryPath.LastIndexOf('\\') + 1);
        }
    }
}
