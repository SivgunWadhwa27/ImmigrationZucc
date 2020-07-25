using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationZucc.Data.Entities
{
    public class Stream
    {
        public long StreamId { get; set; }
        public string Name { get; set; }
        public StreamType StreamType { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserStreamSubscription
    {
        public long UserStreamSubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
        public long StreamId { get; set; }
        public Stream Stream { get; set; }
        public DateTime? SubscribedDateTime { get; set; }
        public DateTime? CancelledDateTime { get; set; }
    }
}
