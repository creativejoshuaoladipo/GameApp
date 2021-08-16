using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimplWebService.SimplWebService.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.SimplWebService.Data.DataContext
{
    public class SimpleDbContext : IdentityDbContext<User, Role, int>
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> dbContextOptions) : base(dbContextOptions)
        {



        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(u =>
                {
                    u.ToTable("Users");
                    u.HasKey(p => p.Id);
                    u.Property(p => p.PasswordHash).HasColumnName("Password").HasColumnType("varchar(250)");
                    u.Property(p => p.PhoneNumber).HasColumnType("varchar(15)");
                    u.Property(p => p.Email).HasColumnType("varchar(100)");
                    u.Property(p => p.NormalizedEmail).HasColumnType("varchar(100)");
                    u.Property(p => p.UserName).HasColumnType("varchar(100)");
                    u.Property(p => p.NormalizedUserName).HasColumnType("varchar(100)");
                    u.Property(p => p.ConcurrencyStamp).HasColumnType("varchar(100)");
                    u.Property(p => p.FirstName).HasColumnType("varchar(100)");
                    u.Property(p => p.LastName).HasColumnType("varchar(100)");          
                
                });



            builder.Entity<User>().HasData(new User 
            {
            Id = 1,
            FirstName = "Joshua",
            LastName = "Oladipo",
            PhoneNumber = "07060412177",
            Email = "joshuaoladipo29@gmail.com",
            UserName = "joshuaoladipo29@gmail.com"

            });


            builder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Femi",
                LastName = "Adewale",
                PhoneNumber = "0807878777",
                Email = "joshuaoladipo29@gmail.com",
                UserName = "joshuaoladipo29@gmail.com"

            });

            builder.Entity<Role>().HasData(new Role
            { 
                Id = 1,
                Name = "Administrators",
                ConcurrencyStamp = Guid.NewGuid().ToString(), 
                NormalizedName = "ADMINISTRATORS"
            });
        }


        

    }
}
