using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Wrapper_Theatre
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Theatres GetTheatres(String yourCity)
        {
            Theatres tr = new Theatres();
            string[] split = yourCity.Split(' ');
            string city = null;
            for(int k = 0; k< split.Length; k++)
            {
                if (k == split.Length - 1)
                    city += split[k];
                else
                    city += split[k] + "+";
                
            }
            string url = @"https://maps.googleapis.com/maps/api/place/textsearch/xml?query=movie+theatre+in+"+city+"&types=movie_theater&key=";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader = reader.ReadToEnd();

            XmlDocument TheatreXml = new XmlDocument();
            TheatreXml.LoadXml(responsereader);
            int i = 0;
            tr.address = new string[5];
            tr.name = new string[5];
            tr.movies = new string[5];
            tr.reviews = new string[5];
            XmlNodeList root = TheatreXml.ChildNodes;
            foreach(XmlNode child in root)
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
                                    tr.name[i] = resultChild.InnerText;
                                else if (resultChild.Name.Equals("formatted_address"))
                                {
                                    tr.address[i] = resultChild.InnerText;
                                    i = i + 1;
                                    if (i > 4)
                                        break;
                                }
                                if (i > 4)
                                    break;
                            }
                        }
                        if (i > 4)
                            break;
                    }
                }
            }
            String url1 = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey=&page=1";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
            WebResponse response1 = request1.GetResponse();
            Stream responseStream1 = response1.GetResponseStream();
            StreamReader reader1 = new StreamReader(responseStream1);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader1 = reader1.ReadToEnd();
            dynamic movie = JObject.Parse(responsereader1);
            for (int p = 0; p < 5; p++)
            {
                tr.movies[p] = movie.movies[p].title;
                tr.reviews[p] = movie.movies[p].ratings.audience_score;
            }
            return tr;



        }
    }
}
