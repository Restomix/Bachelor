using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

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
        public int Id { set; get; }
        public string phoneNumber { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public Data dataInformation { get; set; }
        public Statistic statistic { get; set; } 
    }
    public class Data
    {   
        public DateTime dateTime { set; get; }
        public decimal batery { get; set; }
        public decimal water { get; set; }
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