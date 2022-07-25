using Bidding_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal class Product : IProduct, ICloneable
    {
        string _productName;
        double _startPrice;
        double _actualPrice;
        DateTime _postTime;
        DateTime _finalTime;
        //TimeSpan
        Company _company;
        Client _owner;
        bool _cashOut;
        List<Review> _reviews;
        public Product(string productName, double price, DateTime postTime, DateTime finalTime, Company company, Client owner)
        {
            _productName = productName;
            _startPrice = price;
            _postTime = postTime;
            _finalTime = finalTime;
            _company = company;
            _owner = owner;
            _actualPrice = price;
            _cashOut = false;
            _reviews = new List<Review>();
        }
        public string ProductName { get { return _productName; } set { _productName = value; } }
        public double StartPrice { get { return _startPrice; } set { _startPrice = value; } }
        public DateTime PostTime { get { return _postTime; } }
        public DateTime FinalTime { get { return _finalTime; } set { _finalTime = value; } }
        public Company Company { get { return _company; } }
        public Client Owner { get { return _owner; } set { _owner = value; } }
        public bool CashOut { get { return _cashOut; } set { _cashOut = value; } }
        public List<Review> Reviews { get { return _reviews; } }
        public double ActualPrice { get { return _actualPrice; } set { _actualPrice = value; } }
        public bool CheckAvailable()
        {
            if (_finalTime.CompareTo(_postTime) > 0) return true;
            else return false;
        }

        public void MakeOffer(Client client, double offer)
        {
            Owner.Balance += this.ActualPrice;
            Owner.ProductsOwn.Remove(this);
            if (this.Owner != null)
            {
                Owner.Balance += this.ActualPrice;
                Owner.ProductsOwn.Remove(this);
            }
            this.Owner = client;
            this.ActualPrice = offer + offer * IProduct.BitConstant;
            DateTime dateTime = DateTime.Now;
            int x = dateTime.Subtract(_finalTime).Seconds;
            if( x <= 30)
            {
                _finalTime.AddMinutes(1);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
