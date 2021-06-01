using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspect.Autofac.Validation;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carsDal;
        public CarManager (ICarDal carDal)
        {
            _carsDal = carDal;
        }
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(CarValidator))]        
        public IResult Add(Car car)
        {            
            _carsDal.Add(car);
            return new SuccessResult(Messages.CarAdded);            
        }

        public IResult Delete(Car car)
        {            
            _carsDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
                      
        }
        public IResult Update(Car car)
        {
            _carsDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarMaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {        
            
            return new SuccessDataResult<Car>(_carsDal.Get(c => c.CarId == id));            
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carsDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(c => c.ColorId == id));
        }

       
    }
}
