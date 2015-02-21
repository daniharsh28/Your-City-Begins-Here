using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wrapper_Theatre
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetTheatres/{cityName}",
        ResponseFormat = WebMessageFormat.Xml)]
        Theatres GetTheatres(string cityName);
        
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Theatres
    {
        [DataMember]
        public string[] name;

        [DataMember]
        public string[] address;

        [DataMember]
        public string[] movies;

        [DataMember]
        public string[] reviews;
    }
}
