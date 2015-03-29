﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolderHelper
{
    public static class StringExtension
    {
        /// <summary>
        /// Generates a permalink slug for passed string
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>clean slug string (ex. "some-cool-topic")</returns>
        public static string GenerateSlug(this string phrase)
        {
            var s = phrase.RemoveAccent().ToLower();
            s = Regex.Replace(s, @"[^a-z0-9\s-]", ""); // remove invalid characters
            s = Regex.Replace(s, @"\s+", " ").Trim(); // single space
            s = s.Substring(0, s.Length <= 45 ? s.Length : 45).Trim(); // cut and trim
            s = Regex.Replace(s, @"\s", "-"); // insert hyphens
            return s.ToLower();
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
