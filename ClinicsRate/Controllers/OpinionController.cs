﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicsRate.Controllers
{
    [Route("api/opinion")]
    [Produces("application/json")]
    public class OpinionController : Controller
    {
        private readonly IOpinionService _opinionService;

        public OpinionController(IOpinionService opinionService)
        {
            _opinionService = opinionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOpinions()
        {
            return new JsonResult(await _opinionService.GetAllOpinionsAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOpinion([FromBody] Opinion opinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _opinionService.UpdateOpinionAsync(opinion);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(opinion.OpinionId);
        }

        [HttpPost]
        public async Task<IActionResult> AddOpinion([FromBody] Opinion opinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _opinionService.AddOpinionAsync(opinion);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(opinion.OpinionId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpinion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _opinionService.DeleteOpinionAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(id);
        }

    }
}