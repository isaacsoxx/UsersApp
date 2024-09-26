namespace FitFlexApp.DTOs.Model
{
    public class UserDTO
    {
        public int Id {  get; set; }
        public int UserId { set; get; }
        public string Email { set; get; } = String.Empty;
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string Password { set; get; } = String.Empty;
        public required AccessLevelDTO AccessLevel { set; get; }
    }

    public class UserIncludePlanDTO : UserDTO
    {
        public ICollection<TrainingPlanDTO> TrainingPlans { set; get; } = new List<TrainingPlanDTO>();
    }

    public class AccessLevelDTO {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
