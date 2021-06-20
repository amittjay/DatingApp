using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using DatingApp.Entities;
using System.Security.Cryptography;

namespace DatingApp.Data
{
    public class Seed
    {
        public static async Task SeedUser(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var Userdata = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var Users = JsonSerializer.Deserialize<List<AppUsers>>(Userdata);

            foreach (var user in Users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("pa$$w0rd"));
                user.PasswordSalt = hmac.Key;
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }

    }
}
