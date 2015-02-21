using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace NewsFocus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public News GetNews(String yourCity)
        {
            News nw = new News();
            
            string url = @"https://news.google.com/news/feeds?q="+yourCity+"&output=rss";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader = reader.ReadToEnd();

            XmlDocument newsXml = new XmlDocument();
            newsXml.LoadXml(responsereader);

            XmlNode rootUp = newsXml.FirstChild;
            XmlNode rootChannel = rootUp.FirstChild;
            XmlNodeList root = rootChannel.ChildNodes;
            int i = 0;
            nw.TitleNoFormatting = new string[root.Count-10];
            nw.Date = new string[root.Count-10];
            nw.Url = new string[root.Count-10];
            foreach (XmlNode node in root)
            {
                if(node.Name.Equals("item"))
                {
                    
                    XmlNodeList children = node.ChildNodes;
                    foreach (XmlNode child in children)
                    { 
                        if (child.Name.Equals("title"))
                        {
                            nw.TitleNoFormatting[i] = child.InnerText;
                           
                        }
                        else if (child.Name.Equals("pubDate"))
                        {
                            nw.Date[i] = child.InnerText;
                            i = i + 1;
                        }
                        else if(child.Name.Equals("guid"))
                        {
                            String[] temp = child.InnerText.Split('=');
                            nw.Url[i] = temp[1];
                            
                        }
                    }
                }
            }
             return nw;
            //XmlNodeList itemList = subXml.GetElementsByTagName("item");

           
           
        }
    }
}
