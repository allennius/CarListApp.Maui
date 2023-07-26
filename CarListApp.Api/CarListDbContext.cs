using Microsoft.EntityFrameworkCore;

public class CarListDbContext : DbContext
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
    }


}