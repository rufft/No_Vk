﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using No_Vk.Domain.Models.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace No_Vk.Domain.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20220406142454_Ver0.1.2")]
    partial class Ver012
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Chat", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Friend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("MyId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MyId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Notice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("ChatId")
                        .HasColumnType("text");

                    b.Property<string>("MessageText")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("No_Vk.Domain.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("No_Vk.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Friend", b =>
                {
                    b.HasOne("No_Vk.Domain.Models.User", "Me")
                        .WithMany("Friends")
                        .HasForeignKey("MyId");

                    b.Navigation("Me");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Message", b =>
                {
                    b.HasOne("No_Vk.Domain.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
