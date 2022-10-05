using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArch.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@localhost",
                    Email = "user@localhost",
                    NormalizedUserName = "USER@LOCALHOST",
                    NormalizedEmail = "USER@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var userCreated = _userManager.CreateAsync(user, "Abc123!@#").Result;

                if (userCreated.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var userCreated = _userManager.CreateAsync(user, "Abc123!@#").Result;

                if (userCreated.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                };

                var roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                };

                var roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
