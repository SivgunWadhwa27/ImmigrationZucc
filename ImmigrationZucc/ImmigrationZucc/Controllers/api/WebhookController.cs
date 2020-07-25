using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImmigrationZucc.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImmigrationZucc.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        public WebhookController()
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody] WebhookResponseDTO response)
        {
            var distillChangeDTO = JsonConvert.DeserializeObject<DistillChangeDTO>(response.data.ToString());

            //get the users who subscribe to this -> get their phone numbers

            //generate the diff compared to last update from the website

            return Ok();
        }
    }
}