using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if(brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.BrandInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);            
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandMaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {           
            foreach (var brand in _brandDal.GetAll())
            {
                if(brand.BrandId==id)
                {
                    return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(br => br.BrandId == id));
                    
                }
            }
            return new ErrorDataResult<List<Brand>>(_brandDal.GetAll(br => br.BrandId == id), Messages.BrandNotFound);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
