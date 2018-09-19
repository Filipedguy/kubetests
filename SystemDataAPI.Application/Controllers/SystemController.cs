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
        private FailureHelper _failure;

        public SystemController(FailureHelper failure)
        {
            _failure = failure;
        }

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

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            if (_failure.IsFailing)
            {
                return StatusCode(500, "O sistema falhou");
            }

            return Ok("Tudo ok por aqui");
        }

        [HttpGet("status/fail")]
        public IActionResult SetStatusFail()
        {
            _failure.IsFailing = true;

            return Ok("Setando varíavel de falha para verdadeiro!!!");
        }

        [HttpGet("status/recover")]
        public IActionResult SetStatusRecover()
        {
            _failure.IsFailing = false;

            return Ok("Setando varíavel de falha para falso!!!");
        }
    }
}
