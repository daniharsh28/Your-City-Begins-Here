using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace HW5
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie nameCookie = new HttpCookie("mycookie");
            if (TextBox1.Text.Equals(""))
            {
                nameCookie["nameofUser"] = "Default User";
                Session["nameOfUser"] = "Default User";
            }
            else
            {
                nameCookie["nameOfUser"] = TextBox1.Text;
                Session["nameOfUser"] = TextBox1.Text;
            }
            if (Cache["zipcode"] == null || Cache["city"] == null) // If caches are empty then go and check for it! 
            { // Otherwise use its value in next pages.
                String url = @"http://www.ziptasticapi.com/" + TextBox2.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                String result = reader.ReadToEnd();
                dynamic finalresult = JObject.Parse(result);
                Label1.Text = finalresult.city;
                Cache["zipcode"] = TextBox2.Text;
                Cache["city"] = finalresult.city.ToString();
            }
            Response.Redirect("Page1.aspx");
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exit.aspx");
        }
    }
}