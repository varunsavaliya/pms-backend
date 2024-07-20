namespace PMS.Model.DTOs.Response
{
    public class ApiResponseDTO(object? data = null, string? message = null, bool success = true)
    {
        public bool Success { get; set; } = success;

        public string Message { get; set; } = message ?? string.Empty;

        public object? Data { get; set; } = data;
    }
}
