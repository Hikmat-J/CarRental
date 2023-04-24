using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.Dtos;
using CarRental.Domain.Entities;

namespace CarRental.Application
{
    public class CarRentalProfile:Profile
    {
        public CarRentalProfile()
        {
            CreateMap<UpdateCarDto,Car>();   
            CreateMap<CreateCarDto,Car>();
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateDriverDto, Driver>();
            CreateMap<Driver, DriverDto>();


        }
    }
}
