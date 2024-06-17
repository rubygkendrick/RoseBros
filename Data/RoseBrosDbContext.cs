using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RoseBros.Models;
using Microsoft.AspNetCore.Identity;

namespace RoseBros.Data;
public class RoseBrosDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Rose> Roses { get; set; }
    public DbSet<Habit> Habits { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderRose> OrderRoses { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public RoseBrosDbContext(DbContextOptions<RoseBrosDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            UserName = "Boss",
            Email = "admina@strator.comx",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<OrderRose>()
             .HasKey(or => new { or.OrderId, or.RoseId });

        modelBuilder.Entity<OrderRose>()
            .HasOne(or => or.Order)
            .WithMany(o => o.OrderRoses)
            .HasForeignKey(or => or.OrderId);

        modelBuilder.Entity<OrderRose>()
              .HasOne(or => or.Rose)
              .WithMany(r => r.OrderRoses)
              .HasForeignKey(or => or.RoseId);


        modelBuilder.Entity<Habit>().HasData(
            new Habit
            {
                Id = 1,
                Name = "Climbing"
            },
            new Habit
            {
                Id = 2,
                Name = "Shrub"
            },
            new Habit
            {
                Id = 3,
                Name = "Tree"
            },
            new Habit
            {
                Id = 4,
                Name = "Rambling"
            }
        );
        modelBuilder.Entity<Color>().HasData(
           new Color
           {
               Id = 1,
               Name = "Apricot & Orange"
           },
           new Color
           {
               Id = 2,
               Name = "Pink"
           },
           new Color
           {
               Id = 3,
               Name = "Red"
           },
           new Color
           {
               Id = 4,
               Name = "White & Cream"
           },
           new Color
           {
               Id = 5,
               Name = "Yellow"
           }
       );
        modelBuilder.Entity<Rose>().HasData(
            new Rose
            {
                Id = 1,
                Name = "The Lady of The Lake",
                ColorId = 2,
                HabitId = 4,
                Description = "Its pretty, semi-double flowers, each about 2” across, are held in sprays on long, slender and flexible stems. They are a pale pink color and of open formation, each exposing a nice boss of golden stamens. They have a fresh citrus fragrance. Named after the ruler of Avalon in the Arthurian legend. She also plays a pivotal role in Sir Walter Scott’s famous poem of the same name.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/358bc42b0d8f9ba59b76aad2d2ed90f2_795x.jpg?v=1595523644",
                PricePerUnit = 35.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 2,
                Name = "Lady Of Shallot",
                ColorId = 1,
                HabitId = 2,
                Description = "Rich orange-red buds open to chalice-shaped blooms, filled with loosely arranged, orange petals. The surrounding outer petals are salmon-pink with beautifully contrasting golden-yellow undersides. There is a pleasant, warm Tea fragrance, with hints of spiced apple and cloves. It quickly forms a bushy shrub with slightly arching stems and mid-green leaves, which have attractive, slightly bronzed tones when young. The name is taken from one of Alfred, Lord Tennyson’s poems to commemorate the 200th anniversary of his birth.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/783d07a90fbff613fc0a0d0506858ccd_795x.jpg?v=1617282312",
                PricePerUnit = 36.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 3,
                Name = "Graham Thomas",
                ColorId = 5,
                HabitId = 1,
                Description = "A vigorous, upright climber bearing cupped blooms in an unusually rich shade of yellow. There is a light Tea fragrance with hints of violets. It is clothed in attractive, smooth green foliage.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/09e82fb705e43e9f3c3d31b9495757ac_ac2531c1-c620-410b-9a07-4b4a6bd66fc7_795x.jpg?v=1595522786",
                PricePerUnit = 55.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 4,
                Name = "Desdemona",
                ColorId = 4,
                HabitId = 2,
                Description = "Peachy pink buds open to beautiful, white, chalice-shaped blooms, with a pinkish hue. The incurved petals create an arresting interplay of light and shadow. The strong Old Rose fragrance has hints of almond blossom, cucumber and lemon zest. It forms a most attractive neat, rounded, bushy shrub. Named after the tragic heroine of Shakespeare’s Othello.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/ffd44b06340221e58080644cd3ad5c87_795x.jpg?v=1616146482",
                PricePerUnit = 35.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 5,
                Name = "Darcy Bussel",
                ColorId = 3,
                HabitId = 3,
                Description = "When young, the outer petals of each bloom form a perfect ring around an inner cup, gradually opening out to form a perfect, medium sized rosette. The color is a deep, rich crimson-pink, taking on a tinge of mauve just before the petals drop. There is a light-medium fruity scent. Named after the highly acclaimed ballerina.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/4f715479e7dbb2b800beda26869cbbb5_e15646fa-eda9-41ae-bec2-1d6dffcc10e3_795x.jpg?v=1595522050",
                PricePerUnit = 70.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 6,
                Name = "Boscobel",
                ColorId = 2,
                HabitId = 2,
                Description = "Red buds open to beautifully formed, upward facing, coral-pink rosettes. Small petals of varying shades mingle to provide a most pleasing effect. The myrrh fragrance has delicious hints of hawthorn, elderflower, pear and almond. It forms an upright shrub. Charles II hid in an oak tree at Boscobel House during the English Civil War.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/4dff2acd3891f03d26c87e66efa32606_795x.jpg?v=1595521190",
                PricePerUnit = 50.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 7,
                Name = "The Poet's Wife",
                ColorId = 5,
                HabitId = 3,
                Description = "Bears rich yellow flowers, which pale over time. Their formation is most pleasing, having a neat outer ring of petals enclosing an informal group of petals within. There is a strong, wonderfully rich fragrance with a hint of lemon, which becomes sweeter and stronger with age. It forms a bushy, nicely rounded tree with arching branches and rather shiny foliage.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/ec42c2f8ba68d786f220a5fdd3738b89_795x.jpg?v=1595524724",
                PricePerUnit = 50.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 8,
                Name = "Benjamin Britten",
                ColorId = 3,
                HabitId = 2,
                Description = "A variety of unusual coloring that changes with age to a glowing deep pink-red. The deeply cupped flowers soon open to slightly cupped rosettes. The fragrance is fruity, with aspects of wine and pear drops. It forms a dense, rather upright shrub.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/e3ce5bfc923712cc3fa0f4c423e49f1f_9d85aab2-745d-4b96-9448-10ee85a83937_795x.jpg?v=1595521072",
                PricePerUnit = 50.00M,
                OutOfStock = false
            },
            new Rose
            {
                Id = 9,
                Name = "Benjamin Britten",
                ColorId = 4,
                HabitId = 2,
                Description = "Small, single flowers held in very large heads, rather like a hydrangea, produced almost continuously from early summer into Fall. Soft apricot buds open to pure white, with a hint of soft lemon behind the stamens. It is extremely healthy and almost thornless. The growth is bushy and rather upright.",
                Image = "https://www.davidaustinroses.com/cdn/shop/products/f05472b357e002125394e843afc1e5a5_795x.jpg?v=1616501617",
                PricePerUnit = 35.00M,
                OutOfStock = false
            }
        );
        modelBuilder.Entity<Order>().HasData(
          new Order
          {
              Id = 1,
              UserProfileId = 1,
              PurchaseDate = DateTime.Now,
              IsFulfilled = false,
              IsActive = false
          },
          new Order
          {
              Id = 2,
              UserProfileId = 1,
              PurchaseDate = DateTime.Now,
              IsFulfilled = true,
              IsActive = false,
          }


        );
        modelBuilder.Entity<OrderRose>().HasData(
            new OrderRose
            {
                RoseId = 3,
                OrderId = 1,
                Quantity = 2
            },
            new OrderRose
            {
                RoseId = 2,
                OrderId = 1,
                Quantity = 1
            },
            new OrderRose
            {
                RoseId = 4,
                OrderId = 2,
                Quantity = 2
            }

         );


    }
}