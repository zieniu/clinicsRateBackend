using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicsRate.Controllers
{
    [Route("api/dictCity")]
    [Produces("application/json")]
    public class DictCityController : Controller
    {
        private readonly IDictCityService _dictCityService;

        public DictCityController(IDictCityService dictCityService)
        {
            _dictCityService = dictCityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDictCity()
        {
            return new JsonResult(await _dictCityService.GetAllDictCityAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDictCity([FromBody] DictCity dictCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictCityService.UpdateDictCityAsync(dictCity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(dictCity.DictCityId);
        }

        [HttpPost]
        public async Task<IActionResult> AddDictCity([FromBody] DictCity dictCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictCityService.AddDictCityAsync(dictCity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(dictCity.DictCityId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDictCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictCityService.DeleteDictCity(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(id);
        }


    }
}