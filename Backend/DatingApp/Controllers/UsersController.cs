﻿using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task <ActionResult<IEnumerable<AppUsers>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [Authorize]
        [HttpGet("{id}")]
        
        public async Task <ActionResult<AppUsers>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
