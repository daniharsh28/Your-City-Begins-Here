using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
            Label1.Text = " ";
            String url = @"http://10.1.11.142:8001/Service1.svc/GetTheatres/"+TextBox1.Text;
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
            int p = 0;
            int q = 0;
            string[] address = new string[5];
            string[] theatres = new string[5];
            string [] movies = new string[5];
            string [] audience_scores = new string[5];
            foreach(XmlNode Child in Children ){
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
                        theatres[j++] = nameChild.InnerText;
                }
                else if (Child.Name.Equals("movies")) 
                {
                    XmlNodeList movieChildren = Child.ChildNodes;
                    foreach (XmlNode movieChild in movieChildren)
                        movies[p++] = movieChild.InnerText;

                }
                else if (Child.Name.Equals("reviews"))
                {
                    XmlNodeList reviewsChildren = Child.ChildNodes;
                    foreach (XmlNode reviewChild in reviewsChildren)
                        audience_scores[q++] = reviewChild.InnerText;
                }
            }

        Label1.Text = "<h2> Theatres around "+ TextBox1.Text + "</h1>";

        for (int k = 0; k < 5; k++)
            Label1.Text += theatres[k] + "<br> Address: " + address[k] + "<br><br>";

        Label1.Text += "<br> <br>"+ " <h2> Currently Running Movies  </h2>";

        for(int r=0;r<5; r++)
            Label1.Text += movies[r] + "<br>" + "Audience Score :" + audience_scores[r]+ "<br><br>";

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}