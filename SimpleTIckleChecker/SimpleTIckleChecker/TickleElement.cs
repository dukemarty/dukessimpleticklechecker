using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleTIckleChecker
{
    public class TickleElement
    {
        #region Constants

        public static readonly Regex TicklePathRegex = new Regex(@"(?<tickledate>\d\d\d\d_\d\d_\d\d)-(?<ticklename>.*)");

        #endregion Constants

        #region Properties

        public string ElementPath { get; set; }

        public string Name { get; set; }

        public bool IsDirectory { get; set; }

        public DateTime TickleDate { get; set; }

        public bool HasInfoFile { get; set; }

        public string InfoFilePath { get; set; }
        #endregion Properties

        #region Public interface
        public TickleElement(string path)
        {
            ElementPath = path;

            Initialize();
        }
        #endregion Public interface

        #region Private methods

        private void Initialize()
        {
            var fa = File.GetAttributes(ElementPath);
            IsDirectory = fa.HasFlag(FileAttributes.Directory);

            var match = TicklePathRegex.Match(Path.GetFileName(ElementPath));
            TickleDate = DateTime.Parse(match.Groups["tickledate"].Value.Replace('_', '-'));
            Name = match.Groups["ticklename"].Value;

            HasInfoFile = LoadInformation();
        }

        private bool LoadInformation()
        {
            var res = false;

            var infofileName = $"{Path.GetFileNameWithoutExtension(Name)}-Information.md";
            string infofilePath;
            if (IsDirectory)
            {
                infofilePath = Path.Combine(ElementPath, infofileName);
            }
            else
            {
                infofilePath = Path.Combine(Path.GetDirectoryName(ElementPath), infofileName);
            }
            if (File.Exists(infofilePath))
            {
                res = true;
                InfoFilePath = infofilePath;
            }

            return res;
        }

        #endregion Private methods
    }
}
