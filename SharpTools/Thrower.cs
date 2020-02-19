﻿
using System;
using System.IO;

namespace SharpTools
{
    public static class Thrower
    {
        public static Exception Make(string format, params object[] args)
        {
            return new Exception(Format.Apply(format, args));
        }

        public static Exception Make(Exception inner, string format, params object[] args)
        {
            return new Exception(Format.Apply(format, args), inner);
        }

        public static void Throw(string format, params object[] args)
        {
            throw Make(format, args);
        }

        public static void Throw(Exception inner, string format, params object[] args)
        {
            throw Make(inner, format, args);
        }

        public static string Dump(Exception ex)
        {
            var folder = Executable.Relative("Exceptions");
            Directory.CreateDirectory(folder);
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            var fileName = string.Format("exception-{0}.txt", timestamp);
            var filePath = Path.Combine(folder, fileName);
            File.WriteAllText(filePath, ex.ToString());
            return filePath;
        }
    }
}
