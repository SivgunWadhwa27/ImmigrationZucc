using ImmigrationZucc.Data;
using ImmigrationZucc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ImmigrationZucc.Infrastructure.Repositories
{
    public interface IUserStreamSubscriptionRepository
    {
        IQueryable<UserStreamSubscription> GetUsersSubscribedToStream(long streamId);
        List<string> GetStreamSubscribersPhoneNumbers(long streamId);
    }

    public class UserStreamSubscriptionRepository : IUserStreamSubscriptionRepository
    {
        private ApplicationDbContext _context;
        public UserStreamSubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<UserStreamSubscription> GetUsersSubscribedToStream(long streamId)
        {
            var userStreamSubscriptions = _context.UserStreamSubscriptions
                .Where(o =>
                    o.StreamId == streamId
                    && o.SubscribedDateTime != null
                    && o.CancelledDateTime == null
                ).Include(o => o.User);

            return userStreamSubscriptions;
        }

        public List<string> GetStreamSubscribersPhoneNumbers(long streamId)
        {
            var subscriberPhoneNumbers = GetUsersSubscribedToStream(streamId)
                .Select(o => o.User.PhoneNumber)
                .ToList();

            return subscriberPhoneNumbers;
        }
    }
}
