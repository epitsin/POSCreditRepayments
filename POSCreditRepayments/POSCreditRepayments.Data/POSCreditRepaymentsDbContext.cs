﻿using Microsoft.AspNet.Identity.EntityFramework;
using POSCreditRepayments.Models;
using System.Data.Entity;

namespace POSCreditRepayments.Data
{
    public class POSCreditRepaymentsDbContext : IdentityDbContext<User>, IPOSCreditRepaymentsDbContext
    {
        public POSCreditRepaymentsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static POSCreditRepaymentsDbContext Create()
        {
            return new POSCreditRepaymentsDbContext();
        }
    }
}
