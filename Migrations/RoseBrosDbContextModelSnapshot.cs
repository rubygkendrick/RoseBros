﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoseBros.Data;

#nullable disable

namespace RoseBros.Migrations
{
    [DbContext(typeof(RoseBrosDbContext))]
    partial class RoseBrosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5e3cbfd8-8e6f-4365-8f15-7e4c6f7d87a1",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEIifYVsdyIexgoUIAz5iAIIlWoEIBXeEVQX6dIFnwEyQxWkFHxdatEKeMMB9uWb76A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "51ff1192-d121-421e-91dc-1e78e4ef1b96",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RoseBros.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apricot & Orange"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pink"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 4,
                            Name = "White & Cream"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yellow"
                        });
                });

            modelBuilder.Entity("RoseBros.Models.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Habits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Climbing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shrub"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tree"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rambling"
                        });
                });

            modelBuilder.Entity("RoseBros.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFulfilled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = false,
                            IsFulfilled = false,
                            PurchaseDate = new DateTime(2024, 6, 18, 9, 25, 45, 70, DateTimeKind.Local).AddTicks(5850),
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = false,
                            IsFulfilled = true,
                            PurchaseDate = new DateTime(2024, 6, 18, 9, 25, 45, 70, DateTimeKind.Local).AddTicks(5930),
                            UserProfileId = 1
                        });
                });

            modelBuilder.Entity("RoseBros.Models.OrderRose", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("RoseId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId", "RoseId");

                    b.HasIndex("RoseId");

                    b.ToTable("OrderRoses");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            RoseId = 3,
                            Quantity = 2m
                        },
                        new
                        {
                            OrderId = 1,
                            RoseId = 2,
                            Quantity = 1m
                        },
                        new
                        {
                            OrderId = 2,
                            RoseId = 4,
                            Quantity = 2m
                        });
                });

            modelBuilder.Entity("RoseBros.Models.Rose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HabitId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("OutOfStock")
                        .HasColumnType("boolean");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("HabitId");

                    b.ToTable("Roses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorId = 2,
                            Description = "Its pretty, semi-double flowers, each about 2” across, are held in sprays on long, slender and flexible stems. They are a pale pink color and of open formation, each exposing a nice boss of golden stamens. They have a fresh citrus fragrance. Named after the ruler of Avalon in the Arthurian legend. She also plays a pivotal role in Sir Walter Scott’s famous poem of the same name.",
                            HabitId = 4,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/358bc42b0d8f9ba59b76aad2d2ed90f2_795x.jpg?v=1595523644",
                            Name = "The Lady of The Lake",
                            OutOfStock = false,
                            PricePerUnit = 35.00m
                        },
                        new
                        {
                            Id = 2,
                            ColorId = 1,
                            Description = "Rich orange-red buds open to chalice-shaped blooms, filled with loosely arranged, orange petals. The surrounding outer petals are salmon-pink with beautifully contrasting golden-yellow undersides. There is a pleasant, warm Tea fragrance, with hints of spiced apple and cloves. It quickly forms a bushy shrub with slightly arching stems and mid-green leaves, which have attractive, slightly bronzed tones when young. The name is taken from one of Alfred, Lord Tennyson’s poems to commemorate the 200th anniversary of his birth.",
                            HabitId = 2,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/783d07a90fbff613fc0a0d0506858ccd_795x.jpg?v=1617282312",
                            Name = "Lady Of Shallot",
                            OutOfStock = false,
                            PricePerUnit = 36.00m
                        },
                        new
                        {
                            Id = 3,
                            ColorId = 5,
                            Description = "A vigorous, upright climber bearing cupped blooms in an unusually rich shade of yellow. There is a light Tea fragrance with hints of violets. It is clothed in attractive, smooth green foliage.",
                            HabitId = 1,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/09e82fb705e43e9f3c3d31b9495757ac_ac2531c1-c620-410b-9a07-4b4a6bd66fc7_795x.jpg?v=1595522786",
                            Name = "Graham Thomas",
                            OutOfStock = false,
                            PricePerUnit = 55.00m
                        },
                        new
                        {
                            Id = 4,
                            ColorId = 4,
                            Description = "Peachy pink buds open to beautiful, white, chalice-shaped blooms, with a pinkish hue. The incurved petals create an arresting interplay of light and shadow. The strong Old Rose fragrance has hints of almond blossom, cucumber and lemon zest. It forms a most attractive neat, rounded, bushy shrub. Named after the tragic heroine of Shakespeare’s Othello.",
                            HabitId = 2,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/ffd44b06340221e58080644cd3ad5c87_795x.jpg?v=1616146482",
                            Name = "Desdemona",
                            OutOfStock = false,
                            PricePerUnit = 35.00m
                        },
                        new
                        {
                            Id = 5,
                            ColorId = 3,
                            Description = "When young, the outer petals of each bloom form a perfect ring around an inner cup, gradually opening out to form a perfect, medium sized rosette. The color is a deep, rich crimson-pink, taking on a tinge of mauve just before the petals drop. There is a light-medium fruity scent. Named after the highly acclaimed ballerina.",
                            HabitId = 3,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/4f715479e7dbb2b800beda26869cbbb5_e15646fa-eda9-41ae-bec2-1d6dffcc10e3_795x.jpg?v=1595522050",
                            Name = "Darcy Bussel",
                            OutOfStock = false,
                            PricePerUnit = 70.00m
                        },
                        new
                        {
                            Id = 6,
                            ColorId = 2,
                            Description = "Red buds open to beautifully formed, upward facing, coral-pink rosettes. Small petals of varying shades mingle to provide a most pleasing effect. The myrrh fragrance has delicious hints of hawthorn, elderflower, pear and almond. It forms an upright shrub. Charles II hid in an oak tree at Boscobel House during the English Civil War.",
                            HabitId = 2,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/4dff2acd3891f03d26c87e66efa32606_795x.jpg?v=1595521190",
                            Name = "Boscobel",
                            OutOfStock = false,
                            PricePerUnit = 50.00m
                        },
                        new
                        {
                            Id = 7,
                            ColorId = 5,
                            Description = "Bears rich yellow flowers, which pale over time. Their formation is most pleasing, having a neat outer ring of petals enclosing an informal group of petals within. There is a strong, wonderfully rich fragrance with a hint of lemon, which becomes sweeter and stronger with age. It forms a bushy, nicely rounded tree with arching branches and rather shiny foliage.",
                            HabitId = 3,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/ec42c2f8ba68d786f220a5fdd3738b89_795x.jpg?v=1595524724",
                            Name = "The Poet's Wife",
                            OutOfStock = false,
                            PricePerUnit = 50.00m
                        },
                        new
                        {
                            Id = 8,
                            ColorId = 3,
                            Description = "A variety of unusual coloring that changes with age to a glowing deep pink-red. The deeply cupped flowers soon open to slightly cupped rosettes. The fragrance is fruity, with aspects of wine and pear drops. It forms a dense, rather upright shrub.",
                            HabitId = 2,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/e3ce5bfc923712cc3fa0f4c423e49f1f_9d85aab2-745d-4b96-9448-10ee85a83937_795x.jpg?v=1595521072",
                            Name = "Benjamin Britten",
                            OutOfStock = false,
                            PricePerUnit = 50.00m
                        },
                        new
                        {
                            Id = 9,
                            ColorId = 4,
                            Description = "Small, single flowers held in very large heads, rather like a hydrangea, produced almost continuously from early summer into Fall. Soft apricot buds open to pure white, with a hint of soft lemon behind the stamens. It is extremely healthy and almost thornless. The growth is bushy and rather upright.",
                            HabitId = 2,
                            Image = "https://www.davidaustinroses.com/cdn/shop/products/f05472b357e002125394e843afc1e5a5_795x.jpg?v=1616501617",
                            Name = "Benjamin Britten",
                            OutOfStock = false,
                            PricePerUnit = 35.00m
                        });
                });

            modelBuilder.Entity("RoseBros.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            Email = "admina@strator.comx",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoseBros.Models.Order", b =>
                {
                    b.HasOne("RoseBros.Models.UserProfile", "UserProfile")
                        .WithMany("Orders")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("RoseBros.Models.OrderRose", b =>
                {
                    b.HasOne("RoseBros.Models.Order", "Order")
                        .WithMany("OrderRoses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoseBros.Models.Rose", "Rose")
                        .WithMany("OrderRoses")
                        .HasForeignKey("RoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Rose");
                });

            modelBuilder.Entity("RoseBros.Models.Rose", b =>
                {
                    b.HasOne("RoseBros.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoseBros.Models.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("RoseBros.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("RoseBros.Models.Order", b =>
                {
                    b.Navigation("OrderRoses");
                });

            modelBuilder.Entity("RoseBros.Models.Rose", b =>
                {
                    b.Navigation("OrderRoses");
                });

            modelBuilder.Entity("RoseBros.Models.UserProfile", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
