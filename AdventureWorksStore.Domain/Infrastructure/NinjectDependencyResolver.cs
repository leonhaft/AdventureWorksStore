using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Moq;
using AdventureWorksStore.Domain.Abstract;
using AdventureWorksStore.Domain.Entities;

namespace AdventureWorksStore.Domain.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParm)
        {
            kernel = kernelParm;
            AddBinds();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBinds()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(s => s.Products).Returns(new List<ProductInfo>
                {
                    new ProductInfo{ ProductID=1,ProductName="P1" ,ListPrice=12.3m},
                    new ProductInfo{ ProductID=2,ProductName="P2",ListPrice=234.3m},
                    new ProductInfo{ ProductID=3,ProductName="P3",ListPrice=32m}
                });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);

        }
    }
}
