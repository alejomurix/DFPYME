using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Standard
{
    public class DTOJSON
    {
        [JsonPropertyName("actions")]
        public Action Action { set; get; }

        [JsonPropertyName("invoice")]
        public Heading Invoice { set; get; }
    }

    public class Action
    {
        [JsonPropertyName("send_dian")]
        public bool SendDian { get => false; }

        [JsonPropertyName("send_email")]
        public bool SendEmail { get => false; }
    }


    public class ErrorResponse
    {
        private System.Text.StringBuilder sb;
        public Error[] errors { set; get; }

        public class Error
        {
            public string[] path { set; get; }
            public string error { set; get; }
        }

        public override string ToString()
        {
            sb = new System.Text.StringBuilder();
            foreach (var e in errors)
            {
                foreach (var p in e.path)
                {
                    sb.Append(p);
                    sb.Append(" | ");
                }
                sb.Append("\n");
                sb.Append(e.error);
            }
            return sb.ToString();
        }
    }

    public class InvoiceResponse
    {
        private Dictionary<string, int> dianStatus;

        public InvoiceResponse()
        {
            dianStatus = new Dictionary<string, int>();
            dianStatus.Add("DIAN_NO_ENVIADO", 1);
            dianStatus.Add("DIAN_ACEPTADO", 2);
            dianStatus.Add("DIAN_RECHAZADO ", 3);
            dianStatus.Add("DIAN_ERROR", 4);
        }

        public int DianStatus
        {
            get
            {
                if(dianStatus.TryGetValue(dian_status, out int status))
                {
                    return status;
                }
                return 4;
            }
        }

        public string uuid { set; get; }

        public string dian_status { set; get; }

        public string qrcode { set; get; }

        public string cufe { set; get; }

        public string pdf_url { set; get; }
    }
}
