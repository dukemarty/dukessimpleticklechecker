using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTIckleChecker.Model
{
    public class TickleElementFactory
    {
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
