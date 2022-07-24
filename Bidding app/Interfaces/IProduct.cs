using Bidding_app.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Interfaces
{
    internal interface IProduct
    {
        public const double BitConstant = 0.1;
        public bool CheckAvailable();
        public void MakeOffer(Client client, double offer);
    }

}
