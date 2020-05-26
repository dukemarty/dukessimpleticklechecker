using SimpleTIckleChecker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleTIckleChecker.Model
{
    public class TickleFolder
    {
        #region Constants
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion Constants

        #region Properties

        public string TicklePath { get; private set; }

        public List<ITickleElement> Elements { get; set; } = new List<ITickleElement>();

        #endregion Properties

        #region Public interface

        public TickleFolder(string tickleFolderPath)
        {
            TicklePath = tickleFolderPath;

            LoadFolder();
        }

        #endregion Public interface

        #region Private methods

        private void LoadFolder()
        {
            var entries = Directory.EnumerateFileSystemEntries(TicklePath);

            //var rgx = new Regex(@"\d\d\d\d_\d\d_\d\d-.*");
            foreach (var e in entries.Where(e => TickleElement.TicklePathRegex.IsMatch(Path.GetFileName(e))))
            {
                var newElem = TickleElementFactory.Construct(Path.GetFullPath(e));
                Elements.Add(newElem);
            }
        }

        #endregion Private methods

        #region Attributes


        #endregion Attributes
    }
}
