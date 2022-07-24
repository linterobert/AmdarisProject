using Bidding_app.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Interfaces
{
    internal interface IAdmin
    {
        public void ResolveReport(Client client, Product product, bool result);
    }
}
