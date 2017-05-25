using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspNetCoreCms.Data;

namespace AspNetCoreCms.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170327001630_AddedCmsModels")]
    partial class AddedCmsModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreCms.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("SectionId");

                    b.Property<int>("SiteId");

                    b.Property<int>("SitePageId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("SitePageId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Branding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Header");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("TagLine");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Carousel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("SectionId");

                    b.Property<int>("SiteId");

                    b.Property<int>("SitePageId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("SitePageId");

                    b.ToTable("Carousel");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.CarouselSlide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<int>("CarouselId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CssClass");

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CarouselId");

                    b.ToTable("CarouselSlide");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<int?>("SitePageId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("SitePageId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("MenuId");

                    b.Property<int>("SortOrder");

                    b.Property<string>("Text");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CssClass");

                    b.Property<string>("CssId");

                    b.Property<string>("Element");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DomainName");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.SitePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrandingId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Heading");

                    b.Property<int?>("SiteId");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("BrandingId");

                    b.HasIndex("SiteId");

                    b.ToTable("SitePage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Article", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.SitePage")
                        .WithMany("Articles")
                        .HasForeignKey("SitePageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Carousel", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.SitePage")
                        .WithMany("Carousels")
                        .HasForeignKey("SitePageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.CarouselSlide", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.ContentTypes.Carousel")
                        .WithMany("Slides")
                        .HasForeignKey("CarouselId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.Menu", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.SitePage")
                        .WithMany("Menus")
                        .HasForeignKey("SitePageId");
                });

            modelBuilder.Entity("AspNetCoreCms.Models.ContentTypes.MenuItem", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.ContentTypes.Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspNetCoreCms.Models.SitePage", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.ContentTypes.Branding", "Branding")
                        .WithMany()
                        .HasForeignKey("BrandingId");

                    b.HasOne("AspNetCoreCms.Models.Site")
                        .WithMany("Pages")
                        .HasForeignKey("SiteId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AspNetCoreCms.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreCms.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
