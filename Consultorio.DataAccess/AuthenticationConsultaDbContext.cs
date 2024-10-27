using Consultorio.DataAccess.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess
{
    public class AuthenticationConsultaDbContext :IdentityDbContext<ConsultorioUser>
    {
        public AuthenticationConsultaDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ConsultorioUser>(e => e.ToTable("Usuario"));
            builder.Entity<IdentityRole>(e => e.ToTable("Rol"));
            builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRol"));

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveMaxLength(150);

        }




    }
}
