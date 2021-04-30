using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from c in context.tblCar
                             join clr in context.tblColor
                             on c.ColorId equals clr.ColorId
                             join br in context.tblBrand on c.BrandId equals br.BrandId
                             select new CarDetailsDto
                             {
                                 CarId = c.CarId,
                                 CarName = br.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
