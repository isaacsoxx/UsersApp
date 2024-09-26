namespace FitFlexApp.DTOs.Model
{
    public class TrainingPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public required TrainingPlanTypeDTO TrainingPlanType { get; set; }
    }

    public class TrainingPlanTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MonthlyFee {get; set; } = string.Empty;

    }
}
