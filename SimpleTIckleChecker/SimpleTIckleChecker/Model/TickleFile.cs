using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleTIckleChecker.Model
{
    public class TickleFile : TickleElement
    {
        #region Internal types

        private class MovePair
        {
            public string Source { get; set; }
            public string Destination { get; set; }

            public MovePair(string source, string destination)
            {
                Source = source;
                Destination = destination;
            }
        }

        #endregion Internal types

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
            var moves = new List<MovePair>();

            moves.Add(new MovePair(ElementPath, ElementPath.ReplaceTickleDate(newTickleDate)));

            if (HasInfoFile)
            {
                moves.Add(new MovePair(InfoFilePath, InfoFilePath.ReplaceTickleDate(newTickleDate)));
            }

            var res = true;
            foreach (var mp in moves)
            {
                try
                {
                    File.Move(mp.Source, mp.Destination);
                }
                catch (Exception ex)
                {
                    res = false;
                }
            }

            return res;
        }

        #endregion Public interface

        #region Private methods
        protected override bool LoadInformation()
        {
            var res = false;

            var infofileName = $"{Path.GetFileNameWithoutExtension(ElementPath)}-Information.md";
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
