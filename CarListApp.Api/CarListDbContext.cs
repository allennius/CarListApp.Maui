using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CarListDbContext : IdentityDbContext
{

    public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
    {

    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>().HasData(
            new Car
            {
                Id = 1,
                Make = "Ford",
                Model = "Mustang",
                Vin = "1967"
            },

            new Car
            {
                Id = 2,
                Make = "Honda",
                Model = "2000",
                Vin = "2004"
            },
            new Car
            {
                Id = 3,
                Make = "Toyota",
                Model = "Supra",
                Vin = "2000"
            },
            new Car
            {
                Id = 4,
                Make = "Dodge",
                Model = "Charger",
                Vin = "1994"
            },
            new Car
            {
                Id = 5,
                Make = "Ferrari",
                Model = "V70",
                Vin = "2020"
            }

        );

        modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "5b827e64-4126-490a-8834-fb9a7c47f6b3",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = "33b160d2-341e-4799-af9d-6bd149226c62",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

        var hasher = new PasswordHasher<IdentityUser>();

        modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "6490751e-1342-476a-bb01-a515eadafa78",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new IdentityUser
                {
                    Id = "d9496331-4421-4d51-9c19-3f3e67c93913",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                    EmailConfirmed = true
                }
            );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5b827e64-4126-490a-8834-fb9a7c47f6b3",
                    UserId = "6490751e-1342-476a-bb01-a515eadafa78"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "33b160d2-341e-4799-af9d-6bd149226c62",
                    UserId = "d9496331-4421-4d51-9c19-3f3e67c93913"
                }

            );
    }


}