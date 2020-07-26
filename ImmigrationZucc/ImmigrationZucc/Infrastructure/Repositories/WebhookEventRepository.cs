using ImmigrationZucc.Data;
using ImmigrationZucc.Data.Entities;
using System;

namespace ImmigrationZucc.Infrastructure.Repositories
{
    public interface IWebhookEventRepository
    {
        void Insert(string streamCode, string uri);
    }

    public class WebhookEventRepository : IWebhookEventRepository
    {
        private ApplicationDbContext _context;
        public WebhookEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Insert(string streamCode, string uri)
        {
            var webhookEvent = new WebhookEvent()
            {
                StreamCode = streamCode,
                SourceUri = uri,
                DateTime = DateTime.UtcNow
            };

            _context.WebhookEvents.Add(webhookEvent);
        }
    }
}
