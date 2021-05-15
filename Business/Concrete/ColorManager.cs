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
    public class ColorManager : IColorService
    {
        IColorDal _colorsDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorsDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if(color.ColorName.Length<1)
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
            _colorsDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorsDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorMaintenanceTime);
            }
            
            return new SuccessDataResult<List<Color>>(_colorsDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorsDal.GetAll(clr => clr.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _colorsDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
