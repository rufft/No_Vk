﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20220313131125_Ver2.36")]
    partial class Ver236
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Chat", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ChatCreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Friend", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Notice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddresseeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Object")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddresseeId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("MessageCreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("FromUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

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
                    b.HasOne("No_Vk.Domain.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Data.Notice", b =>
                {
                    b.HasOne("No_Vk.Domain.Models.User", "Addressee")
                        .WithMany()
                        .HasForeignKey("AddresseeId");

                    b.Navigation("Addressee");
                });

            modelBuilder.Entity("No_Vk.Domain.Models.Message", b =>
                {
                    b.HasOne("No_Vk.Domain.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("No_Vk.Domain.Models.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId");

                    b.Navigation("Chat");

                    b.Navigation("FromUser");
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
