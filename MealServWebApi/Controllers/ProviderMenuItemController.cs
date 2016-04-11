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
using MealServWebApi.Filters;

namespace MealServWebApi.Controllers
{
    //[ApiAuthenticationFilter]
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
        [HttpGet]
        //[ActionName("allp")]
        [Route("api/providermenuitem/today")]
        public HttpResponseMessage TodayProf()
        {
            var products = _providerServices.GetAllProducts().Where(product => product.Date.Date == DateTime.Now.Date);
            if (products != null)
            {
                var productEntities = products as List<ProviderMenuItemEntity> ?? products.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/product
        // [ApiAuthenticationFilter(false)]
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
        // [ApiAuthenticationFilter(true)]
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

        [HttpPut]
        [Route("api/providermenuitem/like/{id}")]
        public bool Like(int id)
        {
            if (id > 0)
            {
                return _providerServices.LikeProduct(id);
            }
            return false;
        }
        [HttpPut]
        [Route("api/providermenuitem/dislike/{id}")]
        public bool Dislike(int id)
        {
            if (id > 0)
            {
                return _providerServices.DislikeProduct(id);
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