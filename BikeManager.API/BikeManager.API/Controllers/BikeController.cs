using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeManager.API.Models;
using BikeManager.API.Services.Interfaces;
using BikeManager.API.Validators;
using BikeManager.API.ViewModels;
using BikeManager.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BikeManager.API.Controllers
{
    [ApiController]
    [Route("")]
    public class BikeController : Controller
    {
        private readonly IBikeService _bikeService;
        private readonly ILogger<BikeController> _logger;
        private readonly IMapper _mapper;

        public BikeController(IBikeService bikeService, ILogger<BikeController> logger, IMapper mapper)
        {
            _bikeService = bikeService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("bikes")]
        [HttpPost]
        public async Task<IActionResult> AddBike([FromBody] BikeDto bikeDto)
        {
            var validResult = await new BikeDtoValidator().ValidateAsync(bikeDto);
                
            if (!validResult.IsValid)
            {
                _logger.Log(LogLevel.Information, "Bike is not valid!");

                //add errors to model state
                foreach (var error in validResult.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }
            
            await _bikeService.AddFromDto(bikeDto);
            _logger.Log(LogLevel.Information, "Add bike");

            return Ok();
        }

        [Route("bikes/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBike([NotNull] long id)
        {
            await _bikeService.RemoveBike(Convert.ToInt32(id));
            _logger.Log(LogLevel.Information, $"Remove bike by id {id}");

            return Ok();
        }

        [Route("bikes")]
        [HttpPut]
        public async Task<IActionResult> UpdateBikeStatus([NotNull][FromQuery] long id, 
            [NotNull] [FromQuery] string toStatus)
        {
            await _bikeService.UpdateBikeStatus(id, toStatus);
            _logger.Log(LogLevel.Information, $"Update bike by id {id} to status {toStatus}");

            return Ok();
        }

        [Route("bikes")]
        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            var bikes = await _bikeService.GetAllAsync();
            _logger.Log(LogLevel.Information, "Get all bikes");

            return Ok(bikes);
        }

        [Route("bikes/available")]
        [HttpGet]
        public async Task<IActionResult> GetAvailBikes()
        {
            var bikes = await _bikeService.BikesFilterForStatus("Available");
            _logger.Log(LogLevel.Information, "Get available bikes");
            
            var bikesForResponse = _mapper.Map<List<BikeDto>>(bikes);
            
            return Ok(bikesForResponse);
        }

        [Route("bikes/rented")]
        [HttpGet]
        public async Task<IActionResult> GetRentBikes()
        {
            var bikes = await _bikeService.BikesFilterForStatus("Rented");
            _logger.Log(LogLevel.Information, "Get rented bikes");

            var bikesForResponse = _mapper.Map<List<BikeDto>>(bikes);
            
            return Ok(bikesForResponse);
        }
    }
}