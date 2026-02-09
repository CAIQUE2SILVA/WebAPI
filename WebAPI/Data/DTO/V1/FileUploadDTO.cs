using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO.V1
{
    public class FileUploadDTO
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
