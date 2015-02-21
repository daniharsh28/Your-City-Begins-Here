using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
namespace TrafficeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Traffic GetTraffic(string zipcode)
        {
            Traffic tr = new Traffic();

            string url = @"http://maps.googleapis.com/maps/api/geocode/json?address="+zipcode+"&sensor=true";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader = reader.ReadToEnd();
             String northeast_lat = "";
             String northeast_lng = "";
            dynamic data = JObject.Parse(responsereader);
            try
            {
                northeast_lat = data.results[0].geometry.bounds.northeast.lat;
            }
            catch (Exception e) { }
            finally
            {
                northeast_lat = data.results[0].geometry.viewport.northeast.lat;
            }
            try
            {
                 northeast_lng = data.results[0].geometry.bounds.northeast.lng;
            }
            catch (Exception e) { }
            finally
            {
                northeast_lng = data.results[0].geometry.viewport.northeast.lng;
            }
            String southwest_lat = "";
            String southwest_lng = "";
            try
            {
                 southwest_lat = data.results[0].geometry.bounds.southwest.lat;
            }
            catch (Exception e) { }
            finally
            {
                southwest_lat = data.results[0].geometry.viewport.southwest.lat;
            }
            try
            {
                 southwest_lng = data.results[0].geometry.bounds.southwest.lng;
            }
            catch (Exception e) { }
            finally
            {
                southwest_lng = data.results[0].geometry.viewport.southwest.lng;
            }
            String url1 = @"http://www.mapquestapi.com/traffic/v2/incidents?key=Fmjtd%7Cluurn96yn5%2C8l%3Do5-9w8w5r&callback=handleIncidentsResponse&boundingBox="+northeast_lat+","+northeast_lng+","+southwest_lat+","+southwest_lng+"&filters=construction,incidents&inFormat=kvp&outFormat=xml";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
            WebResponse response1 = request1.GetResponse();
            Stream responseStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(responseStream1);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader1 = reader1.ReadToEnd();

            XmlDocument TrafficXml = new XmlDocument();
            TrafficXml.LoadXml(responsereader1);

            XmlNodeList incidentList = TrafficXml.GetElementsByTagName("Incident");
            tr.fullDesc = new string[incidentList.Count];
            tr.endTime = new string[incidentList.Count];
            tr.startTime = new string[incidentList.Count];
            int i=0;
            int j=0;
            int k=0;
            foreach (XmlNode incident in incidentList)
            {
                XmlNodeList incidentChildren = incident.ChildNodes;
                foreach (XmlNode incidentChild in incidentChildren)
                {
                    if (incidentChild.Name.Equals("startTime"))
                        tr.startTime[i++] = incidentChild.InnerText;
                    else if (incidentChild.Name.Equals("endTime"))
                        tr.endTime[j++] = incidentChild.InnerText;
                    else if (incidentChild.Name.Equals("fullDesc"))
                        tr.fullDesc[k++] = incidentChild.InnerText;
                }
            }
            return tr;
        }
    }
}
