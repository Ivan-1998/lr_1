using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.Storage;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private IStorage<Lab1Data> _memCache;

        public Lab1Controller(IStorage<Lab1Data> memCache)
        {
            _memCache = memCache;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Lab1Data>> Get()
        {
            return Ok(_memCache.All);
        }

        [HttpGet("{id}")]
        public ActionResult<Lab1Data> Get(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("Такого пользователя не существует!");

             return Ok(_memCache[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Lab1Data value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _memCache.Add(value);

            return Ok($"{value.ToString()} - запись успешно добавлена!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Lab1Data value)
        {
            if (!_memCache.Has(id)) return NotFound("Такого пользователя не сущесвует!");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"Данные пользователя обновлены!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("Такого пользователя не сущесвует!");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"Пользователь удален");
        }
    }
}