using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NearestHospitals
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetNearestHospitals/{zipcode}",
        ResponseFormat = WebMessageFormat.Xml)]
        Hospitals GetNearestHospitals(String zipcode);

        

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Hospitals
    {

        [DataMember]
        public string[] name;

        [DataMember]
        public string[] address;

        [DataMember]
        public string city;
    }
}
