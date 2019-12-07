using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Negocio.Response
{
    [DataContract]
    public class Response
    {
        public Response()
        {
            this.Status = ResponseStatus.Success;
        }
        public Response(Exception currentException)
        {

            this.CurrentException = currentException.ToString();
            Status = ResponseStatus.Failed;
        }
        public Response(string currentException)
        {
            this.CurrentException = currentException;
            Status = ResponseStatus.Failed;
        }
        public Response(string format, params object[] args)
        {
            this.CurrentException = string.Format(format, args);
            Status = ResponseStatus.Failed;
        }

        [DataMember]
        public ResponseStatus Status { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string CurrentException { get; set; }
    }
}
