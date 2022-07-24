using Bidding_app.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding_app.Interfaces
{
    internal interface IClient
    {
        public void MakeOffer(Product product, double offer);
        public void ChangePassword(string newPassword);
        public void AddCard(Card newCard);
        public void RemoveCard(Card newCard);
        public void AddMoney(Card card, Double sum);
        public void MakeReport(Product product);
        public void AddReview(Product product, String message, int stars);
        public void RemoveReview(Review review);
        public void UpdateReview(Review review, string message);
    }
}
