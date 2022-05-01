using IdentityServer.API2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id = 1, Name = "Mono Lisa",Url="monolisa.jpg" },
                new Picture{Id = 1, Name = "Son Akşam Yemeği",Url="sonaksamyemegi.jpg" },   
                new Picture{Id = 2, Name = "Fareli Köyün Kavalcısı",Url="farelikoyunkavalcisi.jpg" },
           
            };
            return Ok(pictures);
        }
    }
}
