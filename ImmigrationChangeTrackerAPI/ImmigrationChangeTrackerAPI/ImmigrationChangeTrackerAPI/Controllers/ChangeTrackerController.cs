using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ImmigrationChangeTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeTrackerController : ControllerBase
    {
        public ChangeTrackerController()
        {
            
        }

        [HttpPost]
        public IActionResult PostChange([FromBody] DistillResponse response)
        {
            var x = JsonConvert.DeserializeObject<JsonResponse>(response.props.ToString());

            return Ok(response);
        }
    }

    public class DistillResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public object props { get; set; }
        public List<string> GetStringDiff()
        {
            string s1 = "i have a car a car";
            string s2 = "i have a new car bmw";

            List<string> diff;
            IEnumerable<string> set1 = s1.Split(' ').Distinct();
            IEnumerable<string> set2 = s2.Split(' ').Distinct();

            if (set2.Count() > set1.Count())
            {
                diff = set2.Except(set1).ToList();
            }
            else
            {
                diff = set1.Except(set2).ToList();
            }
            return diff;
        }
    }

    public class JsonResponse
    {
        public string id { get; set; }
        public string data { get; set; }
        public string text { get; set; }
        public string ts { get; set; }
    }
}
