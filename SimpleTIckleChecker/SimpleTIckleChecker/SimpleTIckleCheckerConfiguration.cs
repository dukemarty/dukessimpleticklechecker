using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SimpleTIckleChecker
{
    public class SimpleTIckleCheckerConfiguration
    {
        #region Constants

        private static readonly SimpleTIckleCheckerConfiguration DefaultSettings = new SimpleTIckleCheckerConfiguration
        {
            TicklePath = "TestTickles",
        };

        #endregion Constants

        #region Properties

        [DataMember]
        public string TicklePath { get; set; }
        #endregion Properties

        #region Public interface
        public SimpleTIckleCheckerConfiguration() { }

        public SimpleTIckleCheckerConfiguration(SimpleTIckleCheckerConfiguration orig)
        {
            TicklePath = orig.TicklePath;
        }

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
                Console.WriteLine("Caught exception when trying to write xml: {0}\n{1}", ex.Message, ex.StackTrace);
            }
        }

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
                Console.WriteLine("Caught exception when trying to read xml: {0}\n{1}", ex.Message, ex.StackTrace);
            }

            if (settings == null)
            {
                settings = new SimpleTIckleCheckerConfiguration(DefaultSettings);
                settings.StoreToFile(filename);
            }

            return settings;
        }
        #endregion Public interface

    }
}
