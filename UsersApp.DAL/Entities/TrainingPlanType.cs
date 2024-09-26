using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.DAL.Entities
{
    public class TrainingPlanType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(5)]
        public string MonthlyFee {get; set; } = string.Empty;
    }
}
