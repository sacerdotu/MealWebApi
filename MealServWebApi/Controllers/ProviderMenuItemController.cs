using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessServices;
using BusinessEntities;

namespace MealServWebApi.Controllers
{
    public class ProviderMenuItemController : ApiController
    {
        private readonly IProviderMenuServices _providerServices;

         #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public ProviderMenuItemController(IProviderMenuServices providerMenuServices)
        {
            _providerServices = providerMenuServices;
        }

        #endregion

        // GET api/product
        public HttpResponseMessage Get()
        {
            var products = _providerServices.GetAllProducts();
            if (products != null)
            {
                var productEntities = products as List<ProviderMenuItemEntity> ?? products.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var product = _providerServices.GetProductById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/product
        public long Post([FromBody] ProviderMenuItemEntity productEntity)
        {
            return _providerServices.CreateProduct(productEntity);
        }

        // PUT api/product/5
        public bool Put(int id, [FromBody]ProviderMenuItemEntity productEntity)
        {
            if (id  > 0)
            {
                return _providerServices.UpdateProduct(id, productEntity);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _providerServices.DeleteProduct(id);
            return false;
        }
    }
}