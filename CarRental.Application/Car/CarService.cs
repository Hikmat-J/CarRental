using AutoMapper;
using CarRental.Application.Contract;
using CarRental.Application.Dtos;
using CarRental.Domain.Entities;
using CarRental.Domain.Repository;
using CarRental.Domain.Shared.CarRental.Caching;
using CarRental.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace CarRental.Application.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICachInMemoryService _cachInMemoryService;
        //private readonly ConstCachInMemory constCachInMemory;
        public CarService(IUnitOfWork unitOfWork, IMapper mapper, ICachInMemoryService cachInMemoryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cachInMemoryService = cachInMemoryService;
            //constCachInMemory = new ConstCachInMemory();
        }
        public async Task Create(CreateCarDto createCarDto)
        {
            
            Car car = _mapper.Map<CreateCarDto, Car>(createCarDto);
            _unitOfWork.Cars.Add(car);
            _unitOfWork.Complete();
        }

        public async Task Delete(CarDto carDto)
        {
            Car car = _mapper.Map<CarDto, Car>(carDto);
            _unitOfWork.Cars.Remove(car);
            _unitOfWork.Complete();

        }

        public async Task<PagedList<CarDto>> GetAll(int pageIndex, int pageSize,string SortBy,
             long? number = null, string? color = null, bool? withDriver = null)
        {
            var cacheData = _cachInMemoryService.GetData<IEnumerable<Car>>("Car");
            if (cacheData != null)
            {
                if (number is not null)
                {
                    cacheData = cacheData.Where(c => c.Number == number);
                }
                if (color is not null)
                {
                    cacheData = cacheData.Where(c => c.Color == color);
                }
                if (withDriver is not null)
                {
                    cacheData = cacheData.Where(c => c.WithDriver == withDriver);
                }
                return new PagedList<CarDto>(_mapper.Map<List<Car>, List<CarDto>>(cacheData.ToList()), pageIndex, pageSize);
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(ConstCachInMemory.DEFAULT_CACH_TIME);
            
            cacheData = _unitOfWork.Cars.GetAll();
            if (number is not null)
            {
                cacheData = cacheData.Where(c => c.Number == number);
            }
            if (color is not null)
            {
                cacheData = cacheData.Where(c => c.Color == color);
            }
            if (withDriver is not null)
            {
                cacheData = cacheData.Where(c => c.WithDriver == withDriver);
            }
            _cachInMemoryService.SetData("Car", cacheData, expirationTime);
            return new PagedList<CarDto>(_mapper.Map<List<Car>, List<CarDto>>(cacheData.ToList()), pageIndex, pageSize);
        }

        public async Task<CarDto> GetById(int Id)
        {
            Car car = _unitOfWork.Cars.GetById(Id);
            var result = _mapper.Map<Car, CarDto>(car);
            return result;
        }

        public async Task Put(UpdateCarDto updateCarDto)
        {
            Car car = _mapper.Map<UpdateCarDto, Car>(updateCarDto);
            _unitOfWork.Cars.Update(car);
            _unitOfWork.Complete();

        }

    }
}
