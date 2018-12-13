﻿using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using ClinicsRate.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicsRate.Controllers
{
    [Route("api/clinic")]
    [Produces("application/json")]
    public class ClinicController : Controller
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClinics()
        {
            return new JsonResult(await _clinicService.GetClinicsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClinic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return new JsonResult(await _clinicService.GetClinicAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClinic([FromBody] ClinicDto clinic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _clinicService.UpdateClinicAsync(clinic);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(clinic.ClinicId);
        }

        [HttpPost]
        public async Task<IActionResult> AddClinic([FromBody] ClinicDto clinic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _clinicService.AddClinicAsync(clinic);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(clinic.ClinicId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _clinicService.DeleteClinicAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(id);
        }

    }
}