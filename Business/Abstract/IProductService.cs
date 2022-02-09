using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
       
        IDataResult<List<Product>> GetAll(); //List<Product> GetAll();  --eskisi
        IDataResult<List<Product>> GetAllByCategoryId(int id);//  List<Product> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//List<Product> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();// List<ProductDetailDto> GetProductDetails(); //void Add(Product product); --eskisi

        IResult Add(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int productId); //Product GetById(int productId);
        IResult AddTransactionalTest(Product product);

    }
}
