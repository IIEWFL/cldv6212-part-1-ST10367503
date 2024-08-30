using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

public class ContractController : Controller
{
    private readonly AzureFileService _fileService;

    public ContractController(AzureFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                await _fileService.UploadFileAsync(stream, file.FileName);
            }
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Download(string fileName)
    {
        var stream = await _fileService.DownloadFileAsync(fileName);
        return File(stream, "application/octet-stream", fileName);
    }
}

