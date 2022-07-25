using Bidding_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal class Admin : User, IAdmin, ICloneable
    {
        internal protected static List<Tuple<Client, Product>> _unresolvedReports = new List<Tuple<Client, Product>>();
        internal protected static List<Tuple<Client, Product>> _resolvedReports = new List<Tuple<Client, Product>>();
        public Admin(string username, string password, string email, string phone) : base(username, password, email, phone)
        {
        }
        
        public void ResolveReport(Client client, Product product, bool result)
        {
            if (result != false)
            {
                product.Company.StrikeNumber += 1;
            }
            Tuple<Client, Product> x = new Tuple<Client, Product>(client, product);
            _resolvedReports.Add(x);
            _unresolvedReports.Remove(x);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
