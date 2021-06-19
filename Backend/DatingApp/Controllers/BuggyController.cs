using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _Context;
        public BuggyController(DataContext context)
        {
            _Context = context;
        }
        [Authorize]
        [HttpGet("Auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret key";
        }

        [HttpGet("NotFound")]
        public ActionResult<AppUsers> GetNotFound()
        {
            var thing = _Context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }

        [HttpGet("Server-error")]
        public ActionResult<string> GetServererror()
        {
            var thing = _Context.Users.Find(-1);
            var returntoserver = thing.ToString();
            return returntoserver;
            
        }

        [HttpGet("Bad-Request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("this was not a good request");
        }
    }
}
