using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleTIckleChecker
{
    public static class TicklePathUtils
    {
        #region Constants
        private static readonly Regex FilenameSplitRegex = new Regex(@"^(?<tickledata>\d\d\d\d_\d\d_\d\d)(-)(?<baseName>.*)$");

        #endregion Constants

        #region Public interface
        public static string ReplaceTickleDate(this string path, DateTime newDate)
        {
            var basePath = Path.GetDirectoryName(path);
            var origFilename = Path.GetFileName(path);
            var split = FilenameSplitRegex.Match(origFilename);

            if (!split.Success)
            {
                return null;
            }

            var newFilename = $"{newDate.ToString("yyyy_MM_dd-")}-{split.Groups["baseName"]}";

            return Path.Combine(basePath, newFilename);
        }
        #endregion Public interface
    }
}
