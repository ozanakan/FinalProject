using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{//TEntity için class ve IEntity den (ornek Category,Customer,Product yani tablo isimleri)TContext içinde DbContextten(örnek NortwindContext)
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> where TEntity :class, IEntity, new() where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);  //Referansı yakala
                addedEntity.State = EntityState.Added;   //o aslında eklenecek nesne
                context.SaveChanges(); //şimdi ekle
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);  //Referansı yakala
                deletedEntity.State = EntityState.Deleted;   //o aslında eklenecek nesne
                context.SaveChanges(); //şimdi ekle
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {   // filtre boş ise tüm product listesini getir ? if gibi doğruysa ilki değilse : tan sonrayı yapıyor
                return filter == null ? context.Set<TEntity>().ToList() :
                                        context.Set<TEntity>().Where(filter).ToList();

            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);  //Referansı yakala
                updatedEntity.State = EntityState.Modified;   //o aslında eklenecek nesne
                context.SaveChanges(); //şimdi ekle
            }
        }
    }
}
