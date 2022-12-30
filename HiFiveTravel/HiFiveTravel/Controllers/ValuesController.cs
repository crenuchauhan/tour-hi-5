using HiFiveTravel.Interfaces;
using HiFiveTravel.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace HiFiveTravel.Controllers
{
    [Route("HiFitravel")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly ISendEnquiry _sendEnquiry;

        public ValuesController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment,ISendEnquiry sendEnquiry)
        {
            _configuration = configuration;
            _env = webHostEnvironment;
            _sendEnquiry = sendEnquiry;
        }

        [HttpPost("SendEnquiry")]
        public IActionResult SendEnquiryMailToAgency(Information info)
        {



            var out_msg = this._sendEnquiry.SendEnquiryMailToAgency(info);
            if (out_msg == "success")
            {
                return Ok(new { msg = "Mail Send" });

            }
            else
            {
                return NotFound(new { msg = out_msg });
            }

        }
    }
}
