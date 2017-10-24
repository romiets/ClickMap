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
    [XmlRoot("event"), XmlType("event")]
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string FullAddress { get; set; }
        public Address Address { get; set; }

        //Create a version
        public Events(XElement xEvents)
        {
            Id = Convert.ToInt32(xEvents.Attribute("id").Value);
            Name = xEvents.Attribute("name").Value;
            Date = xEvents.Attribute("date").Value;
            Address = Address.GetAddress(xEvents);
            FullAddress = string.Format("{0} {1} {2} {3} {4}", Address.Address1, Address.Address2,Address.Suburb, Address.State, Address.Country);
        }
 
        //Get the list of versions
        public static List<Events> GetEvents(XElement xDocument)
        {
            if (xDocument == null)
                return null;

            List<Events> list = new List<Events>();
            var xEvents = xDocument.Elements("event");

            foreach (var xEvent in xEvents)
            {
                list.Add(new Events(xEvent));
            }

            return list;
        }

    }
}
