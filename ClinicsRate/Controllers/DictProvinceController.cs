using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicsRate.Controllers
{
    [Authorize]
    [Route("api/dictProvince")]
    [Produces("application/json")]
    public class DictProvinceController : Controller
    {
        private readonly IDictProvinceService _dictProvinceService;

        public DictProvinceController(IDictProvinceService dictProvinceService)
        {
            _dictProvinceService = dictProvinceService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllDictProvinces()
        {
            return new JsonResult(await _dictProvinceService.GetAllDictProvinceAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDictProvince([FromBody] DictProvince dictProvince)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictProvinceService.UpdateDictProvinceAsync(dictProvince);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(dictProvince.DictProvinceId);
        }

        [HttpPost]
        public async Task<IActionResult> AddDictProvince([FromBody] DictProvince dictProvince)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictProvinceService.AddDictProvinceAsync(dictProvince);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(dictProvince.DictProvinceId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDictProvince([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dictProvinceService.DeleteDictProvinceAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(id);
        }
    }
}