using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IProviderMenuServices
    {
        ProviderMenuItemEntity GetProductById(int productId);
        IEnumerable<ProviderMenuItemEntity> GetAllProducts();
        long CreateProduct(ProviderMenuItemEntity productEntity);
        bool UpdateProduct(int productId, ProviderMenuItemEntity productEntity);
        bool LikeProduct(int productId);
        bool DislikeProduct(int productId);
        bool DeleteProduct(int productId);
    }
}
