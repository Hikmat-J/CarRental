using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Dtos;
using CarRental.Application.Dtos;

namespace CarRental.Application.Services
{
    public interface ICarService
    {
        Task Create(CreateCarDto createCarDto);
        Task<CarDto> GetById(int Id);
        Task<PagedList<CarDto>> GetAll(int pageIndex, int pageSize, string SortBy, long? number = null, string? color = null, bool? withDriver = null);
        Task Put(UpdateCarDto input);
        Task Delete(CarDto carDto);
    }
}
