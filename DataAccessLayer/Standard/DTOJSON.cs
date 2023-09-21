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
}
