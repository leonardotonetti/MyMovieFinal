﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyMovie.Api.Controllers
{
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok($"Everything is fine........... {DateTime.Now}");
        }
    }
}
