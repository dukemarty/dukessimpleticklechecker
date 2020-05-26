using System;
using System.IO;

namespace SimpleTIckleChecker.Model
{
    public class TickleFile : TickleElement
    {
        #region Constants
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion Constants

        #region Properties
        public override ElementType ElementType => ElementType.File;
        #endregion Properties

        #region Public interface

        public TickleFile(string path) : base(path)
        {

        }

        public override bool OpenElement()
        {
            if (!File.Exists(ElementPath)) { return false; }

            System.Diagnostics.Process.Start(ElementPath);

            return true;
        }

        public override bool MoveElement(string newLocation, bool removeInfoFile = false, bool removeTickleDatePrefix = true)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeferElement(DateTime newTickleDate)
        {
            var sourceFile = ElementPath;
            var destinationPath = Path.GetDirectoryName(sourceFile);
            var destinationName = $"{newTickleDate.ToString("yyyy_MM_dd")}-{Name}";
            var destinationFile = Path.Combine(destinationPath, destinationName) ;

            bool res;
            try
            {
                File.Move(sourceFile, destinationFile);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }

            if (HasInfoFile)
            {
                sourceFile = InfoFilePath;
            }

            return res;
        }

        #endregion Public interface

        #region Private methods
        protected override bool LoadInformation()
        {
            var res = false;

            var infofileName = $"{Path.GetFileNameWithoutExtension(Name)}-Information.md";
            var infofilePath = Path.Combine(Path.GetDirectoryName(ElementPath), infofileName);

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
