﻿using CarBook.Application.Features.CQRS.Results.BrandResult;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                Model = x.Model,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmition = x.Transmition,
            }).ToList();
        }
    }
}
