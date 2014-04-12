using System.Xml.Serialization;

namespace Tests.Models
{
    /// <summary>
    ///     Simulation of the real XML tree.
    /// </summary>
    [XmlRoot("Data")]
    public class Data
    {
        /// <summary>
        ///     The XML tree's show object.
        /// </summary>
        [XmlElement("Series")]
        public TestShow TestShow { get; set; }
    }
}