using System.ComponentModel.DataAnnotations;

namespace RedingtonTechTest.WebAPI.Models
{
    public class CalculationInput
    {
        [Required(ErrorMessage = "Both inputs are required")]
        [Range(0, 1, ErrorMessage = "Probability value must be between 0 and 1")]
        public decimal A { get; set; }

        [Required(ErrorMessage = "Both inputs are required")]
        [Range(0, 1, ErrorMessage = "Probability value must be between 0 and 1")]
        public decimal B { get; set; }
    }
}
