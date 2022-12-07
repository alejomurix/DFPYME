using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSFTechSoapPro.WSFTECHPRO;

namespace WSFTechSoapPro
{
    public class WSFTechSPro
    {
        private readonly WSV2PROSoapClient wsClient;

        private response_ws _response_ws;

        private response_docs _response_docs;

        public WSFTechSPro()
        {
            this.wsClient = new WSV2PROSoapClient();
        }

        public UploadFileResponse UploadInvoiceFile(string userName, string password, string xmlBase64)
        {
            _response_ws = wsClient.uploadInvoiceFile(userName, password, xmlBase64);
            return new UploadFileResponse
            {
                Code = _response_ws.code,
                Success = _response_ws.success,
                TransaccionID = _response_ws.transaccionID,
                MsgError = _response_ws.Msgerror
            };
        }

        public DocumentStatusFileResponse DocumentStatusFile(string userName, string password, string transaccionID)
        {
            _response_docs = wsClient.documentStatusFile(userName, password, transaccionID);
            return new DocumentStatusFileResponse
            {
                Code = _response_docs.code,
                Success = _response_docs.success,
                Status = _response_docs.status,
                MsgError = _response_docs.Msgerror
            };
        }
    }
}