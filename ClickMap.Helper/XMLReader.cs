using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ClickMap.Helper.External.Models;
using System.Web;

namespace ClickMap.Helper
{
    public class XMLReader
    {
        public List<Events> ReturnListOfEvents()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Developer Evaluation Events.xml");
            var xDocument = XElement.Load(xmlData);
            List<Events> events = Events.GetEvents(xDocument);

            return events;
        }

        public Events ReturnSpecificEvent(int Id)
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Developer Evaluation Events.xml");
            var xDocument = XElement.Load(xmlData);
            var events = Events.GetEvents(xDocument);
            var xEvent = (Events)(from e in events
                         where e.Id == Id
                         select e);
            return xEvent;
        }
    }
}
