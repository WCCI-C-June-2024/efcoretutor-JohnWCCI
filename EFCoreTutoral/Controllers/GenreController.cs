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
    public class GenreController : BaseController<GenreModel> { 
    
        public GenreController(MusicContext context, ILogger<GenreController> logger) 
            : base(context,logger)
        { }
    }

 }