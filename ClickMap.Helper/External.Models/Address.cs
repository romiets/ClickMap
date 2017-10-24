using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ClickMap.Helper.External.Models
{
    [Serializable]
    [XmlRoot("address"), XmlType("address")]
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //Create a factory
        public Address(XElement xAddress)
        {
            Address1 = xAddress.Attribute("address1").Value;
            Address2 = xAddress.Attribute("address2").Value;
            Suburb = xAddress.Attribute("suburb").Value;
            State = xAddress.Attribute("state").Value;
            Country = xAddress.Attribute("country").Value;
        }

        //Get the factories of a version
        public static Address GetAddress(XElement xEvents)
        {
            XElement xAddressDetail = xEvents.Element("address");
            if (xAddressDetail == null)
                return null;

            Address xAddress = new Address(xAddressDetail);

            return xAddress;
        }
    }
}
