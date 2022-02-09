using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        // ILogger _logger;

        public ProductManager(IProductDal productDal,ICategoryService categoryService/*, ILogger logger*/)
        {  //constructor
            _productDal = productDal;
            _categoryService = categoryService;
            //   _logger = logger;
        }
    

       // [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]//validaysonu kullanamk için yazdığımız kod
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)// void olan eski kullanımı IResult ile değiştirip return ekledik
        {//ekleme için iş kodları eğer bir filtre vesaire birşey eklemek istersek burada ekleriz
         // validation(doğrulama)
         //------------------------------------------------------------------------------
         //if (product.ProductName.Length < 2)
         //   { // ErrorResult("")   "" içerisine mesaj yazabiliriz ama bunun için magic strings kullanıcaz ama her yerde yazdığın bir metni değiştirmek kolay olması için
         //     // return new ErrorResult("Ürün İsmi en az 2 karakter olmalıdır.");
         //       return new ErrorResult(Messages.ProductNameInvalid);
         //   }
         //------------------------------------------------------------------------------
         //   var context = new ValidationContext<Product>(product);
         //   ProductValidator productValidator = new ProductValidator();
         //   var result = productValidator.Validate(context);
         //   if (!result.IsValid)
         //   {
         //       throw new ValidationException(result.Errors);
         //   }
         //------------------------------------------------------------------------------
            ///ValidationTool.Validate(new ProductValidator(), product);

            //_logger.Log();
            //try //AOP kullanmadan nasıl logger kullanılır onu gösterdik sonra AOP ile tekrar doğru kodlayacağız
            //{

            //    _productDal.Add(product);
            //    //  return new SuccessResult("Ürün Eklendi");
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //catch (Exception exception)
            //{
            //    _logger.Log();
            //}
            //return new ErrorResult();
            //------------------------------------------------------------------------------
         
            //iş kurallarını BusinessRuler.Run içerisinde çalıştırıp dönen değere dolu ise hata değil ise ekliyoruz
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                                             CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                             CheckIfCategoryLimitExceded());
            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//cache temizliyoruz update olduğu için
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //İş kodları
            //Yetkisi varmı
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

        }
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {   //category id'ye göre ürün getirme
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), "mesaj");
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {   //ürün max min fiyata göre getirme
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }




        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Bir kategoride en fazla 10 ürün olabilir iş kodunu yazalım.
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 20)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            //Aynı product nameden bir tane daha varmı diye iş kuralı
            //Any şuna uyan kayıt varmı demek
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)//eğer result varsa
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {//category sayısı 15 den fazlaysa ürün eklenmez
            var result = _categoryService.GetAll();
            if (result.Data.Count>=15)//eğer result varsa
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        
        }


    }
}
