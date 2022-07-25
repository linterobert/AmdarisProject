using Bidding_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal sealed class Company : User, ICloneable, ICompany
    {
        string _companyName;
        string _IBAN;
        double _companyBalance;
        List<Product> _products;
        int _strikeNumber;

        public Company(string username, string password, string email, string phone, string companyName, string iBAN) : base(username, password, email, phone)
        {
            _companyName = companyName;
            _IBAN = iBAN;
            _products = new List<Product>();
            _strikeNumber = 0;
            _companyBalance = 0;
        }
        public int StrikeNumber { get { return _strikeNumber; } set { _strikeNumber = value; } }
        public void AddProduct(Product product)
        {
            if (_strikeNumber < 3) this._products.Add(product);
            else Console.WriteLine("Your account was banned!");
        }

        public void CashOut(Product product)
        {
            if (_strikeNumber < 3)
            {
                if (product.CashOut == false && product.FinalTime.CompareTo(DateTime.Now) < 0 && product.Owner != null && this._products.Contains(product))
                {
                    _companyBalance += product.ActualPrice;
                    product.CashOut = true;
                    Console.WriteLine("Cash out successfully");
                }
                else
                {
                    if (!this._products.Contains(product))
                    {
                        Console.WriteLine("You don't have this product!");
                    }
                    else
                    {
                        if (!(product.FinalTime.CompareTo(DateTime.Now) < 0))
                        {
                            Console.WriteLine("This item is still in time!");
                        }
                        else
                        {
                            Console.WriteLine("You already take the money from this product");
                        }
                    }
                }
            }
            else Console.WriteLine("Your account was banned!");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
