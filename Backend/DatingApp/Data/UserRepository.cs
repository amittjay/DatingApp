using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public readonly IMapper _mapper;
        public UserRepository(DataContext context,IMapper imapper)
        {
            _context = context;
            _mapper = imapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
           
                 return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users.
            ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
            
        }

        public async Task<IEnumerable<AppUsers>> GetUserAsync()
        {

            return await _context.Users.Include(p=>p.photos)
                .ToListAsync();
        }

        public async Task<AppUsers> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUsers> GetUserByUserNameAsync(string username)
        {
            return await  _context.Users
                .Include(p=>p.photos)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUsers users)
        {
            _context.Entry(users).State = EntityState.Modified; 
        }
    }
}
