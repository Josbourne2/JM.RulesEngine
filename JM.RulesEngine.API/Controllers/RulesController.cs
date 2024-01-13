using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;

namespace JM.RulesEngine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly ILogger<RulesController> _logger;
        private readonly IHttpContextAccessor _context;

        public RulesController(ILogger<RulesController> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        [Route("EvaluateRules")]
        public async Task<IActionResult> EvaluateRules ()
        {

            var rawRequestBody = await Request.GetRawBodyAsync();

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(rawRequestBody)!;

            string references = dynamicObject.References;
            

            _logger.LogInformation(rawRequestBody);
            var temp = (decimal)dynamicObject.Measurements.TEMP.Value;
            _logger.LogInformation(temp.ToString());
            //var jsonString = _context.HttpContext.Request.Body;
            
            //var jsonString = ((System.Text.Json.JsonElement)input).ToString();


            //var whatAreWeLookingAt = JsonConvert.DeserializeObject<DynamicBase>(jsonString);
            //var type = whatAreWeLookingAt.References;

           


            


            ////var data = JsonConvert.DeserializeObject<ding>   (jsonString);

            

            //await Console.Out.WriteLineAsync(jsonString);
            
            //var dinges = JsonConvert.DeserializeObject<dynamic> (jsonString)!;
            //var references = dinges.References;

            //var baseObject = JsonConvert.DeserializeObject<DynamicBase>(input);


            //var references = baseObject.References;



            return Ok(dynamicObject);
        }
    }
}
