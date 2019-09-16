using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Models;
using HotelManagementSystem.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models
{
    public class HotelContext: DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options):base(options)
        {}


        public DbSet<ReserveModel> Reserve { get; set; }
        public DbSet<GuestsModel> Guests { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeViewModel> RoomType { get; set; }
        public DbSet<GenderViewModel> Gender { get; set; }
        public DbSet<DepartmentViewModel> Departments { get; set; }
        public DbSet<ServiceCatagoryViewModel> ServiceCategory { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<BillViewModel> Bill { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReserveModel>().ToTable("ReserveTable");
            modelBuilder.Entity<GuestsModel>().ToTable("GuestTable");
            modelBuilder.Entity<RoomModel>().ToTable("RoomTable");
            modelBuilder.Entity<RoomTypeViewModel>().ToTable("RoomTypeTable");
            modelBuilder.Entity<GenderViewModel>().ToTable("GenderTable");
            modelBuilder.Entity<DepartmentViewModel>().ToTable("DepartmentTable");
            modelBuilder.Entity<ServiceCatagoryViewModel>().ToTable("ServiceCatagoryTable");
            modelBuilder.Entity<ServiceModel>().ToTable("ServiceTable");
            modelBuilder.Entity<EmployeeModel>().ToTable("EmployeeTable");
            modelBuilder.Entity<OrderModel>().ToTable("OrderTable");
            modelBuilder.Entity<BillViewModel>().ToTable("BillTable");
        }







    }
}
