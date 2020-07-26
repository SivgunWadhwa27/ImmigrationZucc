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
        private IStreamRepository _stream;
        public WebhookController(
            IUpdateNotificationService updateNotificationService,
            ApplicationDbContext context,
            IStreamRepository stream
        )
        {
            _updateNotificationService = updateNotificationService;
            _context = context;
            _stream = stream;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WebhookResponseDTO response)
        {
            var distillChangeDTO = JsonConvert.DeserializeObject<DistillChangeDTO>(response.data.ToString());

            //log webhook event
            var webhookEvent = new WebhookEvent()
            {
                StreamCode = response.streamCode,
                SourceUri = response.uri,
                DateTime = DateTime.UtcNow
            };
            _context.WebhookEvents.Add(webhookEvent);
            _context.SaveChanges();


            var stream = _stream.GetByStreamCode(response.streamCode);
            //get the users who subscribe to this -> get their phone numbers

            await _updateNotificationService.SendUpdateNotifications(stream.StreamId, distillChangeDTO.text);
            //get the diff compared to last update from the website
            
            //send out the messages

            return Ok();
        }
    }
}