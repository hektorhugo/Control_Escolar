using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Negocio.Response
{
    [DataContract]
    public class ResponseGeneric<T> : Response
    {
        public ResponseGeneric(T returnObject) : base()
        {
            this.Response = returnObject;
            CurrentException = null;
            Status = ResponseStatus.Success;
        }
        public ResponseGeneric(Exception currentException) : base(currentException)
        {
            Response = default(T);
            Status = ResponseStatus.Failed;
        }
        public ResponseGeneric(string currentException) : base(currentException)
        {
            Response = default(T);
            Status = ResponseStatus.Failed;
        }
        public ResponseGeneric(string format, params object[] args) : base(format, args)
        {
            Response = default(T);
            Status = ResponseStatus.Failed;

        }
        [DataMember]
        public T Response { get; set; }
    }
}
