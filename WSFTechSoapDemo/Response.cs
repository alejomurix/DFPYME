using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSFTechSoapDemo.Response
{
    public class WsResponse
    {
        public string Code { set; get; }

        public string Success { set; get; }

        public string MsgError { set; get; }
    }

    public class UploadFileResponse : WsResponse 
    {
        public string TransaccionID { set; get; }
    }

    public class DocumentStatusFileResponse : WsResponse 
    {
        public string Status { set; get; }
    }
}