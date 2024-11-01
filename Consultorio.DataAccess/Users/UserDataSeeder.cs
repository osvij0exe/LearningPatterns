using Consultorio.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Users
{
    public static class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<ConsultorioUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Roles
            var adminRole = new IdentityRole(Constantes.AdminRol);
            var patientRole = new IdentityRole(Constantes.PatientRol);
            var practitionerRole = new IdentityRole(Constantes.PractitionerRol);

            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(patientRole);
            await roleManager.CreateAsync(practitionerRole);

            //Usuario administrador
            var administrador = new ConsultorioUser()
            {
                GivenName = "Admin",
                FamilyName = "HospitalAdmin",
                UserName = "Admin",
                Email = "admin@gmail.com",
                PhoneNumber = "52 989 989 989",
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(administrador,"Admin123*");
            if(result.Succeeded)
            {
                //asegura que el usuario se creo correctamente
                administrador = await userManager.FindByEmailAsync(administrador.Email);
                if(administrador is not null)
                {
                    await userManager.AddToRoleAsync(administrador, Constantes.AdminRol);
                }
            }




        }

    }
}
