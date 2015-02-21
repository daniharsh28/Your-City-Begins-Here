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
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Text = Convert.ToString(Session["nameofUser"]);
            String url = @"http://localhost:14254/Service1.svc/GetNews/" + (String)Cache["city"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String result = reader.ReadToEnd();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(result);

            XmlNode root = xmlDoc.FirstChild;
            XmlNodeList Children = root.ChildNodes;
            int i = 0;
            int j = 0;
            int k = 0;
            string[] date = new string[10];
            string[] title = new string[10];
            string[] urls = new string[10];
            foreach (XmlNode Child in Children)
            {
                if (Child.Name.Equals("Date"))
                {
                    XmlNodeList dateChildren = Child.ChildNodes;
                    foreach (XmlNode dateChild in dateChildren)
                        date[i++] = dateChild.InnerText;
                }
                else if (Child.Name.Equals("TitleNoFormatting"))
                {
                    XmlNodeList titleChildren = Child.ChildNodes;
                    foreach (XmlNode titleChild in titleChildren)
                        title[j++] = titleChild.InnerText;
                }
                else if (Child.Name.Equals("Url"))
                {
                    XmlNodeList urlChildren = Child.ChildNodes;
                    foreach (XmlNode urlChild in urlChildren)
                        urls[k++] = urlChild.InnerText;
                }
            }

            Label5.Text = "<h2> News about " + (String)Cache["city"] + " </h2> <br><br>";

            for (int l = 0; l < 10; l++)
                Label5.Text += "<b>" + title[l] + "</b> <br>" + date[l] + "<br>" + urls[l] + "<br> <br>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page3.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exit.aspx");
        }
    }
}