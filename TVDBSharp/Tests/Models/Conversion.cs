namespace Tests.Models
{
    /// <summary>
    ///     A helper class to translate an object to its XML value and vice versa.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        ///     The XML representation for either an element tag or a value.
        /// </summary>
        public string XmlValue { get; set; }

        /// <summary>
        ///     The object representation for either a property or a value.
        /// </summary>
        public string ObjValue { get; set; }

        /// <summary>
        ///     Constructs a new object with the given values.
        /// </summary>
        /// <param name="xmlValue">XML Value (see <see cref="XmlValue" />).</param>
        /// <param name="objValue">Object Value (see <see cref="ObjValue" />).</param>
        public Conversion(string xmlValue, string objValue)
        {
            XmlValue = xmlValue;
            ObjValue = objValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Conversion) obj);
        }

        protected bool Equals(Conversion other)
        {
            return string.Equals(XmlValue, other.XmlValue) && string.Equals(ObjValue, other.ObjValue);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((XmlValue != null ? XmlValue.GetHashCode() : 0)*397) ^
                       (ObjValue != null ? ObjValue.GetHashCode() : 0);
            }
        }
    }
}