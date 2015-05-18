﻿using POSCreditRepayments.Data.Repositories;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data
{
    public interface IPOSCreditRepaymentsData
    {
        IRepository<User> Users { get; }

        IRepository<Product> Products { get; }

        int SaveChanges();
    }
}
