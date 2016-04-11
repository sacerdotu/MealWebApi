using System.ComponentModel.Composition;
using DataModel;
using DataModel.UnitOfWork;
using Resolver;
using BusinessServices.Classes;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IProviderMenuServices, ProviderMenuServices>();
            registerComponent.RegisterType<BusinessServices.Interfaces.IUserServices, UserService>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();

        }
    }
}
