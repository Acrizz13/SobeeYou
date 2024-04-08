namespace sobee_core.Models {
    public class ShoppingCartViewModel {
        public List<CartItemDTO> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalCartItems { get; set; }
    }
}
