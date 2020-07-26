using ImmigrationZucc.Infrastructure.Repositories;
using ImmigrationZucc.Infrastructure.Utilities;
using System.Threading.Tasks;

namespace ImmigrationZucc.Infrastructure.Services
{
    public interface IUpdateNotificationService
    {
        Task SendUpdateNotifications(long streamId, string changedText);
    }

    public class UpdateNotificationService : IUpdateNotificationService
    {
        private IUserStreamSubscriptionRepository _userStreamSubscription; 
        private IStreamRepository _stream; 
        public UpdateNotificationService(IUserStreamSubscriptionRepository userStreamSubscription, IStreamRepository stream)
        {
            _userStreamSubscription = userStreamSubscription;
            _stream = stream;
        }

        public async Task SendUpdateNotifications(long streamId, string changedText)
        {
            //get the users who subscribe to this -> get their phone numbers
            var subscriberPhoneNumberList = _userStreamSubscription.GetStreamSubscribersPhoneNumbers(streamId);

            //generate the diff compared to last update from the website
            var stream = _stream.GetById(streamId);
            var diff = DiffMatchPatchUtil.GetPatchedString(stream.TextBlob, changedText);

            //send out the messages

        }
    }

}
