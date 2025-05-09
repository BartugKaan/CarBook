﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastFiveCarsWithBrandQueryHandler _getLastFiveCarsWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
            GetCarQueryHandler getCarQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
            GetLastFiveCarsWithBrandQueryHandler getLastFiveCarsWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastFiveCarsWithBrandQueryHandler = getLastFiveCarsWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araba Eklendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba Silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba Güncellendi");
        }

        [HttpGet("GetCarWithBrand")]
        public  IActionResult GetCarWithBrand()
        {
            var values =  _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetLastFiveCarsWithBrand")]
        public IActionResult GetLastFiveCarsWithBrand()
        {
            var values = _getLastFiveCarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
