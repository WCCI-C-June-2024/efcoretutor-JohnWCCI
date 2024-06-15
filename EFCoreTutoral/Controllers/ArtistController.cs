using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreTutoral.Context;
using EFCoreTutoral.Models;
using Microsoft.Extensions.Logging;

namespace EFCoreTutoral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : BaseController<ArtistModel>
    {
        public ArtistController(MusicContext context, ILogger<ArtistController> logger)
          : base(context, logger)
        { }
    }
}