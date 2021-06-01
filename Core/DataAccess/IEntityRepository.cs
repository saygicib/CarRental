using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new ()
    {
        //Generic Constraint
        //class : referans tip olmalı demek.
        //IEntity : IEntity veya IEntity implemente eden bir nesne olabilir.
        //new() : new'lenebilir olmalı
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>> filter);//filtreleme zorunlu.
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //istediğimiz filtre yöntemine göre getirecek. istersek filtreleme yapmaya gerek olmayacak.
    }
}
