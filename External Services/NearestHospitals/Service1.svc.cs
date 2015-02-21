using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NearestHospitals
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Hospitals GetNearestHospitals(String zipcode)
        {
            Hospitals hs = new Hospitals();
            string url = @"https://maps.googleapis.com/maps/api/place/textsearch/xml?query=hospitals+around+" + zipcode + "&key=AIzaSyDEZ11XTH_9GYFuYLLqyENQqdyH77hQ51M";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader = reader.ReadToEnd();

            XmlDocument HospitalXml = new XmlDocument();
            HospitalXml.LoadXml(responsereader);
            int i = 0;
            hs.address = new string[10];
            hs.name = new string[10];

            XmlNodeList root = HospitalXml.ChildNodes;
            foreach (XmlNode child in root)
            {
                if (child.Name.Equals("PlaceSearchResponse"))
                {
                    XmlNodeList placesChildren = child.ChildNodes;
                    foreach (XmlNode placeChild in placesChildren)
                    {
                        if (placeChild.Name.Equals("result"))
                        {
                            XmlNodeList resultChildren = placeChild.ChildNodes;
                            foreach (XmlNode resultChild in resultChildren)
                            {
                                if (resultChild.Name.Equals("name"))
                                    hs.name[i] = resultChild.InnerText;
                                else if (resultChild.Name.Equals("formatted_address"))
                                {
                                    hs.address[i] = resultChild.InnerText;
                                    i = i + 1;
                                    if (i > 9)
                                        break;
                                }
                                if (i > 9)
                                    break;
                            }
                        }
                        if (i > 9)
                            break;
                    }
                }
            }

            string url1 = @"http://ziptasticapi.com/" + zipcode;
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            Stream responseStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(responseStream1);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader1 = reader1.ReadToEnd();
            dynamic data = JObject.Parse(responsereader1);
            hs.city = data.city + ","+ data.state+"," + data.country; 
            return hs;
        }   
       
    }
}
