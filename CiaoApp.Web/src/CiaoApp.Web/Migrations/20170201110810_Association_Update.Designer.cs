using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CiaoApp.Web.Data;

namespace CiaoApp.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170201110810_Association_Update")]
    partial class Association_Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CiaoApp.Web.Models.Actors.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsVirtual");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("ActorId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Contacts.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActorId");

                    b.Property<int?>("ContactGroupId");

                    b.Property<string>("Nickname");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("ContactGroupId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Contacts.ContactGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActorId");

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("ContactGroup");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Messages.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("PromiseId");

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PromiseId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Notifications.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsSeen");

                    b.Property<int>("OwnerId");

                    b.Property<int?>("RelatedPromiseId");

                    b.Property<DateTime?>("SeenOn");

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RelatedPromiseId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Association", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildId");

                    b.Property<int?>("ParentId");

                    b.Property<int?>("TargetState");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ParentId");

                    b.ToTable("Association");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.BasePromise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Product");

                    b.HasKey("Id");

                    b.ToTable("BasePromise");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BasePromise");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.PromiseState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Attained");

                    b.Property<int>("PromiseID");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PromiseID");

                    b.ToTable("State");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActorId");

                    b.Property<int?>("BasePromiseId");

                    b.Property<bool>("IsCustom");

                    b.Property<bool>("IsForOffer");

                    b.Property<bool>("IsForPromise");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BasePromiseId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
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

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Offer", b =>
                {
                    b.HasBaseType("CiaoApp.Web.Models.Promises.BasePromise");

                    b.Property<int?>("OffererId");

                    b.Property<int?>("SelectedContactGroupId");

                    b.Property<int>("TargetType");

                    b.HasIndex("OffererId");

                    b.HasIndex("SelectedContactGroupId");

                    b.ToTable("Offer");

                    b.HasDiscriminator().HasValue("Offer");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Promise", b =>
                {
                    b.HasBaseType("CiaoApp.Web.Models.Promises.BasePromise");

                    b.Property<int?>("ExecutorId");

                    b.Property<int?>("InitiatorId");

                    b.Property<DateTime?>("Term");

                    b.Property<int>("TermType");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("InitiatorId");

                    b.ToTable("Promise");

                    b.HasDiscriminator().HasValue("Promise");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.ApplicationUser", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Contacts.Contact", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CiaoApp.Web.Models.Contacts.ContactGroup")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactGroupId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Contacts.ContactGroup", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor")
                        .WithMany("ContactGroups")
                        .HasForeignKey("ActorId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Messages.Message", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CiaoApp.Web.Models.Promises.Promise", "Promise")
                        .WithMany()
                        .HasForeignKey("PromiseId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Notifications.Notification", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CiaoApp.Web.Models.Promises.Promise", "RelatedPromise")
                        .WithMany()
                        .HasForeignKey("RelatedPromiseId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Association", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Promises.BasePromise", "Child")
                        .WithMany("ParentAssociations")
                        .HasForeignKey("ChildId");

                    b.HasOne("CiaoApp.Web.Models.Promises.BasePromise", "Parent")
                        .WithMany("ChildAssociations")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.PromiseState", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Promises.Promise", "Promise")
                        .WithMany("States")
                        .HasForeignKey("PromiseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Tag", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Promises.BasePromise")
                        .WithMany("Tags")
                        .HasForeignKey("BasePromiseId");
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
                    b.HasOne("CiaoApp.Web.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.ApplicationUser")
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

                    b.HasOne("CiaoApp.Web.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Offer", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Offerer")
                        .WithMany()
                        .HasForeignKey("OffererId");

                    b.HasOne("CiaoApp.Web.Models.Contacts.ContactGroup", "SelectedContactGroup")
                        .WithMany()
                        .HasForeignKey("SelectedContactGroupId");
                });

            modelBuilder.Entity("CiaoApp.Web.Models.Promises.Promise", b =>
                {
                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Executor")
                        .WithMany("Requests")
                        .HasForeignKey("ExecutorId");

                    b.HasOne("CiaoApp.Web.Models.Actors.Actor", "Initiator")
                        .WithMany("Promises")
                        .HasForeignKey("InitiatorId");
                });
        }
    }
}
