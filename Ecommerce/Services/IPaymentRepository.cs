﻿using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IPaymentRepository
    {
        public Task<bool> AddOrderAsync(MyOrder newOrder);
        public bool UpdateMyItem(MyItem item);
        public bool UpdateUser(User user);
        public Task<MyOrder?> GetOrderByIdAsync(int orderId);
        public Task<bool> AddShippingAddressAsync(ShippingAddress shippingAddress);
        public Task<bool> UpdateMyOrderAsync(MyOrder myOrder);
        public Task<MyOrder?> GetOrderWithItemsByIdAsync(int orderId);
        public Task<MyOrder?> GetFullOrderByIdAsync(int orderId);
        public bool DeleteItem(MyItem item);
        public void SaveChangesInTheDatabase();
        public (bool wasValid, string? message) CheckAndChangeMyItemsQuantityFromStock(ref MyItem item);
	}
}
