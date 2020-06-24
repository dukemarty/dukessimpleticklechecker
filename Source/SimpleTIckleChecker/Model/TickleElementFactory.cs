using System.IO;

namespace SimpleTIckleChecker.Model
{
    /// <summary>
    /// Factory class for constructing tickle elements, depending on the required type.
    /// </summary>
    public class TickleElementFactory
    {
        #region Constants
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion Constants

        #region Public interface

        public static ITickleElement Construct(string path)
        {
            var fa = File.GetAttributes(path);
            var isDirectory = fa.HasFlag(FileAttributes.Directory);

            ITickleElement res;
            if (isDirectory)
            {
                res = new TickleDirectory(path);
            }
            else
            {
                res = new TickleFile(path);
            }

            return res;
        }

        #endregion Public interface
    }
}
