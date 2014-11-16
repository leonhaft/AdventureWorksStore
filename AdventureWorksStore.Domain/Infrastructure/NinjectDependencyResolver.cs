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
using AdventureWorksStore.Domain.Concrete;

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
            mock.Setup(s => s.Products).Returns(new List<Product>
                {
                    new Product{ ProductID=1,Name="P1" ,ListPrice=12.3m, Description="werwetewrwet"},
                    new Product{ ProductID=2,Name="P2",ListPrice=234.3m, Description="werewtewtew"},
                    new Product{ ProductID=3,Name="P3",ListPrice=32m,Description="ewrewtwetewtewrwers"}
                });
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}
