using CarSearch.DTO;
using CarSearch.Model;
using CarSearch.Repositories;
using System.Numerics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarSearch.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly ICompanyRepository _companyRepository;
        
        private readonly IConfiguration _configuration;

        public CarService(ICarRepository carRepository, ICarTypeRepository carTypeRepository, ICompanyRepository companyRepository, IConfiguration configuration)
        {
            _carRepository = carRepository;
            _carTypeRepository = carTypeRepository;
            _companyRepository = companyRepository;
            _configuration = configuration;

        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _carRepository.GetCarsAsync();
        }

        //public async Task<IEnumerable<GetCarFilterDto>> GetFilteredCarsAsync(GetCarFilterDto filter)
        //{
        //    var cars = await _carRepository.GetCarsAsync();
        //    var carTypes = await _carTypeRepository.GetCarTypesAsync();

        //    var query = from car in cars
        //                join carType in carTypes on car.CarTypeId equals carType.CarTypeId into carTypeGroup
        //                from carType in carTypeGroup.DefaultIfEmpty()
        //                where (filter.CarColor == null || car.CarColor == filter.CarColor) &&
        //                      (filter.CarEngineCapacity == null || car.CarEngineCapacity == filter.CarEngineCapacity) &&
        //                      (filter.CarFuelType == null || car.CarFuelType == filter.CarFuelType) &&
        //                      (filter.CarManuFacYear == null || car.CarManFacYear == filter.CarManuFacYear) &&
        //                      (!filter.CarSeating.HasValue || car.CarSeating == filter.CarSeating) &&
        //                      (!filter.CarTypeId.HasValue || car.CarTypeId == filter.CarTypeId) &&
        //                      (!filter.CompanyId.HasValue || car.CompanyId == filter.CompanyId) &&
        //                      (!filter.MinPrice.HasValue || car.CarPriceExShowroom >= filter.MinPrice.Value) &&
        //                      (!filter.MaxPrice.HasValue || car.CarPriceExShowroom <= filter.MaxPrice.Value)
        //                select new
        //                {
        //                    Car = car,
        //                    CarType = carType
        //                };

        //    var matchingCars = query.ToList();

        //    if (matchingCars.Any())
        //    {
        //        var result = matchingCars.Select(item => new GetCarFilterDto(
        //            item.Car.CarColor ?? "",
        //            item.Car.CarEngineCapacity ?? "",
        //            item.Car.CarFuelType ?? "",
        //            item.Car.CarManFacYear ?? "",
        //            item.Car.CarSeating,
        //            item.Car.CarTypeId,
        //            item.Car.CompanyId,
        //            filter.MinPrice ?? 0,
        //            filter.MaxPrice ?? decimal.MaxValue
        //        ));

        //        return result;
        //    }
        //    else
        //    {
        //        return null; // No matching records found in the database
        //    }
        //}

        public async Task<IEnumerable<CarFilterResultDto>> GetFilteredCarsAsync(GetCarFilterDto filter)
        {
            var cars = await _carRepository.GetCarsAsync(); // Assuming GetCarsAsync returns IEnumerable<CarFilterResultDto>
            var carTypes = await _carTypeRepository.GetCarTypesAsync(); // Assuming GetCarTypesAsync returns IEnumerable<CarType>

            var query = from car in cars
                        join carType in carTypes on car.CarTypeId equals carType.CarTypeId into carTypeGroup
                        from carType in carTypeGroup.DefaultIfEmpty()
                        join company in await _companyRepository.GetCompaniesAsync() on car.CompanyId equals company.CompanyId into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        where ((filter.CarColor == null || car.CarColor == filter.CarColor) || (filter.CarColor == null && car.CarColor == null)) &&
                              (filter.CarEngineCapacity == null || car.CarEngineCapacity == filter.CarEngineCapacity) &&
                              (filter.CarFuelType == null || car.CarFuelType == filter.CarFuelType) &&
                              (filter.CarManuFacYear == null || car.CarManFacYear == filter.CarManuFacYear) &&
                              (!filter.CarSeating.HasValue || car.CarSeating == filter.CarSeating) &&
                              (!filter.CarTypeId.HasValue || car.CarTypeId == filter.CarTypeId) &&
                              (!filter.CompanyId.HasValue || car.CompanyId == filter.CompanyId) &&
                              (!filter.MinPrice.HasValue || car.CarPriceExShowroom >= filter.MinPrice.Value) &&
                              (!filter.MaxPrice.HasValue || car.CarPriceExShowroom <= filter.MaxPrice.Value)
                        select new CarFilterResultDto(
                            car.CarName ?? "",
                            car.CarColor ?? "",
                            car.CarEngineCapacity ?? "",
                            car.CarFuelType ?? "",
                            car.CarManFacYear ?? "",
                            car.CarSeating,
                            car.CarTypeId,
                            carType?.CarTypeName ?? "",
                            car.CompanyId,
                            company?.CompanyName ?? "",
                            company?.CarModel ?? "",   // Use CarModel from the Companies table
                            filter.MinPrice ?? 0,
                            filter.MaxPrice ?? decimal.MaxValue
                        );

            var matchingCars = await query.ToListAsync();

            return matchingCars.Any() ? matchingCars : null;
        }





        public async Task<Car> GetCarByIdAsync(Guid id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            return car;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            car.Id = Guid.NewGuid();
            return await _carRepository.CreateCarAsync(car);
        }

        public async Task<Car> UpdateCarAsync(Guid id, Car car)
        {
            var existingCar = await _carRepository.GetCarByIdAsync(id);
            if (existingCar != null)
            {
                existingCar.CarName = car.CarName;
                existingCar.CarEngineCapacity = car.CarEngineCapacity;
                existingCar.CarSeating = car.CarSeating;
                existingCar.CarManFacYear = car.CarManFacYear;
                existingCar.CarColor = car.CarColor;
                existingCar.CarFuelType = car.CarFuelType;
                existingCar.CarPriceExShowroom = car.CarPriceExShowroom;
                existingCar.CarSeating = car.CarSeating;
                await _carRepository.UpdateCarAsync(existingCar);

                return existingCar;

            }
            else
            {
                return null;
            }

        }

        public async Task DeleteCarAsync (Guid Id)
        {
            await _carRepository.DeleteCarAsync(Id);
        }

    }
}
