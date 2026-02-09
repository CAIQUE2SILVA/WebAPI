using WebAPI.Data.DTO.V1;

namespace WebAPI.Services
{
    public interface IFileServices
    {
        byte[] GetFile(string fileName);
        Task<FileDetailDTO> SaveFileToDisk(IFormFile file);
        Task<List<FileDetailDTO>> SaveFilesToDisk(List<IFormFile> files);



    }
}
