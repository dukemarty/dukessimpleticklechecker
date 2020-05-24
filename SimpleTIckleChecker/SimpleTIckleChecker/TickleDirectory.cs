﻿using System.IO;

namespace SimpleTIckleChecker
{
    public class TickleDirectory : TickleElement
    {
        #region Properties
        public override bool IsDirectory => true;
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
