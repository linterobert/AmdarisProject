using Bidding_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Entities
{
    internal sealed class Client : User, ICloneable, IClient
    {
        List<Product> _productsOwn;
        double _balance;
        List<Card> _cards;
        string _clientName;
        List<Review> _reviews;
        public Client(string username, string password, string email, string phone, string client) : base(username, password, email, phone)
        {
            _balance = 0.00;
            _productsOwn = new List<Product>();
            _cards = new List<Card>();
            _clientName = client;
            _reviews = new List<Review>();
        }

        public double Balance { get { return _balance; } set { _balance = value; } }
        public List<Product> ProductsOwn { get { return _productsOwn; } }
        public List<Card> Cards { get { return _cards; } }
        public List<Review> Reviews { get { return _reviews; } }

        public void AddCard(Card newCard)
        {
            if (newCard.Owner.Equals(_clientName) && newCard.ExpireDate.CompareTo(DateTime.Now) < 0)
            {
                Cards.Add(newCard);
                Console.WriteLine("Card added successfully");
            }
            else
            {
                if (!newCard.Owner.Equals(_clientName))
                {
                    Console.WriteLine("Your profile name is different by your card name!");
                }
                else
                {
                    Console.WriteLine("Your card is out of date!");
                }
            }
        }

        public void AddMoney(Card card, double sum)
        {
            if( this.Cards.Contains(card) )
            {
                _balance += sum;
                Console.WriteLine("Successful transaction!");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void MakeOffer(Product product, double offer)
        {
            if (_balance >= offer)
            {
                _balance -= offer;
                _productsOwn.Add(product);
                product.MakeOffer(this, offer);
                Console.WriteLine("Successful transaction!");
            }
            else Console.WriteLine("Insufficient funds");
        }
        public void RemoveCard(Card newCard)
        {
            Cards.Remove(newCard);
        }
        public void MakeReport(Product product)
        {
            Admin._unresolvedReports.Add(new Tuple<Client, Product>(this, product));
        }
        public void AddReview(Product product, string message, int stars)
        {
            Review x = new Review(message, product, this, stars);
            _reviews.Add(x);
            product.Reviews.Add(x);
        }
        public void RemoveReview(Review review)
        {
            review.Product.Reviews.Remove(review);
            _reviews.Remove(review);
        }
        public void UpdateReview(Review review, string message)
        {
            RemoveReview(review);
            review.Text = message;
            _reviews.Add(review);
            review.Product.Reviews.Add(review);
        }
    }
}
