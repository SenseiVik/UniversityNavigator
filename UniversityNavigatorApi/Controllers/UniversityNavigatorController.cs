using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UniversityNavigatorApi.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class UniversityNavigatorController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            return await Task.Factory.StartNew(() => Ok());
        }

    }
}
