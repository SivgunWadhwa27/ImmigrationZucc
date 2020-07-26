using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImmigrationZucc.Core.Models;
using ImmigrationZucc.Data;
using ImmigrationZucc.Data.Entities;
using ImmigrationZucc.Infrastructure.Repositories;
using ImmigrationZucc.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImmigrationZucc.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private IUpdateNotificationService _updateNotificationService;
        private ApplicationDbContext _context;
        private IWebhookEventRepository _webhookEvent;

        public WebhookController(
            IUpdateNotificationService updateNotificationService,
            ApplicationDbContext context,
            IWebhookEventRepository webhookEvent
        )
        {
            _updateNotificationService = updateNotificationService;
            _context = context;
            _webhookEvent = webhookEvent;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WebhookResponseDTO response)
        {
            //log webhook event
            _webhookEvent.Insert(response.streamCode, response.uri);
            _context.SaveChanges();

            var distillChangeDTO = JsonConvert.DeserializeObject<DistillChangeDTO>(response.data.ToString());
            await _updateNotificationService.SendUpdateNotifications(response.streamCode, distillChangeDTO.text);

            return Ok();
        }
    }
}