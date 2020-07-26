using ImmigrationZucc.Infrastructure.Configuration;
using ImmigrationZucc.Infrastructure.Repositories;
using ImmigrationZucc.Infrastructure.Utilities;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ImmigrationZucc.Infrastructure.Services
{
    public interface IUpdateNotificationService
    {
        Task SendUpdateNotifications(string streamCode, string changedText);
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

        public async Task SendUpdateNotifications(string streamCode, string changedText)
        {
            //get the stream
            var stream = _stream.GetByStreamCode(streamCode);

            //get the users who subscribe to this -> get their phone numbers
            var subscriberPhoneNumberList = _userStreamSubscription.GetStreamSubscribersPhoneNumbers(stream.StreamId);

            //generate the diff compared to last update from the website
            var diff = DiffMatchPatchUtil.GetPatchedString(stream.TextBlob, changedText);

            //send out the messages
            TwilioClient.Init(AppSettings.TwilioSettings.AccountSid, AppSettings.TwilioSettings.AuthToken);
            foreach(var phoneNumber in subscriberPhoneNumberList)
            {
                var message = await MessageResource.CreateAsync(
                    body: $"\"{diff}\". Go to {stream.Url}",
                    from: new Twilio.Types.PhoneNumber( AppSettings.TwilioSettings.PhoneNumber),
                    to: new Twilio.Types.PhoneNumber($"+1{phoneNumber}")
                );
            }
        }
    }

}
