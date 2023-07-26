﻿using Microsoft.EntityFrameworkCore;
using TravelEasy.ElectricVehicles.DB.Models;

namespace TravelEasy.EV.DataLayer
{
    public class ElectricVehiclesContext : DbContext
    {
        public DbSet<ElectricVehicle> ElectricVehicles { get; set;}
        public DbSet<Booking> Booking { get; set;}

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ElectricVehiclesContext(DbContextOptions<ElectricVehiclesContext> options)
           : base(options)
        {
        }
    }
}