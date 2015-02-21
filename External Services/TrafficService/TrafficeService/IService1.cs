using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrafficeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetTraffic/{zipcode}",
        ResponseFormat = WebMessageFormat.Xml)]
        Traffic GetTraffic(string zipcode);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Traffic
    {
        
        [DataMember]
        public string[] fullDesc;

        [DataMember]
        public string[] endTime;

        [DataMember]
        public string[] startTime;
    }
}
