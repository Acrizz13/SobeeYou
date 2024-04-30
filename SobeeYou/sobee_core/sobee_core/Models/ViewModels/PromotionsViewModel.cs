using sobee_core.Models.AzureModels;

namespace sobee_core.Models.ViewModels {
    public class PromotionsViewModel {
        public List<PromotionDTO> Promotions { get; set; }
        public PromotionDTO PromotionToEdit { get; set; }
    }
}
