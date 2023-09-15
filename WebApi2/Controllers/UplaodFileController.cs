using Apiwork.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UplaodFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _dataContext;

        public UplaodFileController(IWebHostEnvironment webHostEnvironment,DataContext dataContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _dataContext=dataContext;
        }


        [HttpPost("[action]")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {


            if (files.Count > 0)
            {
                var file = files[0];

                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "UplodeFile");
                    var fileName = Guid.NewGuid().ToString().Replace("_", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                }

            }
            return Ok("Upload Successful");
        }
    }
}

