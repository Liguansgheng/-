using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HL7LIB
{
    public static class common
    {
        public static string version = "2.4";

        public static string componentDelimiter = "^";
        public static string segmentDelimiter = "\r";
        public static string fieldDelimiter = "|";
        public static string subComponentDelimiter = "&";
        public static string repeatDelimiter = "~";
        public static string escapeDelimiter = "\\";
    }
}