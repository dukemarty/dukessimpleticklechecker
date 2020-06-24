using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimpleTIckleChecker
{
    /// <summary>
    /// Representation of the configuration of the tickle checker.
    /// </summary>
    public class SimpleTIckleCheckerConfiguration
    {
        #region Constants

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static readonly SimpleTIckleCheckerConfiguration DefaultSettings = new SimpleTIckleCheckerConfiguration
        {
            TicklePath = "TestTickles",
            DefaultMoveToPath = "WhiteBoard",
        };

        #endregion Constants

        #region Properties

        [DataMember]
        public string TicklePath { get; set; }

        [DataMember]
        public string DefaultMoveToPath { get; set; }
        #endregion Properties

        #region Public interface

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SimpleTIckleCheckerConfiguration() { }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="orig">original configuration to copy</param>
        public SimpleTIckleCheckerConfiguration(SimpleTIckleCheckerConfiguration orig)
        {
            TicklePath = orig.TicklePath;
            DefaultMoveToPath = orig.DefaultMoveToPath;
        }

        /// <summary>
        /// Store configuration to a file.
        /// </summary>
        /// <param name="filename">name of the configuration file to store to</param>
        public void StoreToFile(string filename)
        {
            try
            {
                var x = new XmlSerializer(typeof(SimpleTIckleCheckerConfiguration));
                var writer = new StreamWriter(filename);
                x.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Caught exception when trying to write xml: {ex.Message}");
            }
        }

        /// <summary>
        /// Load configuration from a given file, or use (and store) default settings if the file can not be loaded.
        /// </summary>
        /// <param name="filename">name of the configuration file to load</param>
        /// <returns>loaded configuration</returns>
        public static SimpleTIckleCheckerConfiguration LoadOrDefaultSettings(string filename)
        {
            SimpleTIckleCheckerConfiguration settings = null;

            try
            {
                var x = new XmlSerializer(typeof(SimpleTIckleCheckerConfiguration));
                var reader = new StreamReader(filename);
                settings = (SimpleTIckleCheckerConfiguration)x.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Caught exception when trying to read xml: {ex.Message}");
            }

            if (settings == null)
            {
                if (File.Exists(filename))
                {
                    File.Move(filename, $"{filename}-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.bak");
                }

                settings = new SimpleTIckleCheckerConfiguration(DefaultSettings);
                settings.StoreToFile(filename);
            }

            return settings;
        }
        #endregion Public interface

    }
}
