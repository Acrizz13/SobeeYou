﻿using sobee_core.Models;
using System.Security.Claims;

namespace sobee_core.Services {
    public interface IShoppingCartService {

        Task<int> GetShoppingCartIdAsync(ClaimsPrincipal user);
        Task UpdateShoppingCartUserIdAsync(string userId);
        Task<List<CartItemDTO>> GetCartItemsAsync(int shoppingCartId);
        Task<int> GetTotalCartItemsAsync(int shoppingCartId);
        Task<int> GetTotalCartItemsAsync(ClaimsPrincipal user);
        Task<decimal> GetTotalPriceAsync(int shoppingCartId);
        Task ClearCartAsync(ClaimsPrincipal user);
    }
}
