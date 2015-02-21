using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        string url = @"http://localhost:5965/Service1.svc/GetTraffic/"+TextBox1.Text;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);
        //Console.WriteLine(reader.ReadToEnd());
        String responsereader = reader.ReadToEnd();

        XmlDocument outputXml = new XmlDocument();
        outputXml.LoadXml(responsereader);

        XmlNode root = outputXml.FirstChild;
        XmlNodeList Children = root.ChildNodes;
        string endtime = "";
        string starttime = "";
        string fulldesc = "";
        string[] starttimesplitted; 
        string[] endtimesplitted; 
        string[] fullDescsplitted;
        foreach (XmlNode child in Children)
        {
            if (child.Name.Equals("endTime"))
            {
                XmlNodeList endTimeChildren = child.ChildNodes;
                foreach (XmlNode endTimeChild in endTimeChildren)
                    endtime += endTimeChild.InnerText + "^";
            }
            else if (child.Name.Equals("startTime"))
            {
                XmlNodeList startTimeChildren = child.ChildNodes;
                foreach (XmlNode startTimeChild in startTimeChildren)
                    starttime += startTimeChild.InnerText + "^";
            }
            else if (child.Name.Equals("fullDesc"))
            {
                XmlNodeList fullDescChildren = child.ChildNodes;
                foreach (XmlNode fullDescChild in fullDescChildren)
                    fulldesc += fullDescChild.InnerText + "^";
            }
        }
            starttimesplitted = starttime.Split('^');
            endtimesplitted = endtime.Split('^');
            fullDescsplitted = fulldesc.Split('^');
        
            Label1.Text += "<h2> Traffic Around " + TextBox1.Text + "</h2> </br>";

            for (int p = 0; p < starttimesplitted.Length-1; p++)
            {
                Label1.Text += "<b>" + fullDescsplitted[p] + "</b></br> Start-Time:" + starttimesplitted[p] + "</br> End-Time:" + endtimesplitted[p] + "</br></br>";
            }
        
    }
}