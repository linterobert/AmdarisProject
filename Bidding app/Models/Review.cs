using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal class Review
    {
        string _text;
        Product _product;
        Client _client;
        int _starNumber;
        DateTime _postTime;
        public Review(string text, Product product, Client client, int starNumber)
        {
            _text = text;
            _product = product;
            _client = client;
            _starNumber = starNumber;
            _postTime = DateTime.Now;
        }
        public Product Product { get { return _product; } }
        public String Text { get { return _text; } set { _text = value; } }
    }
}
