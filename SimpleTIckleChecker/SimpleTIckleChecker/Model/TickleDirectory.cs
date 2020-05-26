using SimpleTIckleChecker.Model;
using System;
using System.IO;

namespace SimpleTIckleChecker
{
    public class TickleDirectory : TickleElement
    {
        #region Constants
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion Constants

        #region Properties
        public override ElementType ElementType => ElementType.Directory;
        #endregion Properties

        #region Public interface

        public TickleDirectory(string path) : base(path)
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
            throw new NotImplementedException();
        }

        public override bool DeferElement(DateTime newTickleDate)
        {
            throw new NotImplementedException();
        }
        #endregion Public interface

        #region Private methods
        protected override bool LoadInformation()
        {
            var res = false;

            var infofileName = $"{Path.GetFileNameWithoutExtension(Name)}-Information.md";
            var infofilePath = Path.Combine(ElementPath, infofileName);

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
