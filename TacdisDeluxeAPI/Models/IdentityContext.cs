using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext()
            : base("IdentityContext", throwIfV1Schema: false)
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }
}
