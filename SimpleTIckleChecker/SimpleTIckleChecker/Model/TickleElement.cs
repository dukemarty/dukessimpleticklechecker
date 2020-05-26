using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleTIckleChecker.Model
{
    public abstract class TickleElement : ITickleElement
    {
        #region Constants

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static readonly Regex TicklePathRegex = new Regex(@"(?<tickledate>\d\d\d\d_\d\d_\d\d)-(?<ticklename>.*)");
        public static readonly Regex InfoFileRegex = new Regex(@"(?<tickledate>\d\d\d\d_\d\d_\d\d)-(?<ticklebasename>.*)-Information.md");

        #endregion Constants

        #region Properties

        public string ElementPath { get; set; }

        public string Name { get; set; }

        public abstract ElementType ElementType { get; }

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

        public bool OpenInformation()
        {
            if (!HasInfoFile)
            {
                return false;
            }

            System.Diagnostics.Process.Start(InfoFilePath);

            return true;
        }

        public abstract bool OpenElement();

        public abstract bool MoveElement(string newLocation, bool removeInfoFile = false, bool removeTickleDatePrefix = true);

        public abstract bool DeferElement(DateTime newTickleDate);

        #endregion Public interface

        #region Private methods

        private void Initialize()
        {
            var match = TicklePathRegex.Match(Path.GetFileName(ElementPath));
            TickleDate = DateTime.Parse(match.Groups["tickledate"].Value.Replace('_', '-'));
            Name = match.Groups["ticklename"].Value;

            HasInfoFile = LoadInformation();
        }

        protected abstract bool LoadInformation();

        #endregion Private methods
    }
}
