using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HW5.Weather;

namespace HW5
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie cookie = new HttpCookie("mycookie");
            Label1.Text = Convert.ToString(Session["nameofUser"]);

            Service1Client weather = new Service1Client();
            String[] weatherOutput = new String[5];
            weatherOutput = weather.Weather5day((String)Cache["zipcode"]);
            Label2.Text = (String) Cache["city"];

            Label3.Text = "";
            for (int i = 0; i < 5; i++)
                Label3.Text += "<b>" + weatherOutput[i] + " <b/> <br/>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exit.aspx");
        }
    }
}