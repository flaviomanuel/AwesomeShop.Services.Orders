using System;
using AwesomeShop.Services.Orders.Core.Entities;
using AwesomeShop.Services.Orders.Core.ValueObjects;

namespace AwesomeShop.Services.Orders.Core.Events
{
    public class OrderCreated : IDomainEvent
    {
        public OrderCreated(Guid id, decimal totalPrice, PaymentInfo paymentInfo, string fullName, Customer customer)
        {
            Id = id;
            TotalPrice = totalPrice;
            PaymentInfo = paymentInfo;
            FullName = fullName;
            Customer = customer;
        }

        public Guid Id { get; }
        public decimal TotalPrice { get; }
        public PaymentInfo PaymentInfo { get; }
        public string FullName { get; }
        public Customer Customer { get; }
    }
}