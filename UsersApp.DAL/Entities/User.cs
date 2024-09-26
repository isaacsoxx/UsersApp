using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitFlexApp.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { set; get; }
        [Required]
        [MaxLength(128)]
        public string Email { set; get; } = string.Empty;
        [MaxLength(128)]
        public string? FirstName { set; get; } = string.Empty;
        [MaxLength(128)]
        public string? LastName { set; get; } = string.Empty;
        [Required]
        [MaxLength(128)]
        public string Password { get; set; } = string.Empty;

        [ForeignKey("AccessLevelId")]
        public AccessLevel? AccessLevel { get; set; } = null;
        public int? AccessLevelId { get; set; } = null;

        public List<TrainingPlan>? TrainingPlans {get; set;} = null;
        
    }
}
