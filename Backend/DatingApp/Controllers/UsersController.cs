using AutoMapper;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _Mapper;
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _UserRepository = userRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //var users = await _UserRepository.GetUserAsync();
            //var UserReturn = _Mapper.Map<IEnumerable<MemberDto>>(users);
            //return Ok(UserReturn);

            var user = await _UserRepository.GetMembersAsync();
            return Ok(user);
                
        }


        [HttpGet("{id}")]
        
        public async Task <ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await _UserRepository.GetUserByIdAsync(id);
            return _Mapper.Map<MemberDto>(user);

        }

        [HttpGet("{username}")]

        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            //var user = await _UserRepository.GetMemberAsync (username);
            //return _Mapper.Map<MemberDto>(user);
            return await _UserRepository.GetMemberAsync(username);
   
        }
    }
}
