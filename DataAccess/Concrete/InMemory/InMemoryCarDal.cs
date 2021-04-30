using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _carBrands;
        List<Color> _carColors;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=250,Description="Araç değişensiz." },
                new Car{CarId=2,BrandId=1,ColorId=1,ModelYear=2011,DailyPrice=350,Description="Araç komple boyalı" },
                new Car{CarId=3,BrandId=2,ColorId=1,ModelYear=2010,DailyPrice=150,Description="Araç tampon değişti." },
                new Car{CarId=4,BrandId=2,ColorId=2,ModelYear=2012,DailyPrice=100,Description="Araç iki parça boyalı." },
                new Car{CarId=5,BrandId=3,ColorId=2,ModelYear=2000,DailyPrice=200,Description="Araç tertemiz." }
            };
            _carBrands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Honda" },
                new Brand{BrandId=2,BrandName="Volvo" },
                new Brand{BrandId=3,BrandName="Mercedes"}
            };
            _carColors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Beyaz"},
                new Color{ColorId=2,ColorName="Siyah"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }       

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}

