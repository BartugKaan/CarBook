﻿using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetLastFiveCarsWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLastFiveCarsWithBrands();
            return values.Select(x => new GetLastFiveCarsWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
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
