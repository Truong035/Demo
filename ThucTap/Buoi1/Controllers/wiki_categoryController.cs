using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class wiki_categoryController : ControllerBase
    {
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
