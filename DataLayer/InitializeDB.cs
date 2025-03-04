﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public static class InitializeDB
    {
        public async static Task InitDB(DiplomContext _context) 
        {
            
            //инициализация
            if (!await _context.BasisOfLearning.AnyAsync())
            {
                _context.BasisOfLearning.Add(new Entity.BasisOfLearning() { Title = "Бюджет" });
                _context.BasisOfLearning.Add(new Entity.BasisOfLearning() { Title = "Контракт" });
                _context.BasisOfLearning.Add(new Entity.BasisOfLearning() { Title = "Целевое" });
            }
            
            await _context.SaveChangesAsync();
        }

        public async static Task InitRole(UserManager<Entity.User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // возможно потом сделаю красивее
            string adminLogin = "admin";
            string adminPassword = "Admin.123";

            if (await roleManager.FindByNameAsync("Администратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Администратор"));
            }
            if (await roleManager.FindByNameAsync("Куратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Куратор"));
            }
            if (await userManager.FindByNameAsync(adminLogin) == null)
            {
                Entity.User admin = new Entity.User
                {
                    UserName = adminLogin,
                    FirstName = "Admin",
                    SecondName = "Admin",
                    LastName = "Admin",
                };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Администратор");
                }
               
            }
            
        }
    }
}
