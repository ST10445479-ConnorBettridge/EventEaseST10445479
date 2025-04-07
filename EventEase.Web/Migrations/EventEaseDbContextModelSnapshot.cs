using System;
using EventEase.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventEase.Web.Migrations
{
    [DbContext(typeof(EventEaseDbContext))]
    partial class EventEaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventEase.Web.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("EventId");

                    b.HasIndex("VenueId", "BookingDate")
                        .IsUnique();

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("EventEase.Web.Models.Event", e =>
                {
                    e.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(e.Property<int>("EventId"));

                    e.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    e.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    e.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    e.HasKey("EventId");

                    e.ToTable("Events");
                });

            modelBuilder.Entity("EventEase.Web.Models.Venue", v =>
                {
                    v.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(v.Property<int>("VenueId"));

                    v.Property<int>("Capacity")
                        .HasColumnType("int");

                    v.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    v.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    v.Property<string>("VenueName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    v.HasKey("VenueId");

                    v.ToTable("Venues");
                });

            modelBuilder.Entity("EventEase.Web.Models.Booking", b =>
                {
                    b.HasOne("EventEase.Web.Models.Event", "Event")
                        .WithMany("Bookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventEase.Web.Models.Venue", "Venue")
                        .WithMany("Bookings")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("EventEase.Web.Models.Event", e =>
                {
                    e.Navigation("Bookings");
                });

            modelBuilder.Entity("EventEase.Web.Models.Venue", v =>
                {
                    v.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
} 