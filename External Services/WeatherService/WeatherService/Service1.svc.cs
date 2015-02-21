using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] Weather5day(string zipcode)
        {
            //Information to call webservice.
            String city,state;
            string url1 = "http://api.wunderground.com/api/67c0482bed592b0c/geolookup/q/" + zipcode + ".xml";
            // Loading xml for zipcode
            XmlDocument xmldoc = new XmlDocument();
            string result = Response(url1);
            if (result.Equals("")) result = "error";
            else
                xmldoc.LoadXml(result);



            XmlNodeList city_xml = null;
            XmlNodeList state_xml = null;
            try
            {
                state_xml = xmldoc.GetElementsByTagName("state");
                city_xml = xmldoc.GetElementsByTagName("city");

            }
            catch (Exception e)
            {
                string[] temp = { "wrong Zipcode:Enter a valid zipcode" };
                return temp;
            }
            try
            {
                city = city_xml[0].InnerText;
                state = state_xml[0].InnerText;
                string url2 = "http://api.wunderground.com/api/67c0482bed592b0c/forecast10day/q/" + state + "/" + city + ".xml";
                result = Response(url2);
            }
            catch (Exception e)
            {
                string[] temp = { "wrong Zipcode:Enter a valid zipcode" };
                return temp;
            }

            //Xml representing weather 
            XmlDocument weather = new XmlDocument();

            if (result.Equals("")) result = "error";
            else
                weather.LoadXml(result);


            //Extracting a subpart of xml and giving it a new XmlDocument
            XmlNodeList simpleforecast = weather.GetElementsByTagName("simpleforecast");
            XmlDocument sub_weather = new XmlDocument();

            sub_weather.LoadXml(simpleforecast[0].InnerXml);

            XmlNodeList day, month, year, weekday, high_temp, low_temp, conditions, temp_f;

            try
            {
                day = sub_weather.GetElementsByTagName("day");
                month = sub_weather.GetElementsByTagName("month");
                year = sub_weather.GetElementsByTagName("year");
                weekday = sub_weather.GetElementsByTagName("weekday");
                high_temp = sub_weather.GetElementsByTagName("high");
                low_temp = sub_weather.GetElementsByTagName("low");
                conditions = sub_weather.GetElementsByTagName("conditions");
            }
                
            finally
            {

            }

            string[] returnResult = new string[5];

            for (int i = 0; i < 5; i++)
            {
                returnResult[i] = "Date:"+day[i].InnerText +" "+ month[i].InnerText+" " + year[i].InnerText +"\n"+ weekday[i].InnerText +
                    " high:"+high_temp[i].ChildNodes[0].InnerText + "f " + high_temp[i].ChildNodes[1].InnerText + "C " +
                    "low:"+low_temp[i].ChildNodes[0].InnerText +"f " + low_temp[i].ChildNodes[1].InnerText +"C\n" +"Conditions:"+conditions[i].InnerText+"\n";
            }

            return returnResult;

        }


        static string Response(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                result = reader.ReadToEnd();
                return result;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());

            }
            return result;

        }


    }
}
