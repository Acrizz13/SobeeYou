namespace sobee_core.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDTO Product { get; set; }
        public List<ProductDTO> RelatedProducts { get; set; }
    }
}
