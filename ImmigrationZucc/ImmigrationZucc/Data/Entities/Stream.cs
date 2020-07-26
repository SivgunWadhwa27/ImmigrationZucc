using System;

namespace ImmigrationZucc.Data.Entities
{
    public class Stream
    {
        public long StreamId { get; set; }
        public string Name { get; set; }
        public string StreamCode { get; set; }
        public DateTime? UpdatedOnDateTime { get; set; }
        public string TextBlob { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
    }
}
