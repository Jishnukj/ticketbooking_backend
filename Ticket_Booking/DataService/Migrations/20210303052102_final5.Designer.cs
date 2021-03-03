﻿// <auto-generated />
using System;
using DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataService.Migrations
{
    [DbContext(typeof(ApplicationdbContext))]
    [Migration("20210303052102_final5")]
    partial class final5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataService.Entities.Booking", b =>
                {
                    b.Property<int>("booking_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("booking_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("No_of_tickets")
                        .HasColumnType("integer")
                        .HasColumnName("no_of_tickets");

                    b.Property<DateTime>("booking_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("booking_date");

                    b.Property<int>("event_id")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<float>("totalprice")
                        .HasColumnType("real")
                        .HasColumnName("totalprice");

                    b.Property<int>("user_id")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("booking_id")
                        .HasName("pk_bookings");

                    b.HasIndex("event_id")
                        .HasDatabaseName("ix_bookings_event_id");

                    b.HasIndex("user_id")
                        .HasDatabaseName("ix_bookings_user_id");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("DataService.Entities.Comment", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comment_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("event_id")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<string>("reply")
                        .HasColumnType("text")
                        .HasColumnName("reply");

                    b.Property<int>("user_id")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("comment_id")
                        .HasName("pk_comments");

                    b.HasIndex("event_id")
                        .HasDatabaseName("ix_comments_event_id");

                    b.HasIndex("user_id")
                        .HasDatabaseName("ix_comments_user_id");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("DataService.Entities.Event", b =>
                {
                    b.Property<int>("event_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("event_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("approval_status")
                        .HasColumnType("text")
                        .HasColumnName("approval_status");

                    b.Property<string>("artist_name")
                        .HasColumnType("text")
                        .HasColumnName("artist_name");

                    b.Property<int>("available_seats")
                        .HasColumnType("integer")
                        .HasColumnName("available_seats");

                    b.Property<string>("description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("event_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("event_date");

                    b.Property<string>("event_name")
                        .HasColumnType("text")
                        .HasColumnName("event_name");

                    b.Property<DateTime>("event_time")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("event_time");

                    b.Property<string>("image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<float>("ticketprice")
                        .HasColumnType("real")
                        .HasColumnName("ticketprice");

                    b.Property<int>("venue_id")
                        .HasColumnType("integer")
                        .HasColumnName("venue_id");

                    b.HasKey("event_id")
                        .HasName("pk_events");

                    b.HasIndex("venue_id")
                        .HasDatabaseName("ix_events_venue_id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("DataService.Entities.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("band_name")
                        .HasColumnType("text")
                        .HasColumnName("band_name");

                    b.Property<string>("email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("user_name")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<string>("user_type")
                        .HasColumnType("text")
                        .HasColumnName("user_type");

                    b.HasKey("user_id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DataService.Entities.Venue", b =>
                {
                    b.Property<int>("venue_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("venue_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("ticket_rate")
                        .HasColumnType("real")
                        .HasColumnName("ticket_rate");

                    b.Property<int>("total_seats")
                        .HasColumnType("integer")
                        .HasColumnName("total_seats");

                    b.Property<string>("venue_name")
                        .HasColumnType("text")
                        .HasColumnName("venue_name");

                    b.HasKey("venue_id")
                        .HasName("pk_venues");

                    b.ToTable("venues");
                });

            modelBuilder.Entity("DataService.Entities.Booking", b =>
                {
                    b.HasOne("DataService.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("event_id")
                        .HasConstraintName("fk_bookings_events_event_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataService.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("fk_bookings_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataService.Entities.Comment", b =>
                {
                    b.HasOne("DataService.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("event_id")
                        .HasConstraintName("fk_comments_events_event_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataService.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("fk_comments_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataService.Entities.Event", b =>
                {
                    b.HasOne("DataService.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("venue_id")
                        .HasConstraintName("fk_events_venues_venue_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });
#pragma warning restore 612, 618
        }
    }
}
