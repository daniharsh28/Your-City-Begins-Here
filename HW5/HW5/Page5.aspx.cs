using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;

namespace HW5
{
    public partial class Page5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (String)Session["nameofUser"];
            Label2.Text = (String)Cache["city"];
            Label3.Text = " ";
            String url = @"http://localhost:3343/Service1.svc/GetNearestHospitals/" + (String) Cache["zipcode"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());
            String responsereader = reader.ReadToEnd();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responsereader);

            XmlNode root = xmlDoc.FirstChild;
            XmlNodeList Children = root.ChildNodes;
            int i = 0;
            int j = 0;
            string[] address = new string[10];
            string[] hospitals = new string[10];
            string city = "";
            foreach (XmlNode Child in Children)
            {
                if (Child.Name.Equals("address"))
                {
                    XmlNodeList addressChildren = Child.ChildNodes;
                    foreach (XmlNode addressChild in addressChildren)
                        address[i++] = addressChild.InnerText;
                }
                else if (Child.Name.Equals("name"))
                {
                    XmlNodeList nameChildren = Child.ChildNodes;
                    foreach (XmlNode nameChild in nameChildren)
                        hospitals[j++] = nameChild.InnerText;
                }
                else if (Child.Name.Equals("city"))
                    city = Child.InnerText;

                // Label3.Text = "<h2> Hospitals around " + city + "</h2>";
            }
                for (int k = 0; k < 9; k++)
                    Label3.Text += hospitals[k] + "<br> Address: " + address[k] + "<br><br>";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exit.aspx");
        }
    }
}