
namespace FitFlexApp.DTOs.Model
{
    public class ServiceResponseDTO<T>
    {
        public bool Error { get; set; } = false;
        public int StatusCode { get; set; } = 200;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
