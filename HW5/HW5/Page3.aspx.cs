using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Net;

namespace HW5
{
    public partial class Page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(Session["nameofUser"]);
            Label2.Text = Convert.ToString(Cache["city"]);
            string url = @"http://localhost:62925/Service1.svc/findPlace/" + (String)Cache["city"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String result = reader.ReadToEnd();
            response.Close();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(result);
            XmlNodeList places = xmldoc.GetElementsByTagName("ArrayOfstring");
            /* byte[] bytes = Convert.FromBase64String(places[0].ChildNodes[9].InnerText);

             System.IO.MemoryStream streamBitmap = new
           System.IO.MemoryStream(bytes);
             Bitmap bitImage = new
                  Bitmap((Bitmap)Image.FromStream(streamBitmap));*/

            if (!places[0].ChildNodes[0].InnerText.Equals("Your search city is not available"))
            {
                Place1.Text = "1. \"" + places[0].ChildNodes[0].InnerText + "\" is located at " + places[0].ChildNodes[1].InnerText;
                Place2.Text = "2. \"" + places[0].ChildNodes[2].InnerText + "\" is located at " + places[0].ChildNodes[3].InnerText; ;
                Place3.Text = "3. \"" + places[0].ChildNodes[4].InnerText + "\" is located at " + places[0].ChildNodes[5].InnerText; ;
                Place4.Text = "4. \"" + places[0].ChildNodes[6].InnerText + "\" is located at " + places[0].ChildNodes[7].InnerText; ;
                Place5.Text = "5. \"" + places[0].ChildNodes[8].InnerText + "\" is located at " + places[0].ChildNodes[9].InnerText; ;
                Place6.Text = "6. \"" + places[0].ChildNodes[10].InnerText + "\" is located at " + places[0].ChildNodes[11].InnerText; ;
                Place7.Text = "7. \"" + places[0].ChildNodes[12].InnerText + "\" is located at " + places[0].ChildNodes[13].InnerText; ;
                Place8.Text = "8. \"" + places[0].ChildNodes[14].InnerText + "\" is located at " + places[0].ChildNodes[15].InnerText; ;
                Place9.Text = "9. \"" + places[0].ChildNodes[16].InnerText + "\" is located at " + places[0].ChildNodes[17].InnerText; ;
                Place10.Text = "10. \"" + places[0].ChildNodes[18].InnerText + "\" is located at " + places[0].ChildNodes[19].InnerText; ;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page4.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exit.aspx");
        }
    }
}