﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bacheler_work.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class Sensor
    {   
        [DisplayName("ID")]
        public int Id { set; get; }
        [DisplayName("Phone number")]
        public string phoneNumber { get; set; }
        [DisplayName("Location")]
        public string location { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        public ICollection<Data> datas { get; set; }

        public Sensor()
        {
            datas = new List<Data>();
        }
    }
    public class Data
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        [DisplayName("Data")]
        public string dateTime { set; get; }
        [DisplayName("Batery")]
        public int batery { get; set; }
        [DisplayName("Water")]
        public int water { get; set; }
    }
    public class Statistic
    {
        public int lowWater { get; set; }
        public int hightWater { get; set; }
        public int averageWater { get; set; }

        public float lowBaterry { get; set; }
        public float hightBaterry { get; set; }
        public float averageBaterry { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sensor> sensors { get; set; }
        public DbSet<Data> Data { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}