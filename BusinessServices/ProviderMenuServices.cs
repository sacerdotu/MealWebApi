using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace BusinessServices
{
    public class ProviderMenuServices:IProviderMenuServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ProviderMenuServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public BusinessEntities.ProviderMenuItemEntity GetProductById(int productId)
        {
            var product = _unitOfWork.ProviderMenuItemRepository.GetByID(productId);
            if (product != null)
            {
                Mapper.CreateMap<tblProviderMenuItem, ProviderMenuItemEntity>();
                var productModel = Mapper.Map<tblProviderMenuItem, ProviderMenuItemEntity>(product);
                return productModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ProviderMenuItemEntity> GetAllProducts()
        {
            var products = _unitOfWork.ProviderMenuItemRepository.GetAll().ToList();
            if (products.Any())
            {
                Mapper.CreateMap<tblProviderMenuItem, ProviderMenuItemEntity>();
                var productsModel = Mapper.Map<List<tblProviderMenuItem>, List<ProviderMenuItemEntity>>(products);
                return productsModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public long CreateProduct(BusinessEntities.ProviderMenuItemEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                var product = new tblProviderMenuItem
                {
                     Name= productEntity.Name
                };
                _unitOfWork.ProviderMenuItemRepository.Insert(product);
                _unitOfWork.Save();
                scope.Complete();
                return product.ProviderMenuItemID;
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, BusinessEntities.ProviderMenuItemEntity productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProviderMenuItemRepository.GetByID(productId);
                    if (product != null)
                    {
                        product.Name = productEntity.Name;
                        _unitOfWork.ProviderMenuItemRepository.Update(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProviderMenuItemRepository.GetByID(productId);
                    if (product != null)
                    {

                        _unitOfWork.ProviderMenuItemRepository.Delete(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
