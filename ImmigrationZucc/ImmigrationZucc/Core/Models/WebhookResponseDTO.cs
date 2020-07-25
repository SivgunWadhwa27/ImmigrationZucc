using ImmigrationZucc.Core.Enums;

namespace ImmigrationZucc.Core.Models
{
    public class WebhookResponseDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string streamCode { get; set; }
        public object data { get; set; }
    }
}
