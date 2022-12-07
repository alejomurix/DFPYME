using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSFTechSoapDemo
{
    public class WSFTechSoap
    {
        private readonly WSFTech.WSV2DEMOSoapClient wsClient;

        //private readonly WSFTech.FtechActionuploadInvoiceFileRequest ws;

        private WSFTech.response_ws _response_ws;

        private WSFTech.response_docs _response_docs;

        public WSFTechSoap()
        {
            this.wsClient = new WSFTech.WSV2DEMOSoapClient();
        }

        public Response.UploadFileResponse UploadInvoiceFile(string userName, string password, string xmlBase64)
        {
            _response_ws = wsClient.uploadInvoiceFile(userName, password, xmlBase64);
            return new Response.UploadFileResponse
            {
                Code = _response_ws.code,
                Success = _response_ws.success,
                TransaccionID = _response_ws.transaccionID,
                MsgError = _response_ws.Msgerror
            };
        }

        public Response.DocumentStatusFileResponse DocumentStatusFile(string userName, string password, string transaccionID)
        {
            _response_docs = wsClient.documentStatusFile(userName, password, transaccionID);
            return new Response.DocumentStatusFileResponse
            {
                Code = _response_docs.code,
                Success = _response_docs.success,
                Status = _response_docs.status,
                MsgError = _response_docs.Msgerror
            };
        }
    }
}