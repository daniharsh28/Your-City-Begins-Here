using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Drawing;

namespace PopularPlaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] findPlace(string cityName)
        {
            string[] add=new string[20];
            string[] storeName = cityName.Split(' ');
            string store = null;
            for (int i = 0; i < storeName.Length; i++)
            {
                if (i == storeName.Length - 1)
                {
                    store += storeName[i];
                }
                else
                {
                    store += storeName[i] + "+";
                }
            }
            string url = @"https://maps.googleapis.com/maps/api/place/textsearch/xml?query=tourist+place+in+" + cityName + "&key";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            XmlNodeList result = xmldoc.GetElementsByTagName("PlaceSearchResponse");
            XmlNodeList photo = xmldoc.GetElementsByTagName("photo");
           /* byte[] bytes = Convert.FromBase64String(photo[0].ChildNodes[0].InnerText);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }*/

            string place = "";
            if (result[0].ChildNodes[0].InnerText.Equals("OK"))
            {
                XmlNodeList places = xmldoc.GetElementsByTagName("result");
                XmlNodeList address = xmldoc.GetElementsByTagName("formatted_address");
                
                for (int i = 0; i < 20; i++)
                {
                     add[i] = Convert.ToString(places[i].ChildNodes[0].InnerText);
                     add[i+1] = Convert.ToString(address[i].ChildNodes[0].InnerText);
                     i++;
                   
                }
               
                return add;
            }
            else
            {
                string[] str = new string[1];
                str[0] = "Your search city is not availble.";
                return str;
            }
        }
    }
}