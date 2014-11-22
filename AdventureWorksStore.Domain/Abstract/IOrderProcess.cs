using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksStore.Domain.Entities;

namespace AdventureWorksStore.Domain.Abstract
{
    public interface IOrderProcess
    {
        void ProcessOrder(Cart cart,ShippingDetails shippingDetails);
    }
}
