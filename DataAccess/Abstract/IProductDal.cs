using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{//code refactoring
   public interface IProductDal:IEntityRepository<Product>
    {
        //Buradaki kodları ortak olan her IDal için tek tek yazmak yerine GenericRepositoryDesign Pattern kullanarak IEntityRepository interface'i ile tek seferde <T> ile kullandık

        //List<Product> GetAll();

        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetAllCategory(int categoryId);

        List<ProductDetailDto> GetProductDetails();

    }
}
