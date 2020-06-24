using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTIckleChecker.Model
{
    /// <summary>
    /// Common interface for tickleable elements.
    /// </summary>
    public interface ITickleElement
    {
        #region Properties

        /// <summary>
        /// Type of the tickle element.
        /// </summary>
        ElementType ElementType { get; }

        /// <summary>
        /// (Base) name of the tickle element.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Date when to tickle the element.
        /// </summary>
        DateTime TickleDate { get; }

        /// <summary>
        /// Flag whether an file with additional information for the element is available.
        /// </summary>
        bool HasInfoFile { get; }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Open the information file related to the tickle element.
        /// </summary>
        /// <returns>true if the file could be opened, otherwise else</returns>
        bool OpenInformation();

        /// <summary>
        /// Open the tickle element (with the assigned default application).
        /// </summary>
        /// <returns>true if the file could be opened, otherwise false</returns>
        bool OpenElement();

        /// <summary>
        /// Move element to a new location.
        /// </summary>
        /// <param name="newLocation">new location, e.g. a path to a folder</param>
        /// <param name="removeInfoFile">flag whether the info file (if existing) should be deleted or moved as well</param>
        /// <param name="removeTickleDatePrefix">flag whether the tickle date prefix of the element is to be removed</param>
        /// <returns>true if the move operation was successful, otherwise false</returns>
        bool MoveElement(string newLocation, bool removeInfoFile = false, bool removeTickleDatePrefix = true);

        /// <summary>
        /// Defer element, i.e. change the tickle date (most typically, tickle at a later time).
        /// </summary>
        /// <param name="newTickleDate">new tickle to which the element is to be defered</param>
        /// <returns>true if the deferring was successful, otherwise false</returns>
        bool DeferElement(DateTime newTickleDate);

        /// <summary>
        /// Remove the element (as well as a related info file if it exists).
        /// </summary>
        /// <returns>true if the removing was a success, otherwise false</returns>
        bool RemoveElement();

        #endregion Methods
    }
}
