using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO.V1
{
    public class MuiltipleFilesUploadDTO
    {
        [Required]
        public List<IFormFile> Files { get; set; }
    }
}
