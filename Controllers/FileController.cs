using blog.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace blog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();
            foreach(var file in files)
            {
                var uploadResult = new UploadResult();
                string trustedFileName;
                string unTrustedFileName = file.FileName;
                uploadResult.FileName= unTrustedFileName;
                //var trustedFileNameForDisplay= WebUtility.HtmlDecode(unTrustedFileName); ?

                trustedFileName = Path.GetRandomFileName();
                var path = Path.Combine(_env.ContentRootPath,"uploads", trustedFileName);
                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                uploadResult.StoredFileName = trustedFileName;
                uploadResults.Add(uploadResult);
            }
            return Ok(uploadResults);
        }
    }
}
