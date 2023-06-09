﻿// <auto-generated />
using System;
using AjMusicApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AjMusicApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230508130127_20")]
    partial class _20
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AjMusicApi.Models.Artists", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<int?>("Followers")
                        .HasColumnType("int")
                        .HasColumnName("followers");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("img_url");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("AjMusicApi.Models.Auth", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("UserId");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("AjMusicApi.Models.Tracks", b =>
                {
                    b.Property<string>("TrackId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("track_id");

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("added_on");

                    b.Property<string>("ArtistId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artist_id");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("duration");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("img_url");

                    b.Property<int?>("Likes")
                        .HasColumnType("int")
                        .HasColumnName("likes");

                    b.Property<string>("PreviewUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("preview_url");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("AjMusicApi.Models.Users", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2")
                        .HasColumnName("dob");

                    b.Property<int?>("Following")
                        .HasColumnType("int")
                        .HasColumnName("following");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
