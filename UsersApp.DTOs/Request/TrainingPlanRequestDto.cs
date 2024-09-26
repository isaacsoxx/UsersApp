using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DTOs.Request
{
    public class PlansRequestDTO
    {
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The type of plan needs to be provided to categorize it")]
        public int Type { get; set; }
    }
}
