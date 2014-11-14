using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksStore.Domain.Entities
{
    public class ProductInfo
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
    }
}
