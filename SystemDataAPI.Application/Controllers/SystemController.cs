using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SystemDataAPI.Application.Controllers
{
    [Route("system")]
    public class SystemController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var systemInfo = new
            {
                SystemPlatform = Environment.OSVersion.Platform.ToString(),
                SystemVersion = Environment.OSVersion.Version.ToString(),
                HostName = Environment.MachineName
            };

            return Ok(systemInfo);
        }

        [HttpGet("status/{id}")]
        public IActionResult GetStatus(int id)
        {
            if (id == 0)
            {
                return StatusCode(500, "O sistema ta zuado");
            }

            return Ok("Tudo ok por aqui");
        }
    }
}
