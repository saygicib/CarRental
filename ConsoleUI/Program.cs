using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {            
            //CarAdd();
            //GetById();
            //GetAll();             
        }

        private static void GetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());           
            foreach (var cars in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(cars.CarId + "  " + cars.CarName+ "  " + cars.ColorName+ "  " + cars.DailyPrice);
            }
            
        }

        private static void GetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(2).Data.DailyPrice);
        }

        private static CarManager CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            car.CarId = 7;
            car.BrandId = 2;
            car.ColorId = 4;
            car.DailyPrice = 400;
            car.Description = "Kiralık.";
            car.ModelYear = 2012;
            carManager.Add(car);
            return carManager;
        }
    }
}
