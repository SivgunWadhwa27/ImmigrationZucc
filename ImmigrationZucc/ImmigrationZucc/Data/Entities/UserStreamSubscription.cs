using Microsoft.AspNetCore.Identity;
using System;

namespace ImmigrationZucc.Data.Entities
{
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
