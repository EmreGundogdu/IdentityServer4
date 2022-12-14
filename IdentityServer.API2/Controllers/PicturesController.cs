using IdentityServer.API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize  ]
    public class PicturesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>
            {
                new Picture(){Id=1,Name="Resim1",Url="resim1.jpg"},
                new Picture(){Id=2,Name="Resim2",Url="resim2.jpg"},
                new Picture(){Id=3,Name="Resim3",Url="resim3.jpg"},
            };
            return Ok(pictures);
        }
    }
}
