using Buoi1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WikiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WikiController(IConfiguration configuration)
        {
            _configuration = configuration;
          
        }

        public async Task<IActionResult> GetAll()
        {
            new WikiAPI(_configuration).OnGet();
            return Ok("ss");
        }
    }
}
