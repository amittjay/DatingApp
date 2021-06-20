using DatingApp.DTOs;
using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Interfaces
{
  public interface IUserRepository
    {
        void Update(AppUsers users);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUsers>> GetUserAsync();

        Task<AppUsers> GetUserByIdAsync(int id);

        Task<AppUsers> GetUserByUserNameAsync(string username);

        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberAsync(string username);
    }
}
