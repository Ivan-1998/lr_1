using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using lab1.Models;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private static List<Lab1Data> _memCache = new List<Lab1Data>();

        [HttpGet]
        public ActionResult<IEnumerable<Lab1Data>> Get()
        {
            return _memCache;
        }

        [HttpPost]
        public void Post([FromBody] Lab1Data value)
        {
            _memCache.Add(value); 
        }
    }
}