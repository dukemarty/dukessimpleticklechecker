using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTIckleChecker.Model
{
    public interface ITickleElement
    {
        #region Properties

        ElementType ElementType { get; }

        string Name { get; }

        DateTime TickleDate { get; }

        bool HasInfoFile { get; }
        #endregion Properties

        #region Methods

        bool OpenInformation();

        bool OpenElement();

        bool MoveElement(string newLocation, bool removeInfoFile = false, bool removeTickleDatePrefix = true);

        bool DeferElement(DateTime newTickleDate);

        #endregion Methods
    }
}
