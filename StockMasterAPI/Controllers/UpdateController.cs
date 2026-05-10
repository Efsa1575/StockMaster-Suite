using Microsoft.AspNetCore.Mvc;

namespace StockMasterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : ControllerBase
    {
        [HttpGet("check")]
        public IActionResult Check(string version)
        {
            string latestVersion = "1.0.1";

            if (version != latestVersion)
            {
                return Ok(new
                {
                    update = true,
                    newVersion = latestVersion,
                    message = "Yeni güncelleme mevcut!"
                });
            }

            return Ok(new
            {
                update = false,
                message = "Program güncel."
            });
        }
    }
}