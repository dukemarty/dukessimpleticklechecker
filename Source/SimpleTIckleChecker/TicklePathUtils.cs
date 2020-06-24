using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SimpleTIckleChecker
{
    /// <summary>
    /// Utility methods for editing tickle pathes.
    /// </summary>
    public static class TicklePathUtils
    {
        #region Constants
        private static readonly Regex FilenameSplitRegex = new Regex(@"^(?<tickledata>\d\d\d\d_\d\d_\d\d)(-)(?<baseName>.*)$");

        #endregion Constants

        #region Public interface

        /// <summary>
        /// Replace tickle date (in the "standard" format) in a path with a new date.
        /// </summary>
        /// <param name="path">original path with old date</param>
        /// <param name="newDate">new date to replace</param>
        /// <returns>copy of the original string with the replaced date</returns>
        public static string ReplaceTickleDate(this string path, DateTime newDate)
        {
            var basePath = Path.GetDirectoryName(path);
            var origFilename = Path.GetFileName(path);
            var split = FilenameSplitRegex.Match(origFilename);

            if (!split.Success)
            {
                return null;
            }

            var newFilename = $"{newDate.ToString("yyyy_MM_dd")}-{split.Groups["baseName"]}";

            return Path.Combine(basePath, newFilename);
        }
        #endregion Public interface
    }
}
