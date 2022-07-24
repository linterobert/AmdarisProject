using Bidding_app.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Interfaces
{
    internal interface ICompany
    {
        public void AddProduct(Product product);
        public void CashOut(Product product);

    }
}
