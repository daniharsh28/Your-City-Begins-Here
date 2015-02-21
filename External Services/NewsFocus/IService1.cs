using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsFocus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [WebGet(UriTemplate = "/GetNews/{yourCity}",
        ResponseFormat = WebMessageFormat.Xml)]
        News GetNews(String yourCity);

    }
    [DataContract]
    public class News
    {
        [DataMember]
        public String[] TitleNoFormatting { get; set;}

        [DataMember]
        public string[] Date { get; set;}

        [DataMember]
        public string[] Url { get; set;}
    }
}
