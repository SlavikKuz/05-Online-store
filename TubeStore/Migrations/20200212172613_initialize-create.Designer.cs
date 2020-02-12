﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TubeStore.Data;

namespace TubeStore.Migrations
{
    [DbContext(typeof(TubeStoreDbContext))]
    [Migration("20200212172613_initialize-create")]
    partial class initializecreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TubeStore.Models.Carousel", b =>
                {
                    b.Property<int>("CarouselId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarouselId");

                    b.ToTable("Carousels");

                    b.HasData(
                        new
                        {
                            CarouselId = 1,
                            Description = "Premium selected",
                            ImageUrl = "/Images/Carousel/carousel_01.jpg",
                            Status = true,
                            Title = "ECC82"
                        },
                        new
                        {
                            CarouselId = 2,
                            Description = "Platinum matched quad",
                            ImageUrl = "/Images/Carousel/carousel_02.jpg",
                            Status = true,
                            Title = "6P14P"
                        },
                        new
                        {
                            CarouselId = 3,
                            Description = "Tested pre-amp set",
                            ImageUrl = "/Images/Carousel/carousel_03.jpg",
                            Status = true,
                            Title = "6N6P"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Pre Triodes"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Tube", b =>
                {
                    b.Property<int>("TubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewArrival")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTubeOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<bool>("MatchedPair")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TubeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tubes");

                    b.HasData(
                        new
                        {
                            TubeId = 1,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "10.1963",
                            FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                            ImageThumbnailUrl = "/Images/PreTriodes/6N1P/20160808_6N1Pnevz_small.jpg",
                            ImageUrl = "/Images/PreTriodes/6N1P/20160808_6N1Pnevz.jpg",
                            InStock = false,
                            IsNewArrival = false,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 12.00m,
                            Quantity = 62,
                            ShortDescription = "NOS, Gray plates, gold grids, mica",
                            Type = "6N1P"
                        },
                        new
                        {
                            TubeId = 2,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "01.1967",
                            FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                            ImageThumbnailUrl = "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates_small.jpg",
                            ImageUrl = "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates.jpg",
                            InStock = true,
                            IsNewArrival = false,
                            IsTubeOfTheWeek = true,
                            MatchedPair = true,
                            Price = 115.00m,
                            Quantity = 12,
                            ShortDescription = "NOS, box plates",
                            Type = "6N1P"
                        },
                        new
                        {
                            TubeId = 3,
                            Brand = "Foton",
                            CategoryId = 1,
                            Date = "1960s",
                            FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                            ImageThumbnailUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pfoton_small.jpg",
                            ImageUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pfoton.jpg",
                            InStock = true,
                            IsNewArrival = false,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 39.99m,
                            Quantity = 30,
                            ShortDescription = "square getter, millitary grade",
                            Type = "6N6P"
                        },
                        new
                        {
                            TubeId = 4,
                            Brand = "NEVZ",
                            CategoryId = 1,
                            Date = "08.1974",
                            FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                            ImageThumbnailUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pnevz_small.jpg",
                            ImageUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pnevz.jpg",
                            InStock = true,
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = true,
                            Price = 89.99m,
                            Quantity = 10,
                            ShortDescription = "gold pin & grid",
                            Type = "6N6P"
                        },
                        new
                        {
                            TubeId = 5,
                            Brand = "Tungsram",
                            CategoryId = 1,
                            Date = "1970s",
                            FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                            ImageThumbnailUrl = "/Images/PreTriodes/ECC82/20171220_ECC82tungsram_small.jpg",
                            ImageUrl = "/Images/PreTriodes/ECC82/20171220_ECC82tungsram.jpg",
                            InStock = true,
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = false,
                            Price = 49.99m,
                            Quantity = 11,
                            ShortDescription = "Made in hungary",
                            Type = "ECC82"
                        },
                        new
                        {
                            TubeId = 6,
                            Brand = "Mullard",
                            CategoryId = 1,
                            Date = "02.1961",
                            FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                            ImageThumbnailUrl = "/Images/PreTriodes/ECC82/20171212_ECC82mullard_small.jpg",
                            ImageUrl = "/Images/PreTriodes/ECC82/20171212_ECC82mullard.jpg",
                            InStock = true,
                            IsNewArrival = true,
                            IsTubeOfTheWeek = false,
                            MatchedPair = false,
                            Price = 299.99m,
                            Quantity = 3,
                            ShortDescription = "Made in Great Britain",
                            Type = "ECC82"
                        });
                });

            modelBuilder.Entity("TubeStore.Models.Category", b =>
                {
                    b.HasOne("TubeStore.Models.Category", "Parent")
                        .WithMany("Parents")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TubeStore.Models.Tube", b =>
                {
                    b.HasOne("TubeStore.Models.Category", "Category")
                        .WithMany("Tubes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
