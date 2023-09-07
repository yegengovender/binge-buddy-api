﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace binge_buddy_api.Migrations
{
    [DbContext(typeof(UserDb))]
    partial class UserDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EpisodeOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PremiereDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLarge")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NextEpisodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Premiered")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NextEpisodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("ShowsProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserShowId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserShowId");

                    b.ToTable("ShowsProgress");
                });

            modelBuilder.Entity("TvEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Airdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Runtime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Season")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("WatchedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("TvEpisodes");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LoggedIn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LastEpisode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserShows");
                });

            modelBuilder.Entity("Season", b =>
                {
                    b.HasOne("Show", null)
                        .WithMany("Seasons")
                        .HasForeignKey("ShowId");
                });

            modelBuilder.Entity("Show", b =>
                {
                    b.HasOne("TvEpisode", "NextEpisode")
                        .WithMany()
                        .HasForeignKey("NextEpisodeId");

                    b.HasOne("User", null)
                        .WithMany("Shows")
                        .HasForeignKey("UserId");

                    b.Navigation("NextEpisode");
                });

            modelBuilder.Entity("ShowsProgress", b =>
                {
                    b.HasOne("UserShow", null)
                        .WithMany("Progress")
                        .HasForeignKey("UserShowId");
                });

            modelBuilder.Entity("TvEpisode", b =>
                {
                    b.HasOne("Show", null)
                        .WithMany("Episodes")
                        .HasForeignKey("ShowId");
                });

            modelBuilder.Entity("UserShow", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("UserShows")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Show", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Shows");

                    b.Navigation("UserShows");
                });

            modelBuilder.Entity("UserShow", b =>
                {
                    b.Navigation("Progress");
                });
#pragma warning restore 612, 618
        }
    }
}
