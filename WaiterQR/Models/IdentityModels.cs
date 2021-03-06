﻿// Handles the Account interaction data and gives feedback to the view

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WaiterQR.Models
{
    // Sie können Profildaten für den Benutzer hinzufügen, indem Sie der ApplicationUser-Klasse weitere Eigenschaften hinzufügen. Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<WaiterQR.Database.ShoppingCart> ShoppingCarts { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Models.RestaurantViewModel> RestaurantModels { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Database.Restaurant> Restaurants { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Database.RestaurantTable> RestaurantTables { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Models.RestaurantTableViewModel> RestaurantTableViewModels { get; set; }

        //public System.Data.Entity.DbSet<WaiterQR.Database.Product> Products { get; set; }
    }
}