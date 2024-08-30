using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

public class ImageController : Controller
{
    private readonly AzureBlobService _blobService;

    public ImageController(AzureBlobService blobService)
    {
        _blobService = blobService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                await _blobService.UploadImageAsync(stream, file.FileName);
            }
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Download(string fileName)
    {
        var stream = await _blobService.DownloadImageAsync(fileName);
        return File(stream, "image/jpeg");
    }
}

