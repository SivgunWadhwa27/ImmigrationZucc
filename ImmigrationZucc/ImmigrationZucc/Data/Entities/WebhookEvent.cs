using System;

namespace ImmigrationZucc.Data.Entities
{
    public class WebhookEvent
    {
        public long WebhookEventId { get; set; }
        public string SourceUri { get; set; }
        public string StreamCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}
